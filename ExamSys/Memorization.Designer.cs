﻿namespace ExamSys
{
    partial class Memorization
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Memorization));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.web = new System.Windows.Forms.WebBrowser();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.web);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1016, 723);
            this.panel.TabIndex = 0;
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.Location = new System.Drawing.Point(0, 0);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.ScrollBarsEnabled = false;
            this.web.Size = new System.Drawing.Size(1016, 723);
            this.web.TabIndex = 1;
            this.web.WebBrowserShortcutsEnabled = false;
            // 
            // Memorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 723);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Memorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.WebBrowser web;
    }
}