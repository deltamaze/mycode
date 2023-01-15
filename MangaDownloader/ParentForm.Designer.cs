namespace MangaDownloader
{
    partial class ParentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectManaga = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ChapterSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSelectManaga
            // 
            this.buttonSelectManaga.Location = new System.Drawing.Point(66, 23);
            this.buttonSelectManaga.Name = "buttonSelectManaga";
            this.buttonSelectManaga.Size = new System.Drawing.Size(137, 23);
            this.buttonSelectManaga.TabIndex = 0;
            this.buttonSelectManaga.Text = "Select Manga";
            this.buttonSelectManaga.UseVisualStyleBackColor = true;
            this.buttonSelectManaga.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSelectManaga_MouseClick);
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(12, 52);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 386);
            this.mainPanel.TabIndex = 1;
            // 
            // ChapterSelect
            // 
            this.ChapterSelect.Location = new System.Drawing.Point(224, 23);
            this.ChapterSelect.Name = "ChapterSelect";
            this.ChapterSelect.Size = new System.Drawing.Size(133, 23);
            this.ChapterSelect.TabIndex = 2;
            this.ChapterSelect.Text = "Chapter Select";
            this.ChapterSelect.UseVisualStyleBackColor = true;
            this.ChapterSelect.Click += new System.EventHandler(this.ChapterSelect_Click);
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChapterSelect);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonSelectManaga);
            this.Name = "ParentForm";
            this.Text = "ParentForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSelectManaga;
        private Panel mainPanel;
        private Button ChapterSelect;
    }
}
