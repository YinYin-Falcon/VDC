﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace VDC
{
    public partial class FormODC : Form
    {

        public FormVDC vdc;
        public int frame;
        const int HitTestDelta = 3;
        private bool space = false;
        private bool ctrl = false;
        private bool shift = false;
        private string dragtype = "";
        private string TipText = string.Format("{0}, {1}", 0, 0);
        bool dragStartPoint = false;
        bool dragEndPoint = false;
        // The mouse position when mouse down
        int oldMouseX;
        int oldMouseY;
        // The line position when mouse down.
        Point oldStartPoint;
        Point oldEndPoint;
        private Bitmap s = Properties.Resources.s;
        int zoom = 3;
        int offsetx = 0;
        int offsety = 0;
        int dashOffset = 0;

        public FormODC()
        {
            if (global.objectfile.frames.Count > 0) offsety = (zoom - 1) * global.objectfile.frames[global.framenumber].centery / 2;
            InitializeComponent();
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormODC_MouseWheel);
        }

        private void FormODC_Load(object sender, EventArgs e)
        {
            CreateBackground();
            ((ToolStripDropDownMenu)moveToolStripMenuItem.DropDown).ShowImageMargin = false;
        }

        private void CreateBackground()
        {
            Bitmap flag = new Bitmap(20, 20);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int left = 0;
            int gray = 0;
            int white = 10;
            while (left <= this.Width)
            {
                while (white <= this.Height)
                {
                    flagGraphics.FillRectangle(Brushes.LightGray, left, gray, 10, 10);
                    flagGraphics.FillRectangle(Brushes.White, left, white, 10, 10);
                    gray += 20;
                    white += 20;
                }
                left += 10;
                gray = -left;
                white = 10 - left;
            }
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.BackgroundImage = flag;
        }

        private void FormODC_FormClosing(object sender, FormClosingEventArgs e)
        {
            vdc.odc = null;
        }

        int k = 0;
        private void FormODC_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            s.MakeTransparent(Color.Black);
            e.Graphics.DrawImage(s, new Rectangle((this.ClientSize.Width / 2) - (s.Width / 2) * zoom + offsetx, (this.ClientSize.Height / 2) - (s.Height / 2) * zoom + offsety, s.Width * zoom, s.Height * zoom));

            int count = 0;
            for (k = 0; k <= global.objectfile.bmp_begin.bmps.Count; k++)
            {
                if (global.objectfile == null
                    || k >= global.objectfile.bmp_begin.bmps.Count
                    || global.objectfile.bmp_begin.bmps.Count == 0
                    || global.objectfile.bmp_begin.bmps[k].row * global.objectfile.bmp_begin.bmps[k].col == 0
                    || global.objectfile.frames.Count == 0
                    || global.framenumber < 0)
                    break;
                if (count <= global.objectfile.frames[global.framenumber].pic
                    && global.objectfile.frames[global.framenumber].pic < count + global.objectfile.bmp_begin.bmps[k].row * global.objectfile.bmp_begin.bmps[k].col)
                {
                    Bitmap load;
                    if(File.Exists(vdc.lf2root + global.objectfile.bmp_begin.bmps[k].path)) load = new Bitmap(vdc.lf2root + global.objectfile.bmp_begin.bmps[k].path);
                    else break;
                    load.MakeTransparent(Color.Black);
                    Bitmap crop = load.Clone(new Rectangle(((global.objectfile.frames[global.framenumber].pic - count) % global.objectfile.bmp_begin.bmps[k].row) * (global.objectfile.bmp_begin.bmps[k].w + 1), ((global.objectfile.frames[global.framenumber].pic - count) / global.objectfile.bmp_begin.bmps[k].row) * (global.objectfile.bmp_begin.bmps[k].h + 1), global.objectfile.bmp_begin.bmps[k].w, global.objectfile.bmp_begin.bmps[k].h), System.Drawing.Imaging.PixelFormat.DontCare);
                    e.Graphics.DrawImage(crop, new Rectangle((this.ClientSize.Width / 2) - global.objectfile.frames[global.framenumber].centerx * zoom + offsetx, (this.ClientSize.Height / 2) - global.objectfile.frames[global.framenumber].centery * zoom + offsety, global.objectfile.bmp_begin.bmps[k].w * zoom, global.objectfile.bmp_begin.bmps[k].h * zoom));

                    /*e.Graphics.DrawRectangle(Pens.White, new Rectangle((this.ClientSize.Width / 2) - global.objectfile.frames[global.framenumber].centerx * zoom + offsetx, (this.ClientSize.Height / 2) - global.objectfile.frames[global.framenumber].centery * zoom + offsety,global.objectfile.bmp_begin.bmps[k].w * zoom,global.objectfile.bmp_begin.bmps[k].h * zoom));
                        using (Pen pn = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Custom, DashPattern = { 4f, 4f }, DashOffset = dashOffset })
                        {
                            e.Graphics.DrawRectangle(pn, new Rectangle((this.ClientSize.Width / 2) - global.objectfile.frames[global.framenumber].centerx * zoom + offsetx, (this.ClientSize.Height / 2) - global.objectfile.frames[global.framenumber].centery * zoom + offsety,global.objectfile.bmp_begin.bmps[k].w * zoom,global.objectfile.bmp_begin.bmps[k].h * zoom));
                        }*/

                    for (int l = 0; l <= global.objectfile.frames[global.framenumber].bdys.Count - 1; l++)
                    {
                        e.Graphics.DrawRectangle(Pens.Blue,
                            new Rectangle((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].bdys[l].x) * zoom + offsetx,
                                (this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].bdys[l].y) * zoom + offsety,
                                global.objectfile.frames[global.framenumber].bdys[l].w * zoom,
                                global.objectfile.frames[global.framenumber].bdys[l].h * zoom));
                        e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].bdys[l].x) * zoom + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].bdys[l].y) * zoom + offsety),
                            7, 7));
                    }
                    for (int m = 0; m <= global.objectfile.frames[global.framenumber].itrs.Count - 1; m++)
                    {
                        e.Graphics.DrawRectangle(Pens.Red,
                            new Rectangle((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].itrs[m].x) * zoom + offsetx,
                                (this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].itrs[m].y) * zoom + offsety,
                                global.objectfile.frames[global.framenumber].itrs[m].w * zoom,
                                global.objectfile.frames[global.framenumber].itrs[m].h * zoom));
                        e.Graphics.DrawRectangle(Pens.Red, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].itrs[m].x) * zoom + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].itrs[m].y) * zoom + offsety),
                            7, 7));
                    }
                    if (global.objectfile.frames[global.framenumber].wpoint != null)
                    {
                        e.Graphics.FillRectangle(Brushes.LimeGreen, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].wpoint.x - 0.5) * zoom - 3 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].wpoint.y - 0.5) * zoom - 3 + offsety),
                            7, 7));
                        e.Graphics.DrawRectangle(Pens.White, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].wpoint.x - 0.5) * zoom - 1 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].wpoint.y - 0.5) * zoom - 1 + offsety),
                            4, 4));
                    }
                    if (global.objectfile.frames[global.framenumber].opoint != null)
                    {
                        e.Graphics.FillRectangle(Brushes.CornflowerBlue, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].opoint.x - 0.5) * zoom - 3 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].opoint.y - 0.5) * zoom - 3 + offsety),
                            7, 7));
                        e.Graphics.DrawRectangle(Pens.White, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].opoint.x - 0.5) * zoom - 1 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].opoint.y - 0.5) * zoom - 1 + offsety),
                            4, 4));
                    }
                    if (global.objectfile.frames[global.framenumber].cpoint != null)
                    {
                        e.Graphics.FillRectangle(Brushes.Goldenrod, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].cpoint.x - 0.5) * zoom - 3 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].cpoint.y - 0.5) * zoom - 3 + offsety),
                            7, 7));
                        e.Graphics.DrawRectangle(Pens.White, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].cpoint.x - 0.5) * zoom - 1 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].cpoint.y - 0.5) * zoom - 1 + offsety),
                            4, 4));
                    }
                    if (global.objectfile.frames[global.framenumber].bpoint != null)
                    {
                        e.Graphics.FillRectangle(Brushes.Red, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].bpoint.x - 0.5) * zoom - 3 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].bpoint.y - 0.5) * zoom - 3 + offsety),
                            7, 7));
                        e.Graphics.DrawRectangle(Pens.White, new Rectangle(
                            Convert.ToInt32((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].bpoint.x - 0.5) * zoom - 1 + offsetx),
                            Convert.ToInt32((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].bpoint.y - 0.5) * zoom - 1 + offsety),
                            4, 4));
                    }
                    break;
                }
                count = count + global.objectfile.bmp_begin.bmps[k].row * global.objectfile.bmp_begin.bmps[k].col;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = vdc.fctb.UndoEnabled;
            redoToolStripMenuItem.Enabled = vdc.fctb.RedoEnabled;

            if (!ctrl && !space && global.objectfile.frames.Count > global.framenumber && global.framenumber > -1)
            {
                if (global.objectfile.frames[global.framenumber].wpoint != null
                    && MouseIsNearBy(new Point((int)((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].wpoint.x - 0.5) * zoom + offsetx),
                    (int)((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].wpoint.y - 0.5) * zoom + offsety))))
                {
                    this.Cursor = Cursors.SizeAll;
                    dragtype = "wpoint";
                }
                else if (global.objectfile.frames[global.framenumber].bpoint != null
                    && MouseIsNearBy(new Point((int)((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].bpoint.x - 0.5) * zoom + offsetx),
                    (int)((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].bpoint.y - 0.5) * zoom + offsety))))
                {
                    this.Cursor = Cursors.SizeAll;
                    dragtype = "bpoint";
                }
                else if (global.objectfile.frames[global.framenumber].opoint != null
                    && MouseIsNearBy(new Point((int)((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].opoint.x - 0.5) * zoom + offsetx),
                    (int)((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].opoint.y - 0.5) * zoom + offsety))))
                {
                    this.Cursor = Cursors.SizeAll;
                    dragtype = "opoint";
                }
                else if (global.objectfile.frames[global.framenumber].cpoint != null
                    && MouseIsNearBy(new Point((int)((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].cpoint.x - 0.5) * zoom + offsetx),
                    (int)((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].cpoint.y - 0.5) * zoom + offsety))))
                {
                    this.Cursor = Cursors.SizeAll;
                    dragtype = "cpoint";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    dragtype = "";
                    for (int l = 0; l <= global.objectfile.frames[global.framenumber].bdys.Count - 1; l++)
                    {
                        if (global.objectfile.frames[global.framenumber].bdys[l] != null
                            && MouseIsNearBy(new Point((int)((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].bdys[l].x) * zoom + 7 + offsetx),
                            (int)((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].bdys[l].y) * zoom + 7 + offsety))))
                        {
                            this.Cursor = Cursors.SizeAll;
                            dragtype = "bdy" + l.ToString();
                            break;
                        }
                    }
                    for (int m = 0; m <= global.objectfile.frames[global.framenumber].itrs.Count - 1; m++)
                    {
                        if (global.objectfile.frames[global.framenumber].itrs[m] != null
                            && MouseIsNearBy(new Point((int)((this.ClientSize.Width / 2) - (global.objectfile.frames[global.framenumber].centerx - global.objectfile.frames[global.framenumber].itrs[m].x) * zoom + 7 + offsetx),
                            (int)((this.ClientSize.Height / 2) - (global.objectfile.frames[global.framenumber].centery - global.objectfile.frames[global.framenumber].itrs[m].y) * zoom + 7 + offsety))))
                        {
                            this.Cursor = Cursors.SizeAll;
                            dragtype = "itr" + m.ToString();
                            break;
                        }
                    }
                }
            }

            /*if (dashOffset == 4)
                dashOffset = 0;
            dashOffset = dashOffset - 1;*/
            this.Invalidate();
        }

        private void FormODC_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                zoomout();
            else
                zoomin();
            this.Refresh();
        }

        private void zoomin()
        {
            zoom = zoom + 1;
            offsetx += offsetx / zoom;
            offsety += offsety / zoom;
        }

        private void zoomout()
        {
            if (zoom > 1)
            {
                offsetx -= offsetx / zoom;
                offsety -= offsety / zoom;
                zoom = zoom - 1;
            }
        }

        private void FormODC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!ctrl && !space)
                        previousFrame();
                    break;
                case Keys.Down:
                    if (!ctrl && !space)
                        nextFrame();
                    break;
                case Keys.Space:
                    if (!ctrl)
                    {
                        space = true;
                        this.Cursor = Cursors.NoMove2D;
                    }
                    break;
                case Keys.ControlKey:
                    if (!space && dragtype == "")
                    {
                        ctrl = true;
                        this.Cursor = Cursors.SizeAll;
                    }
                    break;
                case Keys.ShiftKey:
                    shift = true;
                    break;
            }
        }

        private void FormODC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && space)
            {
                space = false;
                dragStartPoint = false;
                dragEndPoint = false;
                this.Cursor = Cursors.Default;
            }
            else if (e.KeyCode == Keys.ControlKey && ctrl)
            {
                ctrl = false;
                dragStartPoint = false;
                dragEndPoint = false;
                this.Cursor = Cursors.Default;
                TrackTip.Show(TipText, this, new Point(-1000, -1000));
            }
            else if (e.KeyCode == Keys.ShiftKey && shift)
            {
                shift = false;
                if (!ctrl) this.Cursor = Cursors.Default;
                else this.Cursor = Cursors.SizeAll;
            }
        }

        private void FormODC_MouseDown(object sender, MouseEventArgs e)
        {
            if ((ctrl || dragtype != "") && global.framenumber > -1)
            {
                oldMouseX = e.X;
                oldMouseY = e.Y;
                while (global.objectfile.frames.Count <= global.framenumber)
                    global.objectfile.frames.Add(new Frame());
                if (ctrl)
                {
                    oldStartPoint = new Point(global.retentiveframe.centerx * zoom, global.retentiveframe.centery * zoom);
                    oldEndPoint = new Point(global.retentiveframe.centerx * zoom, global.retentiveframe.centery * zoom);
                }
                else if (dragtype == "wpoint")
                {
                    oldStartPoint = new Point(global.retentiveframe.wpoint.x * zoom, global.retentiveframe.wpoint.y * zoom);
                    oldEndPoint = new Point(global.retentiveframe.wpoint.x * zoom, global.retentiveframe.wpoint.y * zoom);
                }
                else if (dragtype == "bpoint")
                {
                    oldStartPoint = new Point(global.retentiveframe.bpoint.x * zoom, global.retentiveframe.bpoint.y * zoom);
                    oldEndPoint = new Point(global.retentiveframe.bpoint.x * zoom, global.retentiveframe.bpoint.y * zoom);
                }
                else if (dragtype == "opoint")
                {
                    oldStartPoint = new Point(global.retentiveframe.opoint.x * zoom, global.retentiveframe.opoint.y * zoom);
                    oldEndPoint = new Point(global.retentiveframe.opoint.x * zoom, global.retentiveframe.opoint.y * zoom);
                }
                else if (dragtype == "cpoint")
                {
                    oldStartPoint = new Point(global.retentiveframe.cpoint.x * zoom, global.retentiveframe.cpoint.y * zoom);
                    oldEndPoint = new Point(global.retentiveframe.cpoint.x * zoom, global.retentiveframe.cpoint.y * zoom);
                }
                else if (dragtype.StartsWith("itr"))
                {
                    for (int m = 0; m <= global.objectfile.frames[global.framenumber].itrs.Count - 1; m++)
                    {
                        if (dragtype.EndsWith(m.ToString()))
                        {
                            oldStartPoint = new Point(global.retentiveframe.itrs[m].x * zoom, global.retentiveframe.itrs[m].y * zoom);
                            oldEndPoint = new Point(global.retentiveframe.itrs[m].x * zoom, global.retentiveframe.itrs[m].y * zoom);
                            break;
                        }
                    }
                }
                else if (dragtype.StartsWith("bdy"))
                {
                    for (int l = 0; l <= global.objectfile.frames[global.framenumber].bdys.Count - 1; l++)
                    {
                        if (dragtype.EndsWith(l.ToString()))
                        {
                            oldStartPoint = new Point(global.retentiveframe.bdys[l].x * zoom, global.retentiveframe.bdys[l].y * zoom);
                            oldEndPoint = new Point(global.retentiveframe.bdys[l].x * zoom, global.retentiveframe.bdys[l].y * zoom);
                            break;
                        }
                    }
                }
                dragStartPoint = MouseIsNearBy(oldStartPoint);
                dragEndPoint = MouseIsNearBy(oldEndPoint);
                if ((!dragStartPoint && !dragEndPoint))
                {
                    //If not drag either end, then drag both.
                    dragStartPoint = true;
                    dragEndPoint = true;
                }
            }
            else if (space)
            {
                oldMouseX = e.X;
                oldMouseY = e.Y;
                oldStartPoint = new Point(offsetx, offsety);
                oldEndPoint = new Point(offsetx, offsety);
                dragStartPoint = MouseIsNearBy(oldStartPoint);
                dragEndPoint = MouseIsNearBy(oldEndPoint);
                if ((!dragStartPoint && !dragEndPoint))
                {
                    dragStartPoint = true;
                    dragEndPoint = true;
                }
            }
        }

        private Point movepoint(Point e, Point r, Point p)
        {
            if (!shift || Math.Abs(r.X - (oldStartPoint.X - e.X + oldMouseX) / zoom) > Math.Abs(r.Y - (oldStartPoint.Y - e.Y + oldMouseY) / zoom))
            {
                if (shift)
                {
                    this.Cursor = Cursors.SizeWE;
                    p.Y = r.Y;
                }
                if (ctrl) p.X = (oldStartPoint.X - e.X + oldMouseX) / zoom;
                else p.X = (oldStartPoint.X + e.X - oldMouseX) / zoom;
            }
            if (!shift || Math.Abs(r.X - (oldStartPoint.X - e.X + oldMouseX) / zoom) <= Math.Abs(r.Y - (oldStartPoint.Y - e.Y + oldMouseY) / zoom))
            {
                if (shift)
                {
                    this.Cursor = Cursors.SizeNS;
                    p.X = r.X;
                }
                if (ctrl) p.Y = (oldStartPoint.Y - e.Y + oldMouseY) / zoom;
                else p.Y = (oldStartPoint.Y + e.Y - oldMouseY) / zoom;
            }
            TipText = string.Format("x: {0} y: {1}", p.X, p.Y);
            if (!shift) this.Cursor = Cursors.SizeAll;
            TrackTip.Show(TipText, this, new Point(e.X, e.Y));
            TrackTip.AutoPopDelay = 500;
            TrackTip.InitialDelay = 100;
            TrackTip.ReshowDelay = 50;
            this.Refresh();
            return p;
        }

        private void FormODC_MouseMove(object sender, MouseEventArgs e)
        {
            if ((dragStartPoint || dragEndPoint) && (ctrl || dragtype != ""))
            {
                if (ctrl)
                {
                    Point p = movepoint(new Point(e.X, e.Y),
                        new Point(global.retentiveframe.centerx, global.retentiveframe.centery),
                        new Point(global.objectfile.frames[global.framenumber].centerx, global.objectfile.frames[global.framenumber].centery));
                    global.objectfile.frames[global.framenumber].centerx = p.X;
                    global.objectfile.frames[global.framenumber].centery = p.Y;
                }
                else if (dragtype == "wpoint")
                {
                    Point p = movepoint(new Point(e.X, e.Y),
                        new Point(global.retentiveframe.wpoint.x, global.retentiveframe.wpoint.y),
                        new Point(global.objectfile.frames[global.framenumber].wpoint.x, global.objectfile.frames[global.framenumber].wpoint.y));
                    global.objectfile.frames[global.framenumber].wpoint.x = p.X;
                    global.objectfile.frames[global.framenumber].wpoint.y = p.Y;
                }
                else if (dragtype == "bpoint")
                {
                    Point p = movepoint(new Point(e.X, e.Y),
                        new Point(global.retentiveframe.bpoint.x, global.retentiveframe.bpoint.y),
                        new Point(global.objectfile.frames[global.framenumber].bpoint.x, global.objectfile.frames[global.framenumber].bpoint.y));
                    global.objectfile.frames[global.framenumber].bpoint.x = p.X;
                    global.objectfile.frames[global.framenumber].bpoint.y = p.Y;
                }
                else if (dragtype == "opoint")
                {
                    Point p = movepoint(new Point(e.X, e.Y),
                        new Point(global.retentiveframe.opoint.x, global.retentiveframe.opoint.y),
                        new Point(global.objectfile.frames[global.framenumber].opoint.x, global.objectfile.frames[global.framenumber].opoint.y));
                    global.objectfile.frames[global.framenumber].opoint.x = p.X;
                    global.objectfile.frames[global.framenumber].opoint.y = p.Y;
                }
                else if (dragtype == "cpoint")
                {
                    Point p = movepoint(new Point(e.X, e.Y),
                        new Point(global.retentiveframe.cpoint.x, global.retentiveframe.cpoint.y),
                        new Point(global.objectfile.frames[global.framenumber].cpoint.x, global.objectfile.frames[global.framenumber].cpoint.y));
                    global.objectfile.frames[global.framenumber].cpoint.x = p.X;
                    global.objectfile.frames[global.framenumber].cpoint.y = p.Y;
                }
                else if (dragtype.StartsWith("itr"))
                {
                    for (int m = 0; m <= global.objectfile.frames[global.framenumber].itrs.Count - 1; m++)
                    {
                        if (dragtype.EndsWith(m.ToString()))
                        {
                            Point p = movepoint(new Point(e.X, e.Y),
                                new Point(global.retentiveframe.itrs[m].x, global.retentiveframe.itrs[m].y),
                                new Point(global.objectfile.frames[global.framenumber].itrs[m].x, global.objectfile.frames[global.framenumber].itrs[m].y));
                            global.objectfile.frames[global.framenumber].itrs[m].x = p.X;
                            global.objectfile.frames[global.framenumber].itrs[m].y = p.Y;
                            break;
                        }
                    }
                }
                else if (dragtype.StartsWith("bdy"))
                {
                    for (int l = 0; l <= global.objectfile.frames[global.framenumber].bdys.Count - 1; l++)
                    {
                        if (dragtype.EndsWith(l.ToString()))
                        {
                            Point p = movepoint(new Point(e.X, e.Y),
                                new Point(global.retentiveframe.bdys[l].x, global.retentiveframe.bdys[l].y),
                                new Point(global.objectfile.frames[global.framenumber].bdys[l].x, global.objectfile.frames[global.framenumber].bdys[l].y));
                            global.objectfile.frames[global.framenumber].bdys[l].x = p.X;
                            global.objectfile.frames[global.framenumber].bdys[l].y = p.Y;
                            break;
                        }
                    }
                }
            }
            else
                if ((dragStartPoint || dragEndPoint) && space)
                {
                    offsetx = oldStartPoint.X + e.X - oldMouseX;
                    offsety = oldStartPoint.Y + e.Y - oldMouseY;
                    TrackTip.AutoPopDelay = 500;
                    TrackTip.InitialDelay = 100;
                    TrackTip.ReshowDelay = 50;
                    this.Refresh();
                }
        }

        private bool MouseIsNearBy(Point testPoint)
        {
            testPoint = this.PointToScreen(testPoint);
            return Math.Abs(testPoint.X - MousePosition.X) <= HitTestDelta && Math.Abs(testPoint.Y - MousePosition.Y) <= HitTestDelta;
        }

        private void FormODC_MouseUp(object sender, MouseEventArgs e)
        {
            dragStartPoint = false;
            dragEndPoint = false;
            TrackTip.Show(TipText, this, new Point(-1000, -1000));

            if (global.framenumber > -1 && vdc.rangestart > -1)
                replace();
        }

        private void replace()
        {
            string currenttag = "";
            int m = -1;
            int l = -1;
            for (int i = vdc.rangestart; i <= vdc.rangeend; i++)
            {
                string replacement = vdc.fctb.GetLineText(i);
                if (vdc.fctb.Lines[i].Contains("wpoint:")) currenttag = "wpoint";
                else if (vdc.fctb.Lines[i].Contains("bpoint:")) currenttag = "bpoint";
                else if (vdc.fctb.Lines[i].Contains("opoint:")) currenttag = "opoint";
                else if (vdc.fctb.Lines[i].Contains("cpoint:")) currenttag = "cpoint";
                else if (vdc.fctb.Lines[i].Contains("itr:")) { currenttag = "itr"; m++; }
                else if (vdc.fctb.Lines[i].Contains("bdy:")) { currenttag = "bdy"; l++; }
                else if (vdc.fctb.Lines[i].Contains("_end:")) currenttag = "";
                if (vdc.fctb.Lines[i].Contains("centerx: ")
                    && global.retentiveframe.centerx != global.objectfile.frames[global.framenumber].centerx)
                    replacement = replacement.Replace("centerx: " + global.retentiveframe.centerx.ToString(), "centerx: " + global.objectfile.frames[global.framenumber].centerx.ToString());
                if (vdc.fctb.Lines[i].Contains("centery: ")
                    && global.retentiveframe.centery != global.objectfile.frames[global.framenumber].centery)
                    replacement = replacement.Replace("centery: " + global.retentiveframe.centery.ToString(), "centery: " + global.objectfile.frames[global.framenumber].centery.ToString());
                if (currenttag == "wpoint" && vdc.fctb.Lines[i].Contains(" x: ")
                    && global.retentiveframe.wpoint.x != global.objectfile.frames[global.framenumber].wpoint.x)
                    replacement = replacement.Replace(" x: " + global.retentiveframe.wpoint.x.ToString(), " x: " + global.objectfile.frames[global.framenumber].wpoint.x.ToString());
                if (currenttag == "wpoint" && vdc.fctb.Lines[i].Contains(" y: ")
                    && global.retentiveframe.wpoint.y != global.objectfile.frames[global.framenumber].wpoint.y)
                    replacement = replacement.Replace(" y: " + global.retentiveframe.wpoint.y.ToString(), " y: " + global.objectfile.frames[global.framenumber].wpoint.y.ToString());
                if (currenttag == "bpoint" && vdc.fctb.Lines[i].Contains(" x: ")
                    && global.retentiveframe.bpoint.x != global.objectfile.frames[global.framenumber].bpoint.x)
                    replacement = replacement.Replace(" x: " + global.retentiveframe.bpoint.x.ToString(), " x: " + global.objectfile.frames[global.framenumber].bpoint.x.ToString());
                if (currenttag == "bpoint" && vdc.fctb.Lines[i].Contains(" y: ")
                    && global.retentiveframe.bpoint.y != global.objectfile.frames[global.framenumber].bpoint.y)
                    replacement = replacement.Replace(" y: " + global.retentiveframe.bpoint.y.ToString(), " y: " + global.objectfile.frames[global.framenumber].bpoint.y.ToString());
                if (currenttag == "opoint" && vdc.fctb.Lines[i].Contains(" x: ")
                    && global.retentiveframe.opoint.x != global.objectfile.frames[global.framenumber].opoint.x)
                    replacement = replacement.Replace(" x: " + global.retentiveframe.opoint.x.ToString(), " x: " + global.objectfile.frames[global.framenumber].opoint.x.ToString());
                if (currenttag == "opoint" && vdc.fctb.Lines[i].Contains(" y: ")
                    && global.retentiveframe.opoint.y != global.objectfile.frames[global.framenumber].opoint.y)
                    replacement = replacement.Replace(" y: " + global.retentiveframe.opoint.y.ToString(), " y: " + global.objectfile.frames[global.framenumber].opoint.y.ToString());
                if (currenttag == "cpoint" && vdc.fctb.Lines[i].Contains(" x: ")
                    && global.retentiveframe.cpoint.x != global.objectfile.frames[global.framenumber].cpoint.x)
                    replacement = replacement.Replace(" x: " + global.retentiveframe.cpoint.x.ToString(), " x: " + global.objectfile.frames[global.framenumber].cpoint.x.ToString());
                if (currenttag == "cpoint" && vdc.fctb.Lines[i].Contains(" y: ")
                    && global.retentiveframe.cpoint.y != global.objectfile.frames[global.framenumber].cpoint.y)
                    replacement = replacement.Replace(" y: " + global.retentiveframe.cpoint.y.ToString(), " y: " + global.objectfile.frames[global.framenumber].cpoint.y.ToString());
                
                if (m > -1 && currenttag == "itr" && vdc.fctb.Lines[i].Contains(" x: ")
                    && global.retentiveframe.itrs[m].x != global.objectfile.frames[global.framenumber].itrs[m].x)
                    replacement = replacement.Replace(" x: " + global.retentiveframe.itrs[m].x.ToString(), " x: " + global.objectfile.frames[global.framenumber].itrs[m].x.ToString());
                if (m > -1 && currenttag == "itr" && vdc.fctb.Lines[i].Contains(" y: ")
                    && global.retentiveframe.itrs[m].y != global.objectfile.frames[global.framenumber].itrs[m].y)
                    replacement = replacement.Replace(" y: " + global.retentiveframe.itrs[m].y.ToString(), " y: " + global.objectfile.frames[global.framenumber].itrs[m].y.ToString());
                
                if (l > -1 && currenttag == "bdy" && vdc.fctb.Lines[i].Contains(" x: ")
                    && global.retentiveframe.bdys[l].x != global.objectfile.frames[global.framenumber].bdys[l].x)
                    replacement = replacement.Replace(" x: " + global.retentiveframe.bdys[l].x.ToString(), " x: " + global.objectfile.frames[global.framenumber].bdys[l].x.ToString());
                if (l > -1 && currenttag == "bdy" && vdc.fctb.Lines[i].Contains(" y: ")
                    && global.retentiveframe.bdys[l].y != global.objectfile.frames[global.framenumber].bdys[l].y)
                    replacement = replacement.Replace(" y: " + global.retentiveframe.bdys[l].y.ToString(), " y: " + global.objectfile.frames[global.framenumber].bdys[l].y.ToString());
                
                if (replacement != vdc.fctb.GetLineText(i))
                {
                    vdc.fctb.Navigate(i);
                    vdc.fctb.ClearCurrentLine();
                    vdc.fctb.InsertText("\r\n" + replacement);
                }
            }
        }

        internal void Exit()
        {
            throw new NotImplementedException();
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.objectfile.frames[global.framenumber].centery++;
            replace();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.objectfile.frames[global.framenumber].centery--;
            replace();
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.objectfile.frames[global.framenumber].centerx--;
            replace();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global.objectfile.frames[global.framenumber].centerx++;
            replace();
        }

        private void zoominCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomin();
        }

        private void zoomoutCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomout();
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (global.objectfile.frames.Count > global.framenumber && global.framenumber > -1)
            {
                offsetx = 0;
                offsety = (zoom - 1) * global.objectfile.frames[global.framenumber].centery / 2;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vdc.fctb.UndoEnabled)
                vdc.fctb.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vdc.fctb.RedoEnabled)
                vdc.fctb.Redo();
        }

        private void previousFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previousFrame();
        }

        private void nextFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nextFrame();
        }

        private void previousFrame()
        {
            int framenumber = global.retentiveframe.number;
            int i = vdc.rangestart;
            while ((framenumber == global.retentiveframe.number || vdc.rangetype != "<frame_end>") && i > 0)
            {
                i--;
                vdc.fctb.Navigate(i);
            }
        }

        private void nextFrame()
        {
            int framenumber = global.retentiveframe.number;
            int i = vdc.rangeend;
            while ((framenumber == global.retentiveframe.number || vdc.rangetype != "<frame_end>") && i < vdc.fctb.LinesCount)
            {
                i++;
                vdc.fctb.Navigate(i);
            }
        }
                    
    }
}