using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataImporter
{
    public partial class AMCImportForm : Form
    {
        public AMCImportForm()
        {
            InitializeComponent();
        }

        private void CancelButton_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SrcButton_click(object sender, EventArgs e)
        {

            folderDialog.Description = "Select the old AMC TC installation directory.";
            folderDialog.ShowDialog();
            this.srcBox.Text = folderDialog.SelectedPath;
        }

        private void DestButton_click(object sender, EventArgs e)
        {
            folderDialog.Description = "Select the new AMC TC installation directory."; 
            folderDialog.ShowDialog();
            this.destBox.Text = folderDialog.SelectedPath;
        }

        private bool DoCFGImport(string src_file, string dest_path)
        {
            StreamReader src_sr = new StreamReader(File.OpenRead(src_file));

            string dst_file = Path.Combine(dest_path, "amctc.cfg");
            StreamWriter dst_sr = new StreamWriter(File.Create(dst_file));

            bool made_changes = false;
            string src_line = src_sr.ReadLine();

            while (src_line != null)
            {
                while (src_line != null && !src_line.StartsWith("[Gamevars]") && !src_line.StartsWith("[Controls]"))
                    src_line = src_sr.ReadLine();

                if (src_line != null)
                {
                    dst_sr.WriteLine(src_line);

                    src_line = src_sr.ReadLine();
                    while (!string.IsNullOrEmpty(src_line) && !string.IsNullOrWhiteSpace(src_line) && !src_line.StartsWith("["))
                    {
                        dst_sr.WriteLine(src_line);
                        src_line = src_sr.ReadLine();
                    }
                    dst_sr.WriteLine();
                    made_changes = true;
                }

            }
            dst_sr.Close();
            src_sr.Close();
            return made_changes;
        }


        private bool DoSettingsImport(string src_file, string dest_path)
        {
            StreamReader src_sr = new StreamReader(File.OpenRead(src_file));

            string dst_file = Path.Combine(dest_path, "settings.cfg");
            StreamWriter dst_sr = new StreamWriter(File.Create(dst_file));

            bool made_changes = false;
            string src_line = src_sr.ReadLine();
            while (src_line != null)
            {
                if (src_line.StartsWith("//") || src_line.StartsWith("bind") || src_line.StartsWith("unbound") || src_line.StartsWith("unbindall"))
                {
                    dst_sr.WriteLine(src_line);
                }
                src_line = src_sr.ReadLine();
                made_changes = true;
            }

            dst_sr.Close();
            src_sr.Close();
            return made_changes;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

            string srcpath = srcBox.Text;
            string destpath = destBox.Text;

            if (string.IsNullOrEmpty(srcpath) || string.IsNullOrEmpty(destpath))
            {
                MessageBox.Show("Error: Must select both source and destination path!", "Error: Empty Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try 
            {
                if (!Directory.Exists(destpath))
                {
                    MessageBox.Show("Error: Invalid Directory: " + destpath, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (File.Exists(Path.Combine(destpath, "amctc.grpinfo")))
                {
                    string src_datafolder = Path.Combine(srcpath, "DATA");
                    string dest_datafolder = Path.Combine(destpath,"DATA");

                    if (Directory.Exists(src_datafolder))
                    {
                        bool made_changes;

                        // Confirm
                        DialogResult r = MessageBox.Show("Are you sure you want to import?\nThis will overwrite your current progress!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.No)
                            return;
 
                        // Copy DATA contents over
                        if (made_changes = !Directory.Exists(dest_datafolder))
                            Directory.CreateDirectory(dest_datafolder);
                        
                        IEnumerable<string> files = Directory.EnumerateFiles(src_datafolder);
                        foreach (string full_path in files)
                        {
                            string filename = Path.GetFileName(full_path).ToUpper(); 
                            File.Copy(full_path, Path.Combine(dest_datafolder, filename), true);
                            made_changes |= true;
                        }


                        // Copy CFG gamevars over
                        string amctc_cfg_path = Path.Combine(srcpath, "amctc.cfg");
                        string eduke_cfg_path = Path.Combine(srcpath, "eduke32.cfg");
                        int result = 0;

                        if (File.Exists(amctc_cfg_path) && File.Exists(eduke_cfg_path))
                        {
                            result = DateTime.Compare(File.GetLastWriteTime(amctc_cfg_path), File.GetLastWriteTime(eduke_cfg_path));
                        }

                        if (File.Exists(amctc_cfg_path) && result >= 0)
                        {
                            made_changes |= this.DoCFGImport(amctc_cfg_path, destpath);
                        } 
                        else if (File.Exists(eduke_cfg_path) && result <= 0)
                        {
                            made_changes |= this.DoCFGImport(eduke_cfg_path, destpath);
                        }

                        // Copy keyboard binds
                        if (File.Exists(Path.Combine(srcpath, "settings.cfg")))
                        {
                            made_changes |= this.DoSettingsImport(Path.Combine(srcpath, "settings.cfg"), destpath);
                        }

                        if (made_changes)
                            MessageBox.Show("Import Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Warning: Did not find any data to import!", "No Data Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Error: Source directory is not a valid AMC TC directory!", "Invalid Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error: Destination is not a valid AMC TC directory!", "Invalid Destination", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            catch(DirectoryNotFoundException d)
            {
                MessageBox.Show("Error: Invalid Directory: " + d.Message, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException a)
            {
                MessageBox.Show("Error: Invalid path: " + a.Message, "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
