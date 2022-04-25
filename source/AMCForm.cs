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
            destBox.Text = AppDomain.CurrentDomain.BaseDirectory;
        }

        private void CancelButton_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SrcButton_click(object sender, EventArgs e)
        {
            folderDialog.SelectedPath = this.srcBox.Text;
            folderDialog.Description = "Select the old AMC Squad or AMC TC installation directory.";
            DialogResult r = folderDialog.ShowDialog();
            if (r == DialogResult.OK)
                this.srcBox.Text = folderDialog.SelectedPath;
        }

        private void DestButton_click(object sender, EventArgs e)
        {
            folderDialog.SelectedPath = this.destBox.Text;
            folderDialog.Description = "Select the new AMC Squad installation directory."; 
            DialogResult r = folderDialog.ShowDialog();
            if (r == DialogResult.OK)
                this.destBox.Text = folderDialog.SelectedPath;
        }

        private bool isAMCDir(string path)
        {
            return File.Exists(Path.Combine(path, "AMCTC.grp")) || File.Exists(Path.Combine(path, "AMCSQUAD.grp"));
        }

        private bool checkImportErrors(string srcpath, string dstpath)
        {
            if (string.IsNullOrEmpty(srcpath) || string.IsNullOrEmpty(dstpath))
            {
                MessageBox.Show("Error: Must select both source and destination path!", "Error: Empty Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (srcpath.Equals(dstpath))
            {
                MessageBox.Show("Error: Source path must differ from destination!", "Error: Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (!Directory.Exists(srcpath))
            {
                MessageBox.Show("Error: Invalid Directory: " + srcpath, "Error: Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (!Directory.Exists(dstpath))
            {
                MessageBox.Show("Error: Invalid Directory: " + dstpath, "Error: Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (!isAMCDir(srcpath))
            {
                MessageBox.Show("Error: Source folder is not a valid AMC TC/AMC Squad directory!", "Error: Invalid Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (!isAMCDir(dstpath))
            {
                MessageBox.Show("Error: Destination folder is not a valid AMC TC/AMC Squad directory!", "Error: Invalid Destination", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private bool DoCFGImport(string src_file, string dest_path)
        {
            bool made_changes = false;
            string dst_file = Path.Combine(dest_path, "amctc.cfg");
            StreamReader src_sr = new StreamReader(File.OpenRead(src_file));
            StreamWriter dst_sr = new StreamWriter(File.Create(dst_file));

            string src_line = src_sr.ReadLine();
            while (src_line != null)
            {
                // commented out the [Controls] block because mouse settings don't port over well
                while (src_line != null && !src_line.StartsWith("[Gamevars]")) // && !src_line.StartsWith("[Controls]"))
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
            bool made_changes = false;
            string dst_file = Path.Combine(dest_path, "settings.cfg");
            StreamReader src_sr = new StreamReader(File.OpenRead(src_file));
            StreamWriter dst_sr = new StreamWriter(File.Create(dst_file));

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
            string dstpath = destBox.Text;

            if (checkImportErrors(srcpath, dstpath))
                return;

            // Confirmation dialog
            DialogResult r = MessageBox.Show("Are you sure you want to import?\nThis will overwrite your current progress!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            try 
            {
                string changeNotes = "";

                // Attempt to copy DATA contents over
                string src_datafolder = Path.Combine(srcpath, "DATA");
                string dst_datafolder = Path.Combine(dstpath,"DATA");
                if (Directory.Exists(src_datafolder))
                {
                    if (!Directory.Exists(dst_datafolder))
                        Directory.CreateDirectory(dst_datafolder);

                    IEnumerable<string> files = Directory.EnumerateFiles(src_datafolder);
                    foreach (string full_path in files)
                    {
                        string filename = Path.GetFileName(full_path).ToUpper();
                        File.Copy(full_path, Path.Combine(dst_datafolder, filename), true);
                    }
                    changeNotes += "Imported game progress from DATA folder.\n";
                }

                // Copy CFG gamevars over
                string amctc_cfg_path = Path.Combine(srcpath, "amctc.cfg");
                string eduke_cfg_path = Path.Combine(srcpath, "eduke32.cfg");
                int lastWrite = 0;

                if (File.Exists(amctc_cfg_path) && File.Exists(eduke_cfg_path))
                {
                    lastWrite = DateTime.Compare(File.GetLastWriteTime(amctc_cfg_path), File.GetLastWriteTime(eduke_cfg_path));
                }

                if (File.Exists(amctc_cfg_path) && lastWrite >= 0)
                {
                    this.DoCFGImport(amctc_cfg_path, dstpath);
                    changeNotes += "Copied data from \"amctc.cfg\".\n";
                } 
                else if (File.Exists(eduke_cfg_path) && lastWrite <= 0)
                {
                    this.DoCFGImport(eduke_cfg_path, dstpath);
                    changeNotes += "Copied data from \"eduke32.cfg\".\n";
                }

                // Copy keyboard binds
                if (File.Exists(Path.Combine(srcpath, "settings.cfg")))
                {
                    this.DoSettingsImport(Path.Combine(srcpath, "settings.cfg"), dstpath);
                    changeNotes += "Copied data from \"settings.cfg\".\n";
                }

                if (!string.IsNullOrEmpty(changeNotes))
                {
                    MessageBox.Show("Import Successful!\n\n" + changeNotes, "Data Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Warning: Did not find any data to import!", "No Data Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            catch(DirectoryNotFoundException d)
            {
                MessageBox.Show("Error: invalid directory: " + d.Message, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException a)
            {
                MessageBox.Show("Error: invalid path: " + a.Message, "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
