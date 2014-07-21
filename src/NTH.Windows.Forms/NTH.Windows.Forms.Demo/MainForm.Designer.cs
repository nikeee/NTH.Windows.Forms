﻿namespace NTH.Windows.Forms.Demo
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.placeholderTextbox1 = new NTH.Windows.Forms.PlaceholderTextbox();
            this.verticalProgressBar1 = new NTH.Windows.Forms.VerticalProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Some Placeholder Textbox:";
            // 
            // placeholderTextbox1
            // 
            this.placeholderTextbox1.Location = new System.Drawing.Point(32, 67);
            this.placeholderTextbox1.Name = "placeholderTextbox1";
            this.placeholderTextbox1.Placeholder = "this is a placeholder";
            this.placeholderTextbox1.Size = new System.Drawing.Size(211, 23);
            this.placeholderTextbox1.TabIndex = 1;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.Location = new System.Drawing.Point(288, 12);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(31, 277);
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 30;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 301);
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.placeholderTextbox1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "NTH Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private PlaceholderTextbox placeholderTextbox1;
        private VerticalProgressBar verticalProgressBar1;

    }
}
