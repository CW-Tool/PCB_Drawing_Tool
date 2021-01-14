using System.Drawing;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidebarContainer = new System.Windows.Forms.Panel();
            this.btnMoveObjects = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.picSidebar = new System.Windows.Forms.PictureBox();
            this.txtCanvasZoom = new System.Windows.Forms.TextBox();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.lblLinewidth = new System.Windows.Forms.Label();
            this.cboLinewidth = new System.Windows.Forms.ComboBox();
            this.sidebarLeft = new System.Windows.Forms.Panel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemDefLoc = new System.Windows.Forms.ToolStripTextBox();
            this.mItemSetDefLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mItemAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.mItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerMenu = new System.Windows.Forms.MenuStrip();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.mainDrawingCanvas = new System.Windows.Forms.PictureBox();
            this.sidebarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSidebar)).BeginInit();
            this.headerMenu.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawingCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.sidebarContainer.Controls.Add(this.btnMoveObjects);
            this.sidebarContainer.Controls.Add(this.btnDelete);
            this.sidebarContainer.Controls.Add(this.picSidebar);
            this.sidebarContainer.Controls.Add(this.txtCanvasZoom);
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
            this.sidebarContainer.TabIndex = 2;
            // 
            // btnMoveObjects
            // 
            this.btnMoveObjects.Location = new System.Drawing.Point(13, 191);
            this.btnMoveObjects.Name = "btnMoveObjects";
            this.btnMoveObjects.Size = new System.Drawing.Size(150, 29);
            this.btnMoveObjects.TabIndex = 11;
            this.btnMoveObjects.Text = "Move All Objects";
            this.btnMoveObjects.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(13, 156);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 29);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // picSidebar
            // 
            this.picSidebar.BackColor = System.Drawing.Color.Transparent;
            this.picSidebar.Image = global::PCB_Drawing_Tool.Properties.Resources.circuit_board;
            this.picSidebar.Location = new System.Drawing.Point(10, 439);
            this.picSidebar.Name = "picSidebar";
            this.picSidebar.Size = new System.Drawing.Size(166, 227);
            this.picSidebar.TabIndex = 9;
            this.picSidebar.TabStop = false;
            // 
            // txtCanvasZoom
            // 
            this.txtCanvasZoom.Location = new System.Drawing.Point(13, 249);
            this.txtCanvasZoom.Name = "txtCanvasZoom";
            this.txtCanvasZoom.Size = new System.Drawing.Size(150, 20);
            this.txtCanvasZoom.TabIndex = 2;
            this.txtCanvasZoom.Text = "100 %";
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.lblObjectType.Location = new System.Drawing.Point(53, 49);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(65, 13);
            this.lblObjectType.TabIndex = 5;
            this.lblObjectType.Text = "Object Type";
            // 
            // cboObjectType
            // 
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.FormattingEnabled = true;
            this.cboObjectType.Items.AddRange(new object[] {
            "Line",
            "Circle (empty)",
            "Circle (filled)",
            "Transistor"});
            this.cboObjectType.Location = new System.Drawing.Point(13, 65);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(150, 21);
            this.cboObjectType.TabIndex = 0;
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(13, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(150, 29);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnZoomIn.Location = new System.Drawing.Point(13, 309);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(150, 29);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(13, 276);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(150, 29);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // lblLinewidth
            // 
            this.lblLinewidth.AutoSize = true;
            this.lblLinewidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.lblLinewidth.Location = new System.Drawing.Point(62, 92);
            this.lblLinewidth.Name = "lblLinewidth";
            this.lblLinewidth.Size = new System.Drawing.Size(52, 13);
            this.lblLinewidth.TabIndex = 6;
            this.lblLinewidth.Text = "Linewidth";
            // 
            // cboLinewidth
            // 
            this.cboLinewidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinewidth.FormattingEnabled = true;
            this.cboLinewidth.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40"});
            this.cboLinewidth.Location = new System.Drawing.Point(13, 108);
            this.cboLinewidth.Name = "cboLinewidth";
            this.cboLinewidth.Size = new System.Drawing.Size(150, 21);
            this.cboLinewidth.TabIndex = 1;
            // 
            // sidebarLeft
            // 
            this.sidebarLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.sidebarLeft.Location = new System.Drawing.Point(0, 16);
            this.sidebarLeft.Name = "sidebarLeft";
            this.sidebarLeft.Size = new System.Drawing.Size(5, 682);
            this.sidebarLeft.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemDefLoc,
            this.mItemSetDefLoc,
            this.gToolStripMenuItem,
            this.mItemAutoSave,
            this.hToolStripMenuItem,
            this.mItemSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(122, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mItemDefLoc
            // 
            this.mItemDefLoc.AutoSize = false;
            this.mItemDefLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mItemDefLoc.Name = "mItemDefLoc";
            this.mItemDefLoc.ReadOnly = true;
            this.mItemDefLoc.Size = new System.Drawing.Size(600, 23);
            // 
            // mItemSetDefLoc
            // 
            this.mItemSetDefLoc.Name = "mItemSetDefLoc";
            this.mItemSetDefLoc.Size = new System.Drawing.Size(660, 22);
            this.mItemSetDefLoc.Text = "Set Default Location";
            this.mItemSetDefLoc.Click += new System.EventHandler(this.mItemSetDefLoc_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(657, 6);
            // 
            // mItemAutoSave
            // 
            this.mItemAutoSave.Name = "mItemAutoSave";
            this.mItemAutoSave.Size = new System.Drawing.Size(660, 22);
            this.mItemAutoSave.Text = "Enable autosave";
            this.mItemAutoSave.Click += new System.EventHandler(this.enableAutosaveToolStripMenuItem_Click);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(657, 6);
            // 
            // mItemSave
            // 
            this.mItemSave.Name = "mItemSave";
            this.mItemSave.Size = new System.Drawing.Size(660, 22);
            this.mItemSave.Text = "Save";
            this.mItemSave.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToPNGToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // convertToPNGToolStripMenuItem
            // 
            this.convertToPNGToolStripMenuItem.Name = "convertToPNGToolStripMenuItem";
            this.convertToPNGToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.convertToPNGToolStripMenuItem.Text = "Convert to PNG";
            // 
            // headerMenu
            // 
            this.headerMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.headerMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.headerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.headerMenu.Location = new System.Drawing.Point(0, 0);
            this.headerMenu.Name = "headerMenu";
            this.headerMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.headerMenu.Size = new System.Drawing.Size(823, 27);
            this.headerMenu.TabIndex = 4;
            this.headerMenu.Text = "menuStrip2";
            // 
            // mainContainer
            // 
            this.mainContainer.AutoScroll = true;
            this.mainContainer.BackColor = System.Drawing.Color.Transparent;
            this.mainContainer.Controls.Add(this.mainDrawingCanvas);
            this.mainContainer.Location = new System.Drawing.Point(12, 26);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(596, 666);
            this.mainContainer.TabIndex = 6;
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
            this.mainDrawingCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.mainDrawingCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
            this.mainDrawingCanvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheelEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 733);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.headerMenu);
            this.Controls.Add(this.sidebarLeft);
            this.Controls.Add(this.sidebarContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "PCB Drawing Tool";
            this.Load += new System.EventHandler(this.SetAutosaveStatus);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.Resize += new System.EventHandler(this.ResizeCompontensToForm);
            this.sidebarContainer.ResumeLayout(false);
            this.sidebarContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSidebar)).EndInit();
            this.headerMenu.ResumeLayout(false);
            this.headerMenu.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDrawingCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel sidebarContainer;
        private System.Windows.Forms.Label lblLinewidth;
        private System.Windows.Forms.ComboBox cboLinewidth;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.ComboBox cboObjectType;
        private System.Windows.Forms.TextBox txtCanvasZoom;
        private System.Windows.Forms.Panel sidebarLeft;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox mItemDefLoc;
        private System.Windows.Forms.ToolStripMenuItem mItemSetDefLoc;
        private System.Windows.Forms.ToolStripSeparator gToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemAutoSave;
        private System.Windows.Forms.ToolStripSeparator hToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemSave;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToPNGToolStripMenuItem;
        private System.Windows.Forms.MenuStrip headerMenu;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.PictureBox mainDrawingCanvas;
        private System.Windows.Forms.PictureBox picSidebar;
        private System.Windows.Forms.Button btnMoveObjects;
        private System.Windows.Forms.Button btnDelete;
    }
}

