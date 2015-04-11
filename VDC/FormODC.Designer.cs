namespace VDC
{
    partial class FormODC
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TrackTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.previousFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoominCtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomoutCtrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton22 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previousFrameToolStripMenuItem,
            this.nextFrameToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem1});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator1,
            this.moveToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoominCtrlToolStripMenuItem,
            this.zoomoutCtrlToolStripMenuItem,
            this.centerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImage = global::VDC.Properties.Resources.pixel;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton16,
            this.toolStripButton19,
            this.toolStripButton20,
            this.toolStripButton22,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(721, 379);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(64, 162);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // previousFrameToolStripMenuItem
            // 
            this.previousFrameToolStripMenuItem.Image = global::VDC.Properties.Resources.up;
            this.previousFrameToolStripMenuItem.Name = "previousFrameToolStripMenuItem";
            this.previousFrameToolStripMenuItem.ShowShortcutKeys = false;
            this.previousFrameToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.previousFrameToolStripMenuItem.Text = "&Previous frame        Up";
            this.previousFrameToolStripMenuItem.Click += new System.EventHandler(this.previousFrameToolStripMenuItem_Click);
            // 
            // nextFrameToolStripMenuItem
            // 
            this.nextFrameToolStripMenuItem.Image = global::VDC.Properties.Resources.down;
            this.nextFrameToolStripMenuItem.Name = "nextFrameToolStripMenuItem";
            this.nextFrameToolStripMenuItem.ShowShortcutKeys = false;
            this.nextFrameToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nextFrameToolStripMenuItem.Text = "&Next frame          Down";
            this.nextFrameToolStripMenuItem.Click += new System.EventHandler(this.nextFrameToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Image = global::VDC.Properties.Resources.exit;
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::VDC.Properties.Resources.undo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::VDC.Properties.Resources.redo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.leftToolStripMenuItem});
            this.moveToolStripMenuItem.Image = global::VDC.Properties.Resources.move;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.moveToolStripMenuItem.Text = "&Move";
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.upToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.upToolStripMenuItem.Text = "&Up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.downToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.downToolStripMenuItem.Text = "&Down";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.rightToolStripMenuItem.Text = "&Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.leftToolStripMenuItem.Text = "&Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
            // 
            // zoominCtrlToolStripMenuItem
            // 
            this.zoominCtrlToolStripMenuItem.Image = global::VDC.Properties.Resources.zoomin;
            this.zoominCtrlToolStripMenuItem.Name = "zoominCtrlToolStripMenuItem";
            this.zoominCtrlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoominCtrlToolStripMenuItem.ShowShortcutKeys = false;
            this.zoominCtrlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoominCtrlToolStripMenuItem.Text = "Zoom &in           Ctrl++";
            this.zoominCtrlToolStripMenuItem.Click += new System.EventHandler(this.zoominCtrlToolStripMenuItem_Click);
            // 
            // zoomoutCtrlToolStripMenuItem
            // 
            this.zoomoutCtrlToolStripMenuItem.Image = global::VDC.Properties.Resources.zoomout;
            this.zoomoutCtrlToolStripMenuItem.Name = "zoomoutCtrlToolStripMenuItem";
            this.zoomoutCtrlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.zoomoutCtrlToolStripMenuItem.ShowShortcutKeys = false;
            this.zoomoutCtrlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomoutCtrlToolStripMenuItem.Text = "Zoom &out         Ctrl+-";
            this.zoomoutCtrlToolStripMenuItem.Click += new System.EventHandler(this.zoomoutCtrlToolStripMenuItem_Click);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Image = global::VDC.Properties.Resources.center;
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.centerToolStripMenuItem.Text = "Cente&r";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.CheckOnClick = true;
            this.toolStripButton16.Image = global::VDC.Properties.Resources.itr;
            this.toolStripButton16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton16.Text = "itr:1";
            this.toolStripButton16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.CheckOnClick = true;
            this.toolStripButton19.Image = global::VDC.Properties.Resources.unfold;
            this.toolStripButton19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton19.Text = "itr";
            this.toolStripButton19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton20
            // 
            this.toolStripButton20.CheckOnClick = true;
            this.toolStripButton20.Image = global::VDC.Properties.Resources.bdy;
            this.toolStripButton20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton20.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton20.Name = "toolStripButton20";
            this.toolStripButton20.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton20.Text = "bdy:1";
            this.toolStripButton20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton22
            // 
            this.toolStripButton22.CheckOnClick = true;
            this.toolStripButton22.Image = global::VDC.Properties.Resources.unfold;
            this.toolStripButton22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton22.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton22.Name = "toolStripButton22";
            this.toolStripButton22.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton22.Text = "bdy";
            this.toolStripButton22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.CheckOnClick = true;
            this.toolStripButton6.Image = global::VDC.Properties.Resources.bpoint;
            this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton6.Text = "bpoint";
            this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.CheckOnClick = true;
            this.toolStripButton5.Image = global::VDC.Properties.Resources.wpoint;
            this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton5.Text = "wpoint";
            this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.CheckOnClick = true;
            this.toolStripButton4.Image = global::VDC.Properties.Resources.opoint;
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton4.Text = "opoint";
            this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton3.CheckOnClick = true;
            this.toolStripButton3.Image = global::VDC.Properties.Resources.cpoint;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(63, 20);
            this.toolStripButton3.Text = "cpoint";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormODC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(794, 550);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormODC";
            this.ShowInTaskbar = false;
            this.Text = "select a frame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormODC_FormClosing);
            this.Load += new System.EventHandler(this.FormODC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormODC_Paint_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormODC_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormODC_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormODC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormODC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormODC_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip TrackTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoominCtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomoutCtrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripButton toolStripButton19;
        private System.Windows.Forms.ToolStripButton toolStripButton20;
        private System.Windows.Forms.ToolStripButton toolStripButton22;




    }
}