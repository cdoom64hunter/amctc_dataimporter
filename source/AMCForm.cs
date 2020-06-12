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
            
            string src_line = src_sr.ReadLine();
            while (src_line  != null && !src_line.StartsWith("[Gamevars]"))
                src_line = src_sr.ReadLine();

            if (src_line != null)
            {
                string dst_file = Path.Combine(dest_path, @"amctc.cfg"); 
                StreamWriter dst_sr = new StreamWriter(File.Create(dst_file));
                dst_sr.WriteLine("[Gamevars]");
                while (!string.IsNullOrEmpty(src_line = src_sr.ReadLine()))
                    dst_sr.WriteLine(src_line);
                
                dst_sr.Close();
                src_sr.Close();
                return true;
            }

            src_sr.Close();
            return false;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

            string srcpath = srcBox.Text;
            string destpath = destBox.Text;

            try 
            {
                if (!Directory.Exists(destpath))
                {
                    MessageBox.Show("Invalid Directory: " + destpath, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (File.Exists(Path.Combine(srcpath, "amctc.cfg")))
                        {
                            made_changes |= this.DoCFGImport(Path.Combine(srcpath,"amctc.cfg"), destpath);
                        } 
                        else if (File.Exists(Path.Combine(srcpath, "eduke32.cfg")))
                        {
                            made_changes |= this.DoCFGImport(Path.Combine(srcpath, "eduke32.cfg"), destpath);
                        }

                        if (made_changes)
                            MessageBox.Show("Import Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Did not find any data to import!", "No Data Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Invalid Directory: " + d.Message, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException a)
            {
                MessageBox.Show("Invalid path: " + a.Message, "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
