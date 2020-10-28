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
            this.mainDrawCanvas = new System.Windows.Forms.PictureBox();
            this.sidebarContainer = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.lblLinewidth = new System.Windows.Forms.Label();
            this.cboLinewidth = new System.Windows.Forms.ComboBox();
            this.mainContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawCanvas)).BeginInit();
            this.sidebarContainer.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDrawCanvas
            // 
            this.mainDrawCanvas.BackColor = System.Drawing.Color.Transparent;
            this.mainDrawCanvas.Location = new System.Drawing.Point(7, 9);
            this.mainDrawCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.mainDrawCanvas.Name = "mainDrawCanvas";
            this.mainDrawCanvas.Size = new System.Drawing.Size(100, 100);
            this.mainDrawCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainDrawCanvas.TabIndex = 9;
            this.mainDrawCanvas.TabStop = false;
            this.mainDrawCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseDown);
            this.mainDrawCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseUp);
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.LightGray;
            this.sidebarContainer.Controls.Add(this.btnSave);
            this.sidebarContainer.Controls.Add(this.lblObjectType);
            this.sidebarContainer.Controls.Add(this.cboObjectType);
            this.sidebarContainer.Controls.Add(this.btnUndo);
            this.sidebarContainer.Controls.Add(this.btnZoomIn);
            this.sidebarContainer.Controls.Add(this.btnZoomOut);
            this.sidebarContainer.Controls.Add(this.lblLinewidth);
            this.sidebarContainer.Controls.Add(this.cboLinewidth);
            this.sidebarContainer.Location = new System.Drawing.Point(871, 15);
            this.sidebarContainer.Margin = new System.Windows.Forms.Padding(4);
            this.sidebarContainer.Name = "sidebarContainer";
            this.sidebarContainer.Size = new System.Drawing.Size(213, 837);
            this.sidebarContainer.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 30);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(33, 87);
            this.lblObjectType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(85, 17);
            this.lblObjectType.TabIndex = 13;
            this.lblObjectType.Text = "Object Type";
            // 
            // cboObjectType
            // 
            this.cboObjectType.FormattingEnabled = true;
            this.cboObjectType.Items.AddRange(new object[] {
            "Line",
            "Circle (empty)",
            "Circle (filled)",
            "Dot",
            "Transistor"});
            this.cboObjectType.Location = new System.Drawing.Point(13, 107);
            this.cboObjectType.Margin = new System.Windows.Forms.Padding(4);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(125, 24);
            this.cboObjectType.TabIndex = 1;
            this.cboObjectType.Text = "Line";
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(13, 299);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(125, 36);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(13, 240);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(125, 36);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(13, 199);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(125, 36);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // lblLinewidth
            // 
            this.lblLinewidth.AutoSize = true;
            this.lblLinewidth.Location = new System.Drawing.Point(44, 135);
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
            this.cboLinewidth.Location = new System.Drawing.Point(12, 155);
            this.cboLinewidth.Margin = new System.Windows.Forms.Padding(4);
            this.cboLinewidth.Name = "cboLinewidth";
            this.cboLinewidth.Size = new System.Drawing.Size(125, 24);
            this.cboLinewidth.TabIndex = 2;
            this.cboLinewidth.Text = "10";
            // 
            // mainContainer
            // 
            this.mainContainer.AutoScroll = true;
            this.mainContainer.BackColor = System.Drawing.Color.Transparent;
            this.mainContainer.Controls.Add(this.mainDrawCanvas);
            this.mainContainer.Location = new System.Drawing.Point(9, 6);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(828, 846);
            this.mainContainer.TabIndex = 8;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1097, 902);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.sidebarContainer);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "PCB Drawing Tool";
            this.Load += new System.EventHandler(this.ResizeCompontensToForm);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.ResizeCompontensToForm);
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawCanvas)).EndInit();
            this.sidebarContainer.ResumeLayout(false);
            this.sidebarContainer.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox mainDrawCanvas;
        private System.Windows.Forms.Panel sidebarContainer;
        private System.Windows.Forms.Label lblLinewidth;
        private System.Windows.Forms.ComboBox cboLinewidth;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.ComboBox cboObjectType;
        private System.Windows.Forms.Button btnSave;
    }
}

