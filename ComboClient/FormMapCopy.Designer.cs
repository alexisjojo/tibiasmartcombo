namespace ComboClient
{
    partial class FormMapCopy
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
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.butZoomIn = new System.Windows.Forms.Button();
            this.butZoomOut = new System.Windows.Forms.Button();
            this.butReload = new System.Windows.Forms.Button();
            this.butUp = new System.Windows.Forms.Button();
            this.butDown = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // butZoomIn
            // 
            this.butZoomIn.Location = new System.Drawing.Point(12, 2);
            this.butZoomIn.Name = "butZoomIn";
            this.butZoomIn.Size = new System.Drawing.Size(30, 23);
            this.butZoomIn.TabIndex = 2;
            this.butZoomIn.Text = "+";
            this.butZoomIn.UseVisualStyleBackColor = true;
            this.butZoomIn.Click += new System.EventHandler(this.butZoomIn_Click);
            // 
            // butZoomOut
            // 
            this.butZoomOut.Location = new System.Drawing.Point(48, 2);
            this.butZoomOut.Name = "butZoomOut";
            this.butZoomOut.Size = new System.Drawing.Size(30, 23);
            this.butZoomOut.TabIndex = 3;
            this.butZoomOut.Text = "-";
            this.butZoomOut.UseVisualStyleBackColor = true;
            this.butZoomOut.Click += new System.EventHandler(this.butZoomOut_Click);
            // 
            // butReload
            // 
            this.butReload.Location = new System.Drawing.Point(197, 2);
            this.butReload.Name = "butReload";
            this.butReload.Size = new System.Drawing.Size(92, 23);
            this.butReload.TabIndex = 4;
            this.butReload.Text = "Reload";
            this.butReload.UseVisualStyleBackColor = true;
            this.butReload.Click += new System.EventHandler(this.butReload_Click);
            // 
            // butUp
            // 
            this.butUp.Location = new System.Drawing.Point(93, 2);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(48, 23);
            this.butUp.TabIndex = 5;
            this.butUp.Text = "Up";
            this.butUp.UseVisualStyleBackColor = true;
            this.butUp.Click += new System.EventHandler(this.butUp_Click);
            // 
            // butDown
            // 
            this.butDown.Location = new System.Drawing.Point(143, 2);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(48, 23);
            this.butDown.TabIndex = 6;
            this.butDown.Text = "Down";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butDown_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.pictureBox1.Location = new System.Drawing.Point(8, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 220);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FormMapCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 260);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.butDown);
            this.Controls.Add(this.butUp);
            this.Controls.Add(this.butReload);
            this.Controls.Add(this.butZoomOut);
            this.Controls.Add(this.butZoomIn);
            this.Name = "FormMapCopy";
            this.Text = "Minimap and radar";
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.FormMapCopy_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMapCopy_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button butZoomIn;
        private System.Windows.Forms.Button butZoomOut;
        private System.Windows.Forms.Button butReload;
        private System.Windows.Forms.Button butUp;
        private System.Windows.Forms.Button butDown;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}