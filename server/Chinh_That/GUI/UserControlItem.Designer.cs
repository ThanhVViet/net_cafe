namespace Chinh_That
{
    partial class UserControlItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlItem));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbID = new System.Windows.Forms.Label();
            this.but_delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lab_type = new System.Windows.Forms.Label();
            this.lab_time = new System.Windows.Forms.Label();
            this.lab_Content = new System.Windows.Forms.Label();
            this.lab_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(835, 242);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(292, -1);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(44, 16);
            this.lbID.TabIndex = 12;
            this.lbID.Text = "label1";
            this.lbID.Visible = false;
            // 
            // but_delete
            // 
            this.but_delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("but_delete.BackgroundImage")));
            this.but_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_delete.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.but_delete.Location = new System.Drawing.Point(728, 9);
            this.but_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_delete.Name = "but_delete";
            this.but_delete.Size = new System.Drawing.Size(88, 28);
            this.but_delete.TabIndex = 11;
            this.but_delete.Text = "DELETE";
            this.but_delete.UseVisualStyleBackColor = true;
            this.but_delete.Click += new System.EventHandler(this.but_delete_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lab_type);
            this.panel1.Controls.Add(this.lab_time);
            this.panel1.Controls.Add(this.lab_Content);
            this.panel1.Controls.Add(this.lab_title);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(257, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 171);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(568, 171);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // lab_type
            // 
            this.lab_type.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_type.ForeColor = System.Drawing.Color.Blue;
            this.lab_type.Location = new System.Drawing.Point(6, 15);
            this.lab_type.Name = "lab_type";
            this.lab_type.Size = new System.Drawing.Size(184, 21);
            this.lab_type.TabIndex = 14;
            this.lab_type.Text = "type";
            // 
            // lab_time
            // 
            this.lab_time.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lab_time.Location = new System.Drawing.Point(439, 15);
            this.lab_time.Name = "lab_time";
            this.lab_time.Size = new System.Drawing.Size(120, 21);
            this.lab_time.TabIndex = 12;
            this.lab_time.Text = "time";
            // 
            // lab_Content
            // 
            this.lab_Content.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Content.ForeColor = System.Drawing.Color.Yellow;
            this.lab_Content.Location = new System.Drawing.Point(6, 90);
            this.lab_Content.Name = "lab_Content";
            this.lab_Content.Size = new System.Drawing.Size(560, 72);
            this.lab_Content.TabIndex = 10;
            this.lab_Content.Text = "Content";
            // 
            // lab_title
            // 
            this.lab_title.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_title.ForeColor = System.Drawing.Color.Firebrick;
            this.lab_title.Location = new System.Drawing.Point(9, 48);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(550, 28);
            this.lab_title.TabIndex = 11;
            this.lab_title.Text = "title\r\n";
            // 
            // UserControlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.but_delete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Name = "UserControlItem";
            this.Size = new System.Drawing.Size(835, 242);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button but_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lab_type;
        public System.Windows.Forms.Label lab_time;
        public System.Windows.Forms.Label lab_Content;
        public System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
