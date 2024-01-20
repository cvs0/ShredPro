namespace ShredPro
{
    partial class Form1
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
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnShred = new System.Windows.Forms.Button();
            this.cmbAlgorithms = new System.Windows.Forms.ComboBox();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.btnZeroData = new System.Windows.Forms.Button();
            this.comboBoxAlphabet = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(145, 103);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(339, 108);
            this.lbFiles.TabIndex = 0;
            this.lbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragDrop);
            this.lbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragEnter);
            // 
            // btnShred
            // 
            this.btnShred.BackColor = System.Drawing.Color.LawnGreen;
            this.btnShred.ForeColor = System.Drawing.Color.Black;
            this.btnShred.Location = new System.Drawing.Point(490, 103);
            this.btnShred.Name = "btnShred";
            this.btnShred.Size = new System.Drawing.Size(75, 23);
            this.btnShred.TabIndex = 1;
            this.btnShred.Text = "Shred";
            this.btnShred.UseVisualStyleBackColor = false;
            this.btnShred.Click += new System.EventHandler(this.btnShred_Click);
            // 
            // cmbAlgorithms
            // 
            this.cmbAlgorithms.FormattingEnabled = true;
            this.cmbAlgorithms.Location = new System.Drawing.Point(490, 132);
            this.cmbAlgorithms.Name = "cmbAlgorithms";
            this.cmbAlgorithms.Size = new System.Drawing.Size(182, 21);
            this.cmbAlgorithms.TabIndex = 2;
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.AutoSize = true;
            this.lblTotalSize.Location = new System.Drawing.Point(145, 218);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(0, 13);
            this.lblTotalSize.TabIndex = 3;
            // 
            // btnZeroData
            // 
            this.btnZeroData.BackColor = System.Drawing.Color.LawnGreen;
            this.btnZeroData.Location = new System.Drawing.Point(490, 74);
            this.btnZeroData.Name = "btnZeroData";
            this.btnZeroData.Size = new System.Drawing.Size(98, 23);
            this.btnZeroData.TabIndex = 4;
            this.btnZeroData.Text = "Cleanse Drive";
            this.btnZeroData.UseVisualStyleBackColor = false;
            this.btnZeroData.Click += new System.EventHandler(this.btnZeroData_Click);
            // 
            // comboBoxAlphabet
            // 
            this.comboBoxAlphabet.FormattingEnabled = true;
            this.comboBoxAlphabet.Location = new System.Drawing.Point(594, 74);
            this.comboBoxAlphabet.Name = "comboBoxAlphabet";
            this.comboBoxAlphabet.Size = new System.Drawing.Size(32, 21);
            this.comboBoxAlphabet.TabIndex = 5;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(410, 218);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.comboBoxAlphabet);
            this.Controls.Add(this.btnZeroData);
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.cmbAlgorithms);
            this.Controls.Add(this.btnShred);
            this.Controls.Add(this.lbFiles);
            this.Name = "Form1";
            this.Text = "ShredPro | V. 1.1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnShred;
        private System.Windows.Forms.ComboBox cmbAlgorithms;
        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.Button btnZeroData;
        private System.Windows.Forms.ComboBox comboBoxAlphabet;
        private System.Windows.Forms.Button clearButton;
    }
}

