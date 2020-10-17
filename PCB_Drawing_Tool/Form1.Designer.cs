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
            this.txtY2 = new System.Windows.Forms.MaskedTextBox();
            this.txtX2 = new System.Windows.Forms.MaskedTextBox();
            this.txtX1 = new System.Windows.Forms.MaskedTextBox();
            this.txtY1 = new System.Windows.Forms.MaskedTextBox();
            this.lblX1 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.mainDrawBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLinewidth = new System.Windows.Forms.Label();
            this.cboLinewidth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(470, 30);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(92, 29);
            this.btnPaint.TabIndex = 4;
            this.btnPaint.Text = "Paint";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(344, 52);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(101, 20);
            this.txtY2.TabIndex = 3;
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(216, 52);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(101, 20);
            this.txtX2.TabIndex = 2;
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(216, 15);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(101, 20);
            this.txtX1.TabIndex = 0;
            this.txtX1.ValidatingType = typeof(int);
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(344, 15);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(101, 20);
            this.txtY1.TabIndex = 1;
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(192, 18);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(18, 13);
            this.lblX1.TabIndex = 1;
            this.lblX1.Text = "x1";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(192, 55);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(18, 13);
            this.lblX2.TabIndex = 3;
            this.lblX2.Text = "x2";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(323, 18);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(18, 13);
            this.lblY1.TabIndex = 4;
            this.lblY1.Text = "y1";
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(323, 55);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(18, 13);
            this.lblY2.TabIndex = 6;
            this.lblY2.Text = "y2";
            // 
            // mainDrawBox
            // 
            this.mainDrawBox.BackColor = System.Drawing.Color.Transparent;
            this.mainDrawBox.Location = new System.Drawing.Point(12, 12);
            this.mainDrawBox.Name = "mainDrawBox";
            this.mainDrawBox.Size = new System.Drawing.Size(799, 621);
            this.mainDrawBox.TabIndex = 7;
            this.mainDrawBox.TabStop = false;
            this.mainDrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseDown);
            this.mainDrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.lblLinewidth);
            this.panel1.Controls.Add(this.cboLinewidth);
            this.panel1.Controls.Add(this.lblY2);
            this.panel1.Controls.Add(this.lblY1);
            this.panel1.Controls.Add(this.lblX2);
            this.panel1.Controls.Add(this.lblX1);
            this.panel1.Controls.Add(this.txtY1);
            this.panel1.Controls.Add(this.txtX1);
            this.panel1.Controls.Add(this.txtX2);
            this.panel1.Controls.Add(this.txtY2);
            this.panel1.Controls.Add(this.btnPaint);
            this.panel1.Location = new System.Drawing.Point(12, 639);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 83);
            this.panel1.TabIndex = 8;
            // 
            // lblLinewidth
            // 
            this.lblLinewidth.AutoSize = true;
            this.lblLinewidth.Location = new System.Drawing.Point(67, 14);
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
            "20",
            "25",
            "30",
            "35"});
            this.cboLinewidth.Location = new System.Drawing.Point(70, 30);
            this.cboLinewidth.Name = "cboLinewidth";
            this.cboLinewidth.Size = new System.Drawing.Size(49, 21);
            this.cboLinewidth.TabIndex = 9;
            this.cboLinewidth.Text = "10";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPaint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainDrawBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.MaskedTextBox txtY2;
        private System.Windows.Forms.MaskedTextBox txtX2;
        private System.Windows.Forms.MaskedTextBox txtX1;
        private System.Windows.Forms.MaskedTextBox txtY1;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.PictureBox mainDrawBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLinewidth;
        private System.Windows.Forms.ComboBox cboLinewidth;
    }
}

