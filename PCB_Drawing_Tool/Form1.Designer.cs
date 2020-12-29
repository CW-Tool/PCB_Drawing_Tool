﻿namespace PCB_Drawing_Tool
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
            this.mainDrawingCanvas = new System.Windows.Forms.PictureBox();
            this.sidebarContainer = new System.Windows.Forms.Panel();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.lblLinewidth = new System.Windows.Forms.Label();
            this.cboLinewidth = new System.Windows.Forms.ComboBox();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemDefLoc = new System.Windows.Forms.ToolStripTextBox();
            this.mItemSetDefLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mItemAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mItemSave = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawingCanvas)).BeginInit();
            this.sidebarContainer.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDrawingCanvas
            // 
            this.mainDrawingCanvas.BackColor = System.Drawing.Color.Transparent;
            this.mainDrawingCanvas.Location = new System.Drawing.Point(5, 7);
            this.mainDrawingCanvas.Name = "mainDrawingCanvas";
            this.mainDrawingCanvas.Size = new System.Drawing.Size(100, 100);
            this.mainDrawingCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainDrawingCanvas.TabIndex = 9;
            this.mainDrawingCanvas.TabStop = false;
            this.mainDrawingCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseDown);
            this.mainDrawingCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainDrawBox_MouseUp);
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.LightGray;
            this.sidebarContainer.Controls.Add(this.lblObjectType);
            this.sidebarContainer.Controls.Add(this.cboObjectType);
            this.sidebarContainer.Controls.Add(this.btnUndo);
            this.sidebarContainer.Controls.Add(this.btnZoomIn);
            this.sidebarContainer.Controls.Add(this.btnZoomOut);
            this.sidebarContainer.Controls.Add(this.lblLinewidth);
            this.sidebarContainer.Controls.Add(this.cboLinewidth);
            this.sidebarContainer.Location = new System.Drawing.Point(634, 26);
            this.sidebarContainer.Name = "sidebarContainer";
            this.sidebarContainer.Size = new System.Drawing.Size(179, 666);
            this.sidebarContainer.TabIndex = 0;
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(34, 14);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(65, 13);
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
            this.cboObjectType.Location = new System.Drawing.Point(10, 30);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(116, 21);
            this.cboObjectType.TabIndex = 1;
            this.cboObjectType.Text = "Line";
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(10, 186);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(115, 29);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(10, 138);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(115, 29);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(10, 105);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(115, 29);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // lblLinewidth
            // 
            this.lblLinewidth.AutoSize = true;
            this.lblLinewidth.Location = new System.Drawing.Point(43, 53);
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
            this.cboLinewidth.Location = new System.Drawing.Point(9, 69);
            this.cboLinewidth.Name = "cboLinewidth";
            this.cboLinewidth.Size = new System.Drawing.Size(116, 21);
            this.cboLinewidth.TabIndex = 2;
            this.cboLinewidth.Text = "10";
            // 
            // mainContainer
            // 
            this.mainContainer.AutoScroll = true;
            this.mainContainer.BackColor = System.Drawing.Color.Transparent;
            this.mainContainer.Controls.Add(this.mainDrawingCanvas);
            this.mainContainer.Location = new System.Drawing.Point(7, 26);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(621, 666);
            this.mainContainer.TabIndex = 8;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(823, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemDefLoc,
            this.mItemSetDefLoc,
            this.gToolStripMenuItem,
            this.mItemAutoSave,
            this.hToolStripMenuItem,
            this.mItemSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mItemDefLoc
            // 
            this.mItemDefLoc.AutoSize = false;
            this.mItemDefLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mItemDefLoc.Name = "mItemDefLoc";
            this.mItemDefLoc.ReadOnly = true;
            this.mItemDefLoc.Size = new System.Drawing.Size(600, 23);
            this.mItemDefLoc.Text = "Not Defined Jet";
            // 
            // mItemSetDefLoc
            // 
            this.mItemSetDefLoc.Name = "mItemSetDefLoc";
            this.mItemSetDefLoc.Size = new System.Drawing.Size(460, 22);
            this.mItemSetDefLoc.Text = "Set Default Location";
            this.mItemSetDefLoc.Click += new System.EventHandler(this.mItemSetDefLoc_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(281, 6);
            // 
            // mItemAutoSave
            // 
            this.mItemAutoSave.Name = "mItemAutoSave";
            this.mItemAutoSave.Size = new System.Drawing.Size(284, 22);
            this.mItemAutoSave.Text = "Enable autosave";
            this.mItemAutoSave.Click += new System.EventHandler(this.enableAutosaveToolStripMenuItem_Click);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(281, 6);
            // 
            // mItemSave
            // 
            this.mItemSave.Name = "mItemSave";
            this.mItemSave.Size = new System.Drawing.Size(284, 22);
            this.mItemSave.Text = "Save";
            this.mItemSave.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 733);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.sidebarContainer);
            this.Controls.Add(this.menuStrip2);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "PCB Drawing Tool";
            this.Load += new System.EventHandler(this.ResizeCompontensToForm);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.ResizeCompontensToForm);
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawingCanvas)).EndInit();
            this.sidebarContainer.ResumeLayout(false);
            this.sidebarContainer.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox mainDrawingCanvas;
        private System.Windows.Forms.Panel sidebarContainer;
        private System.Windows.Forms.Label lblLinewidth;
        private System.Windows.Forms.ComboBox cboLinewidth;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.ComboBox cboObjectType;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox mItemDefLoc;
        private System.Windows.Forms.ToolStripMenuItem mItemSetDefLoc;
        private System.Windows.Forms.ToolStripSeparator gToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemAutoSave;
        private System.Windows.Forms.ToolStripSeparator hToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemSave;
    }
}

