namespace DataImporter
{
    partial class AMCImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMCImportForm));
            this.srcButton = new System.Windows.Forms.Button();
            this.destButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.infoLabel = new System.Windows.Forms.Label();
            this.srcBox = new System.Windows.Forms.TextBox();
            this.destBox = new System.Windows.Forms.TextBox();
            this.srcLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // srcButton
            // 
            this.srcButton.Location = new System.Drawing.Point(391, 66);
            this.srcButton.Name = "srcButton";
            this.srcButton.Size = new System.Drawing.Size(77, 23);
            this.srcButton.TabIndex = 7;
            this.srcButton.Text = "Change";
            this.srcButton.UseVisualStyleBackColor = true;
            this.srcButton.Click += new System.EventHandler(this.SrcButton_click);
            // 
            // destButton
            // 
            this.destButton.Location = new System.Drawing.Point(391, 97);
            this.destButton.Name = "destButton";
            this.destButton.Size = new System.Drawing.Size(77, 23);
            this.destButton.TabIndex = 3;
            this.destButton.Text = "Change";
            this.destButton.UseVisualStyleBackColor = true;
            this.destButton.Click += new System.EventHandler(this.DestButton_click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(74, 135);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(169, 23);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(264, 135);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(170, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_click);
            // 
            // folderDialog
            // 
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.SystemColors.Control;
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(78, 15);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(337, 15);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Import progress from a previous version of The AMC Squad";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // srcBox
            // 
            this.srcBox.BackColor = System.Drawing.SystemColors.Window;
            this.srcBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.srcBox.Location = new System.Drawing.Point(97, 68);
            this.srcBox.Name = "srcBox";
            this.srcBox.Size = new System.Drawing.Size(288, 20);
            this.srcBox.TabIndex = 6;
            this.srcBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // destBox
            // 
            this.destBox.BackColor = System.Drawing.SystemColors.Window;
            this.destBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destBox.Location = new System.Drawing.Point(97, 99);
            this.destBox.Name = "destBox";
            this.destBox.Size = new System.Drawing.Size(288, 20);
            this.destBox.TabIndex = 5;
            this.destBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // srcLabel
            // 
            this.srcLabel.AutoSize = true;
            this.srcLabel.Location = new System.Drawing.Point(47, 71);
            this.srcLabel.Name = "srcLabel";
            this.srcLabel.Size = new System.Drawing.Size(44, 13);
            this.srcLabel.TabIndex = 8;
            this.srcLabel.Text = "Source:";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(30, 102);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(63, 13);
            this.destLabel.TabIndex = 9;
            this.destLabel.Text = "Destination:";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.BackColor = System.Drawing.SystemColors.Control;
            this.warningLabel.ForeColor = System.Drawing.Color.DimGray;
            this.warningLabel.Location = new System.Drawing.Point(89, 40);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(317, 13);
            this.warningLabel.TabIndex = 10;
            this.warningLabel.Text = "Warning: This will overwrite the progress in your destination folder!";
            // 
            // AMCImportForm
            // 
            this.AcceptButton = this.importButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(504, 171);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.srcLabel);
            this.Controls.Add(this.srcButton);
            this.Controls.Add(this.srcBox);
            this.Controls.Add(this.destBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.destButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 210);
            this.MinimumSize = new System.Drawing.Size(520, 210);
            this.Name = "AMCImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMC Progress Import Tool (Episode 4)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button destButton;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox destBox;
        private System.Windows.Forms.TextBox srcBox;
        private System.Windows.Forms.Button srcButton;
        private System.Windows.Forms.Label srcLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.Label warningLabel;
    }
}

