namespace WindowsUI
{
    partial class FormStartMenu
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
            this.buttonNumberOfChances = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNumberOfChances
            // 
            this.buttonNumberOfChances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNumberOfChances.Location = new System.Drawing.Point(33, 36);
            this.buttonNumberOfChances.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.buttonNumberOfChances.Name = "buttonNumberOfChances";
            this.buttonNumberOfChances.Size = new System.Drawing.Size(829, 90);
            this.buttonNumberOfChances.TabIndex = 0;
            this.buttonNumberOfChances.UseVisualStyleBackColor = true;
            this.buttonNumberOfChances.Click += new System.EventHandler(this.buttonNumberOfChances_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(587, 231);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(278, 72);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormStartMenu
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(919, 353);
            this.Controls.Add(this.buttonNumberOfChances);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulls and Cows";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNumberOfChances;
        private System.Windows.Forms.Button buttonStart;
    }
}

