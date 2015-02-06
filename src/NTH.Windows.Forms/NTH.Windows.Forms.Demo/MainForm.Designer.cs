namespace NTH.Windows.Forms.Demo
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("P", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("N", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "nikeee",
            "Gemany"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "ProgTrade",
            "Germany"}, -1);
            this.label1 = new System.Windows.Forms.Label();
            this.placeholderTextbox1 = new NTH.Windows.Forms.PlaceholderTextbox();
            this.verticalProgressBar1 = new NTH.Windows.Forms.VerticalProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.nthLinkLabel1 = new NTH.Windows.Forms.NthLinkLabel();
            this.administrativeBanner1 = new NTH.Windows.Forms.AdministrativeBanner();
            this.nthListView1 = new NTH.Windows.Forms.NthListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.verticalProgressBar1.Location = new System.Drawing.Point(474, 166);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(31, 277);
            this.verticalProgressBar1.TabIndex = 2;
            this.verticalProgressBar1.Value = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "minimize and flash 3 times";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // nthLinkLabel1
            // 
            this.nthLinkLabel1.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.nthLinkLabel1.AutoSize = true;
            this.nthLinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nthLinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.nthLinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.nthLinkLabel1.Location = new System.Drawing.Point(29, 135);
            this.nthLinkLabel1.Name = "nthLinkLabel1";
            this.nthLinkLabel1.Size = new System.Drawing.Size(166, 15);
            this.nthLinkLabel1.TabIndex = 4;
            this.nthLinkLabel1.TabStop = true;
            this.nthLinkLabel1.Text = "Link label like the explorer one";
            // 
            // administrativeBanner1
            // 
            this.administrativeBanner1.Location = new System.Drawing.Point(218, 410);
            this.administrativeBanner1.Name = "administrativeBanner1";
            this.administrativeBanner1.Size = new System.Drawing.Size(250, 33);
            this.administrativeBanner1.TabIndex = 5;
            this.administrativeBanner1.Text = "administrativeBanner1";
            // 
            // nthListView1
            // 
            this.nthListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.nthListView1.FullRowSelect = true;
            listViewGroup3.Header = "P";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "N";
            listViewGroup4.Name = "listViewGroup2";
            this.nthListView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            listViewItem3.Group = listViewGroup4;
            listViewItem4.Group = listViewGroup3;
            this.nthListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.nthListView1.Location = new System.Drawing.Point(32, 166);
            this.nthListView1.Name = "nthListView1";
            this.nthListView1.Size = new System.Drawing.Size(423, 229);
            this.nthListView1.TabIndex = 6;
            this.nthListView1.UseCompatibleStateImageBehavior = false;
            this.nthListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User";
            this.columnHeader1.Width = 208;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            this.columnHeader2.Width = 209;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 465);
            this.Controls.Add(this.nthListView1);
            this.Controls.Add(this.administrativeBanner1);
            this.Controls.Add(this.nthLinkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.placeholderTextbox1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "NTH Demo";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private PlaceholderTextbox placeholderTextbox1;
        private VerticalProgressBar verticalProgressBar1;
        private System.Windows.Forms.Button button1;
        private NthLinkLabel nthLinkLabel1;
        private AdministrativeBanner administrativeBanner1;
        private NthListView nthListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

    }
}

