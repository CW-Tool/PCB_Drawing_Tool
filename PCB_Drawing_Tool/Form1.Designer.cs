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
            this.sidebarContainer = new System.Windows.Forms.Panel();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.lblLinewidth = new System.Windows.Forms.Label();
            this.cboLinewidth = new System.Windows.Forms.ComboBox();
            this.mainContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawBox)).BeginInit();
            this.sidebarContainer.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(10, 67);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(94, 29);
            this.btnPaint.TabIndex = 4;
            this.btnPaint.Text = "Paint";
            this.btnPaint.UseVisualStyleBackColor = true;
            // 
            // mainDrawBox
            // 
            this.mainDrawBox.BackColor = System.Drawing.Color.Transparent;
            this.mainDrawBox.Location = new System.Drawing.Point(5, 7);
            this.mainDrawBox.Name = "mainDrawBox";
            this.mainDrawBox.Size = new System.Drawing.Size(100, 100);
            this.mainDrawBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainDrawBox.TabIndex = 9;
            this.mainDrawBox.TabStop = false;
            this.mainDrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseDown);
            this.mainDrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseUp);
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.LightGray;
            this.sidebarContainer.Controls.Add(this.btnZoomIn);
            this.sidebarContainer.Controls.Add(this.btnZoomOut);
            this.sidebarContainer.Controls.Add(this.lblLinewidth);
            this.sidebarContainer.Controls.Add(this.cboLinewidth);
            this.sidebarContainer.Controls.Add(this.btnPaint);
            this.sidebarContainer.Location = new System.Drawing.Point(653, 12);
            this.sidebarContainer.Name = "sidebarContainer";
            this.sidebarContainer.Size = new System.Drawing.Size(160, 680);
            this.sidebarContainer.TabIndex = 7;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(10, 236);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(94, 29);
            this.btnZoomIn.TabIndex = 11;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(10, 202);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(94, 29);
            this.btnZoomOut.TabIndex = 10;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // lblLinewidth
            // 
            this.lblLinewidth.AutoSize = true;
            this.lblLinewidth.Location = new System.Drawing.Point(33, 24);
            this.lblLinewidth.Name = "lblLinewidth";
            this.lblLinewidth.Size = new System.Drawing.Size(52, 13);
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
            this.cboLinewidth.Location = new System.Drawing.Point(9, 41);
            this.cboLinewidth.Name = "cboLinewidth";
            this.cboLinewidth.Size = new System.Drawing.Size(95, 21);
            this.cboLinewidth.TabIndex = 9;
            this.cboLinewidth.Text = "10";
            // 
            // mainContainer
            // 
            this.mainContainer.AutoScroll = true;
            this.mainContainer.BackColor = System.Drawing.Color.Transparent;
            this.mainContainer.Controls.Add(this.mainDrawBox);
            this.mainContainer.Location = new System.Drawing.Point(7, 5);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(621, 687);
            this.mainContainer.TabIndex = 8;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPaint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 733);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.sidebarContainer);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ResizeCompontensToForm);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.ResizeCompontensToForm);
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawBox)).EndInit();
            this.sidebarContainer.ResumeLayout(false);
            this.sidebarContainer.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.PictureBox mainDrawBox;
        private System.Windows.Forms.Panel sidebarContainer;
        private System.Windows.Forms.Label lblLinewidth;
        private System.Windows.Forms.ComboBox cboLinewidth;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Panel mainContainer;
    }
}

