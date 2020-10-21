namespace PCB_Drawing_Tool
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
            this.btnPaint = new System.Windows.Forms.Button();
            this.mainDrawBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.lblLinewidth = new System.Windows.Forms.Label();
            this.cboLinewidth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(13, 83);
            this.btnPaint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(125, 36);
            this.btnPaint.TabIndex = 4;
            this.btnPaint.Text = "Paint";
            this.btnPaint.UseVisualStyleBackColor = true;
            // 
            // mainDrawBox
            // 
            this.mainDrawBox.BackColor = System.Drawing.Color.Transparent;
            this.mainDrawBox.Location = new System.Drawing.Point(16, 15);
            this.mainDrawBox.Margin = new System.Windows.Forms.Padding(4);
            this.mainDrawBox.Name = "mainDrawBox";
            this.mainDrawBox.Size = new System.Drawing.Size(718, 837);
            this.mainDrawBox.TabIndex = 7;
            this.mainDrawBox.TabStop = false;
            this.mainDrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseDown);
            this.mainDrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnZoomIn);
            this.panel1.Controls.Add(this.btnZoomOut);
            this.panel1.Controls.Add(this.lblLinewidth);
            this.panel1.Controls.Add(this.cboLinewidth);
            this.panel1.Controls.Add(this.btnPaint);
            this.panel1.Location = new System.Drawing.Point(871, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 837);
            this.panel1.TabIndex = 8;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(13, 291);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(125, 36);
            this.btnZoomIn.TabIndex = 11;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(13, 249);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(125, 36);
            this.btnZoomOut.TabIndex = 10;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // lblLinewidth
            // 
            this.lblLinewidth.AutoSize = true;
            this.lblLinewidth.Location = new System.Drawing.Point(44, 30);
            this.lblLinewidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinewidth.Name = "lblLinewidth";
            this.lblLinewidth.Size = new System.Drawing.Size(67, 17);
            this.lblLinewidth.TabIndex = 9;
            this.lblLinewidth.Text = "Linewidth";
            // 
            // cboLinewidth
            // 
            this.cboLinewidth.FormattingEnabled = true;
            this.cboLinewidth.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35"});
            this.cboLinewidth.Location = new System.Drawing.Point(12, 51);
            this.cboLinewidth.Margin = new System.Windows.Forms.Padding(4);
            this.cboLinewidth.Name = "cboLinewidth";
            this.cboLinewidth.Size = new System.Drawing.Size(125, 24);
            this.cboLinewidth.TabIndex = 9;
            this.cboLinewidth.Text = "10";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPaint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1097, 902);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainDrawBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ResizeCompontensToForm);
            this.Resize += new System.EventHandler(this.ResizeCompontensToForm);
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.PictureBox mainDrawBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLinewidth;
        private System.Windows.Forms.ComboBox cboLinewidth;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
    }
}

