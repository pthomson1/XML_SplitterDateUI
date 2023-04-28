namespace XML_SplitterDateUI
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
            this.BeginningDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSourceFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSaveLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BeginningDateTimePicker
            // 
            this.BeginningDateTimePicker.Location = new System.Drawing.Point(60, 104);
            this.BeginningDateTimePicker.Name = "BeginningDateTimePicker";
            this.BeginningDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.BeginningDateTimePicker.TabIndex = 0;
            // 
            // EndingDateTimePicker
            // 
            this.EndingDateTimePicker.Location = new System.Drawing.Point(415, 104);
            this.EndingDateTimePicker.Name = "EndingDateTimePicker";
            this.EndingDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.EndingDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Beginning Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ending Date";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(246, 180);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(168, 79);
            this.RunButton.TabIndex = 4;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(694, 24);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSourceFolderToolStripMenuItem,
            this.selectSaveLocationToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // selectSourceFolderToolStripMenuItem
            // 
            this.selectSourceFolderToolStripMenuItem.Name = "selectSourceFolderToolStripMenuItem";
            this.selectSourceFolderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.selectSourceFolderToolStripMenuItem.Text = "Select Source Folder";
            this.selectSourceFolderToolStripMenuItem.Click += new System.EventHandler(this.selectSourceFolderToolStripMenuItem_Click);
            // 
            // selectSaveLocationToolStripMenuItem
            // 
            this.selectSaveLocationToolStripMenuItem.Name = "selectSaveLocationToolStripMenuItem";
            this.selectSaveLocationToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.selectSaveLocationToolStripMenuItem.Text = "Select Save Location";
            this.selectSaveLocationToolStripMenuItem.Click += new System.EventHandler(this.selectSaveLocationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 335);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndingDateTimePicker);
            this.Controls.Add(this.BeginningDateTimePicker);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker BeginningDateTimePicker;
        private System.Windows.Forms.DateTimePicker EndingDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectSourceFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectSaveLocationToolStripMenuItem;
    }
}

