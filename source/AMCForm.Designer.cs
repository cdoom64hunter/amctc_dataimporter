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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // srcButton
            // 
            this.srcButton.Location = new System.Drawing.Point(380, 88);
            this.srcButton.Name = "srcButton";
            this.srcButton.Size = new System.Drawing.Size(91, 23);
            this.srcButton.TabIndex = 7;
            this.srcButton.Text = "Change";
            this.srcButton.UseVisualStyleBackColor = true;
            this.srcButton.Click += new System.EventHandler(this.SrcButton_click);
            // 
            // destButton
            // 
            this.destButton.Location = new System.Drawing.Point(380, 123);
            this.destButton.Name = "destButton";
            this.destButton.Size = new System.Drawing.Size(91, 23);
            this.destButton.TabIndex = 3;
            this.destButton.Text = "Change";
            this.destButton.UseVisualStyleBackColor = true;
            this.destButton.Click += new System.EventHandler(this.DestButton_click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(87, 178);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(169, 23);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(275, 178);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(170, 23);
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
            this.infoLabel.Location = new System.Drawing.Point(95, 20);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(318, 15);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Import progress from a previous version of the AMC TC.";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // srcBox
            // 
            this.srcBox.BackColor = System.Drawing.SystemColors.Control;
            this.srcBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcBox.Location = new System.Drawing.Point(107, 90);
            this.srcBox.Name = "srcBox";
            this.srcBox.Size = new System.Drawing.Size(267, 20);
            this.srcBox.TabIndex = 6;
            this.srcBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // destBox
            // 
            this.destBox.BackColor = System.Drawing.SystemColors.Control;
            this.destBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destBox.Location = new System.Drawing.Point(107, 125);
            this.destBox.Name = "destBox";
            this.destBox.Size = new System.Drawing.Size(267, 20);
            this.destBox.TabIndex = 5;
            this.destBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // srcLabel
            // 
            this.srcLabel.AutoSize = true;
            this.srcLabel.Location = new System.Drawing.Point(57, 93);
            this.srcLabel.Name = "srcLabel";
            this.srcLabel.Size = new System.Drawing.Size(44, 13);
            this.srcLabel.TabIndex = 8;
            this.srcLabel.Text = "Source:";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(38, 128);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(63, 13);
            this.destLabel.TabIndex = 9;
            this.destLabel.Text = "Destination:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Warning: This will overwrite the progress in your destination folder!";
            // 
            // AMCImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 228);
            this.Controls.Add(this.label1);
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
            this.Name = "AMCImportForm";
            this.Text = "Import AMC TC Data";
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
        private System.Windows.Forms.Label label1;
    }
}

