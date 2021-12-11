
namespace TV_Slideshow_Config_Editor
{
    partial class ConfigEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEditor));
            this.TabControl_MainConfig = new System.Windows.Forms.TabControl();
            this.TabPage_Defaults = new System.Windows.Forms.TabPage();
            this.TabPage_TimeDisplay = new System.Windows.Forms.TabPage();
            this.TabPage_Sites = new System.Windows.Forms.TabPage();
            this.TabPage_Notifications = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TabControl_MainConfig.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_MainConfig
            // 
            this.TabControl_MainConfig.Controls.Add(this.TabPage_Defaults);
            this.TabControl_MainConfig.Controls.Add(this.TabPage_TimeDisplay);
            this.TabControl_MainConfig.Controls.Add(this.TabPage_Sites);
            this.TabControl_MainConfig.Controls.Add(this.TabPage_Notifications);
            this.TabControl_MainConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_MainConfig.Enabled = false;
            this.TabControl_MainConfig.HotTrack = true;
            this.TabControl_MainConfig.Location = new System.Drawing.Point(0, 24);
            this.TabControl_MainConfig.Name = "TabControl_MainConfig";
            this.TabControl_MainConfig.SelectedIndex = 0;
            this.TabControl_MainConfig.Size = new System.Drawing.Size(922, 485);
            this.TabControl_MainConfig.TabIndex = 0;
            this.TabControl_MainConfig.Tag = "";
            // 
            // TabPage_Defaults
            // 
            this.TabPage_Defaults.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Defaults.Name = "TabPage_Defaults";
            this.TabPage_Defaults.Size = new System.Drawing.Size(914, 459);
            this.TabPage_Defaults.TabIndex = 0;
            this.TabPage_Defaults.Tag = "defaults";
            this.TabPage_Defaults.Text = "Defaults";
            this.TabPage_Defaults.UseVisualStyleBackColor = true;
            // 
            // TabPage_TimeDisplay
            // 
            this.TabPage_TimeDisplay.Location = new System.Drawing.Point(4, 22);
            this.TabPage_TimeDisplay.Name = "TabPage_TimeDisplay";
            this.TabPage_TimeDisplay.Size = new System.Drawing.Size(914, 459);
            this.TabPage_TimeDisplay.TabIndex = 1;
            this.TabPage_TimeDisplay.Tag = "timedisplay";
            this.TabPage_TimeDisplay.Text = "Show Time";
            this.TabPage_TimeDisplay.UseVisualStyleBackColor = true;
            // 
            // TabPage_Sites
            // 
            this.TabPage_Sites.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Sites.Name = "TabPage_Sites";
            this.TabPage_Sites.Size = new System.Drawing.Size(914, 459);
            this.TabPage_Sites.TabIndex = 2;
            this.TabPage_Sites.Tag = "sites";
            this.TabPage_Sites.Text = "Sites";
            this.TabPage_Sites.UseVisualStyleBackColor = true;
            // 
            // TabPage_Notifications
            // 
            this.TabPage_Notifications.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Notifications.Name = "TabPage_Notifications";
            this.TabPage_Notifications.Size = new System.Drawing.Size(914, 459);
            this.TabPage_Notifications.TabIndex = 3;
            this.TabPage_Notifications.Tag = "notifications";
            this.TabPage_Notifications.Text = "Notifications";
            this.TabPage_Notifications.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(922, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.MenuFile_Open,
            this.toolStripSeparator1,
            this.MenuFile_Save,
            this.MenuFile_SaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.MenuFile_New_Click);
            // 
            // MenuFile_Open
            // 
            this.MenuFile_Open.Name = "MenuFile_Open";
            this.MenuFile_Open.Size = new System.Drawing.Size(123, 22);
            this.MenuFile_Open.Text = "Open...";
            this.MenuFile_Open.Click += new System.EventHandler(this.MenuFile_Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // MenuFile_Save
            // 
            this.MenuFile_Save.Enabled = false;
            this.MenuFile_Save.Name = "MenuFile_Save";
            this.MenuFile_Save.Size = new System.Drawing.Size(123, 22);
            this.MenuFile_Save.Text = "Save...";
            this.MenuFile_Save.Click += new System.EventHandler(this.MenuFile_Save_Click);
            // 
            // MenuFile_SaveAs
            // 
            this.MenuFile_SaveAs.Enabled = false;
            this.MenuFile_SaveAs.Name = "MenuFile_SaveAs";
            this.MenuFile_SaveAs.Size = new System.Drawing.Size(123, 22);
            this.MenuFile_SaveAs.Text = "Save As...";
            this.MenuFile_SaveAs.Click += new System.EventHandler(this.MenuFile_SaveAs_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "json";
            this.openFileDialog1.FileName = "config.json";
            this.openFileDialog1.Filter = "JSON Files|*.json";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "config.json";
            this.saveFileDialog1.Filter = "JSON Files|*.json";
            // 
            // ConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 509);
            this.Controls.Add(this.TabControl_MainConfig);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConfigEditor";
            this.Tag = "defaults";
            this.Text = "TV Slideshow Config Editor";
            this.TabControl_MainConfig.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl_MainConfig;
        private System.Windows.Forms.TabPage TabPage_Defaults;
        private System.Windows.Forms.TabPage TabPage_TimeDisplay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_Save;
        private System.Windows.Forms.ToolStripMenuItem MenuFile_SaveAs;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage TabPage_Sites;
        private System.Windows.Forms.TabPage TabPage_Notifications;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

