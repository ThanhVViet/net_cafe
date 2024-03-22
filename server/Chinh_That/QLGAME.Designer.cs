namespace Chinh_That
{
    partial class QLGAME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLGAME));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.but_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(95, 51);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(610, 348);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // but_add
            // 
            this.but_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("but_add.BackgroundImage")));
            this.but_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_add.ForeColor = System.Drawing.Color.DarkMagenta;
            this.but_add.Location = new System.Drawing.Point(649, 410);
            this.but_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.but_add.Name = "but_add";
            this.but_add.Size = new System.Drawing.Size(91, 29);
            this.but_add.TabIndex = 5;
            this.but_add.Text = "ADD";
            this.but_add.UseVisualStyleBackColor = true;
            // 
            // QLGAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Chinh_That.Properties.Resources._360_F_471002062_tCBbTqeeMhHgMfCW86mQhdgpETooy3ID2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.but_add);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "QLGAME";
            this.Text = "QLGAME";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button but_add;
    }
}