using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;
using System.Diagnostics;

namespace VDC
{

    public partial class FormVDC : Form
    {

        private string filepath;
        public string lf2root;
        bool saved = true;
        //frame viewer
        public FormODC odc;
        //about
        public FormAbout about;
        //settings
        public FormSettings fs;

        //Create style for highlighting
        TextStyle blueStyle = new TextStyle(new SolidBrush(Color.FromArgb(unchecked((int)0xff0000A0))), null, FontStyle.Regular);
        string brackets = "<bmp_begin>|<bmp_end>|<boss>|<background>|<background_end>|<end>|<frame>|<frame_end>|<file_editing>|<file_editing_end>|<object>|<object_end>|<phase>|<phase_end>|<stage>|<stage_end>|<soldier>|<weapon_strength_list>|<weapon_strength_list_end>";
        TextStyle redStyle = new TextStyle(new SolidBrush(Color.FromArgb(unchecked((int)0xff800000))), null, FontStyle.Regular);
        string attributes = "attacking: |aaction: |action: |act: |arest: |backhurtact: |bdefend: |bound: |col: |centerx: |centery: |cover: |catchingact: |caughtact: |cc: |c1: |c2: |dash_height |dash_distance |dash_distancez |dvx: |dvy: |dvz: |decrease: |dircontrol: |effect: |entry: |file|fronthurtact: |fall: |facing: |file: |heavy_walking_speed |heavy_walking_speedz |heavy_running_speed |heavy_running_speedz |h: |head: |hit_a: |hit_d: |hit_j: |hit_Fa: |hit_Ua: |hit_Da: |hit_Fj: |hit_Uj: |hit_Dj: |hit_ja: |hurtable: |hp: |height: |id: |injury: |jaction: |jump_height |jump_distance |jump_distancez |join: |kind: |loop: |mp: |music: |name: |next: |oid: |pic: |running_frame_rate |running_speed |running_speedz |rowing_height |rowing_distance |row: |ratio: |rect: |reserve: |small: |state: |sound: |shadow: |shadowsize: |taction: |throwvx: |throwvy: |throwvz: |throwinjury: |times: |type: |transparency: |vaction: |vrest: |walking_frame_rate |walking_speed |walking_speedz |w: |wait: |weaponact: |weapon_hit_sound: |weapon_drop_sound: |weapon_broken_sound: |weapon_hp: |weapon_drop_hurt: |width: |when_clear_goto_phase: |x: |y: |zwidth: |zboundary: ";
        TextStyle greenStyle = new TextStyle(new SolidBrush(Color.FromArgb(unchecked((int)0xff008040))), null, FontStyle.Regular);
        string tags = "bpoint:|bpoint_end:|bdy:|bdy_end:|cpoint:|cpoint_end:|itr:|itr_end:|layer:|layer_end|opoint:|opoint_end:|wpoint:|wpoint_end:";
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.DarkGray)));
        TextStyle linkStyle = new TextStyle(Brushes.Blue, null, FontStyle.Underline);

        public FormVDC(string[] args)
        {
            filepath = "untitled";
            global.objectfile = new ObjectFile();
            InitializeComponent();
            if (args.Length != 0)
                open(args[0]);
            else
            {
                this.Text = Path.GetFileName(filepath);
                fctb.IsChanged = false;
                fctb.Invalidate();
                saved = true;
            }
        }

        private void FormVDC_Load(object sender, EventArgs e)
        {
            // Removing image margins (space for icons on left) from menubar items:
            ((ToolStripDropDownMenu)foldAllToolStripMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)unfoldAllToolStripMenuItem.DropDown).ShowImageMargin = false;
        }

        private void checkopen(string args)
        {
            if (checksavestatus())
            {
                open(args);
            }
        }

        private void open(string args)
        {
            if (args.EndsWith(".dat"))
                fctb.Text = DecryptFile.Main(args);
            else
            {
                StreamReader sr = new StreamReader(args);
                fctb.Text = sr.ReadToEnd();
                sr.Close();
            }
            this.Text = Path.GetFileName(args);
            fctb.IsChanged = false;
            fctb.Invalidate();
            saved = true;
            filepath = args;

            //only parse bmp header here
            //global.objectfile.bmp_begin = DataParser.getHeader(Regex.Split(fctb.Text, @"\s").OfType<string>().ToList());
            global.objectfile.bmp_begin = DataParser.getHeader(Regex.Split(Regex.Split(fctb.Text, @"bmp_end")[0], @"\s").OfType<string>().ToList());

            //get lf2.exe path
            lf2root = Path.GetDirectoryName(args) + "\\lf2.exe";
            while (!File.Exists(lf2root) && lf2root.Length > 10)
                lf2root = lf2root.Substring(0, lf2root.Length - new DirectoryInfo(Path.GetDirectoryName(lf2root)).Name.Length - Path.GetFileName(lf2root).Length - 2) + "\\lf2.exe";
            lf2root = Path.GetDirectoryName(lf2root) + "\\";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checksavestatus())
                if (ofd.ShowDialog() == DialogResult.OK)
                    open(ofd.FileName);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checksavestatus())
                if (ifd.ShowDialog() == DialogResult.OK)
                    open(ifd.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private bool save()
        {
            if (filepath == "untitled" || (filepath.EndsWith(".dat") && !Properties.Settings.Default.datenabled))
                return saveAs();            
            if (filepath.EndsWith(".dat") && Properties.Settings.Default.datenabled)
            {
                //encrypt
            }
            else
            {
                StreamWriter sw = new StreamWriter(filepath);
                sw.Write(fctb.Text);
                sw.Close();
            }
            this.Text = Path.GetFileName(filepath);
            fctb.IsChanged = false;
            fctb.Invalidate();
            return saved = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private bool saveAs()
        {
            svd.FileName = Path.GetFileNameWithoutExtension(filepath);
            if (svd.ShowDialog() == DialogResult.OK)
            {
                filepath = svd.FileName;
                StreamWriter sw = new StreamWriter(filepath);
                sw.Write(fctb.Text);
                sw.Close();
                this.Text = Path.GetFileName(filepath);
                fctb.IsChanged = false;
                fctb.Invalidate();
                return saved = true;
            }
            return false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormVDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!checksavestatus())
                e.Cancel = true;
        }

        private bool checksavestatus()
        {
            if (!saved)
            {
                DialogResult dr = MessageBox.Show("Save your work before closing " + Path.GetFileName(filepath) + "?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dr == DialogResult.Yes)
                {
                    if (save())
                        return true;
                    return false;
                }
                else if (dr == DialogResult.No)
                    return true;
                return false;
            }
            else
                return true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fctb.UndoEnabled)
                fctb.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fctb.RedoEnabled)
                fctb.Redo();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.ShowReplaceDialog();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
            {
                fctb.DoAutoIndent(iLine);
                fctb.DoAutoIndentChars(iLine);
            }
        }

        private void framesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
                if (fctb[iLine].FoldingStartMarker == "<frame>"
                    || fctb[iLine].FoldingStartMarker == "<phase>")
                    fctb.CollapseFoldingBlock(iLine);
        }

        private void tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
                if (fctb[iLine].FoldingStartMarker == "bpoint:"
                    || fctb[iLine].FoldingStartMarker == "cpoint:"
                    || fctb[iLine].FoldingStartMarker == "opoint:"
                    || fctb[iLine].FoldingStartMarker == "wpoint:"
                    || fctb[iLine].FoldingStartMarker == "bdy:"
                    || fctb[iLine].FoldingStartMarker == "itr:"
                    || fctb[iLine].FoldingStartMarker == "layer:")
                    fctb.CollapseFoldingBlock(iLine);
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.CollapseAllFoldingBlocks();
        }

        private void framesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
                if (fctb[iLine].FoldingStartMarker == "<frame>"
                    || fctb[iLine].FoldingStartMarker == "<phase>")
                    fctb.ExpandFoldedBlock(iLine);
        }

        private void tagsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int iLine = 0; iLine < fctb.LinesCount; iLine++)
                if (fctb[iLine].FoldingStartMarker == "bpoint:"
                    || fctb[iLine].FoldingStartMarker == "cpoint:"
                    || fctb[iLine].FoldingStartMarker == "opoint:"
                    || fctb[iLine].FoldingStartMarker == "wpoint:"
                    || fctb[iLine].FoldingStartMarker == "bdy:"
                    || fctb[iLine].FoldingStartMarker == "itr:"
                    || fctb[iLine].FoldingStartMarker == "layer:")
                    fctb.ExpandFoldedBlock(iLine);
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fctb.ExpandAllFoldingBlocks();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Zoom += fctb.Zoom / 5;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Zoom -= fctb.Zoom / 6;
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Zoom = 100;
        }

        private void frameViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (odc == null)
            {
                odc = new FormODC();
                odc.Owner = this;
                odc.vdc = this;
                odc.Show();
                this.Focus();
            }
            else
                odc.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = new FormAbout();
            about.Owner = this;
            about.Show();
        }


        private void fctb_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            SyntaxHighlight(e);//custom highlighting
            this.Text = Path.GetFileName(filepath) + "*";
            saved = false;
        }

        private void SyntaxHighlight(TextChangedEventArgs e)
        {
            //clear style of changed range
            e.ChangedRange.ClearStyle(blueStyle, redStyle, greenStyle, linkStyle);

            //link
            e.ChangedRange.SetStyle(linkStyle, @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?");
            //highlight brackets
            e.ChangedRange.SetStyle(blueStyle, brackets);
            //highlight attributes
            e.ChangedRange.SetStyle(redStyle, attributes);
            //highlight tags
            e.ChangedRange.SetStyle(greenStyle, tags);

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("<object>", "<object_end>");//allow to collapse <object> blocks
            e.ChangedRange.SetFoldingMarkers("<file_editing>", "<file_editing_end>");//allow to collapse <file_editing> blocks
            //allow to collapse <bmp_begin> blocks
            e.ChangedRange.SetFoldingMarkers("<bmp_begin>", "<bmp_end>");
            e.ChangedRange.SetFoldingMarkers("<weapon_strength_list>", "<weapon_strength_list_end>");//allow to collapse <weapon_strength_list> blocks
            e.ChangedRange.SetFoldingMarkers("<frame>", "<frame_end>");//allow to collapse <frame> blocks
            e.ChangedRange.SetFoldingMarkers("bpoint:", "bpoint_end:");//allow to collapse bpoint: blocks
            e.ChangedRange.SetFoldingMarkers("bdy:", "bdy_end:");//allow to collapse bdy: blocks
            e.ChangedRange.SetFoldingMarkers("cpoint:", "cpoint_end:");//allow to collapse cpoint: blocks
            e.ChangedRange.SetFoldingMarkers("itr:", "itr_end:");//allow to collapse itr: blocks
            e.ChangedRange.SetFoldingMarkers("opoint:", "opoint_end:");//allow to collapse opoint: blocks
            e.ChangedRange.SetFoldingMarkers("wpoint:", "wpoint_end:");//allow to collapse wpoint: blocks
            //allow to collapse <background> blocks
            e.ChangedRange.SetFoldingMarkers("<background>", "<background_end>");
            e.ChangedRange.SetFoldingMarkers("layer:", "layer_end:");//allow to collapse layer: blocks
            //allow to collapse <stage> blocks
            e.ChangedRange.SetFoldingMarkers("<stage>", "<stage_end>");
            e.ChangedRange.SetFoldingMarkers("<phase>", "<phase_end>");//allow to collapse <phase> blocks
        }

        private void fctb_MouseMove(object sender, MouseEventArgs e)
        {
            var p = fctb.PointToPlace(e.Location);
            if (CharIsHyperlink(p))
                fctb.Cursor = Cursors.Hand;
            else
                fctb.Cursor = Cursors.IBeam;
        }

        private void fctb_MouseDown(object sender, MouseEventArgs e)
        {
            var p = fctb.PointToPlace(e.Location);
            if (CharIsHyperlink(p))
            {
                var url = fctb.GetRange(p, p).GetFragment(@"[\S]").Text;
                Process.Start(url);
            }
        }

        bool CharIsHyperlink(Place place)
        {
            var mask = fctb.GetStyleIndexMask(new Style[] { linkStyle });
            if (place.iChar < fctb.GetLineLength(place.iLine))
                if ((fctb[place].style & mask) != 0)
                    return true;
            return false;
        }

        private void fctb_SelectionChangedDelayed(object sender, EventArgs e)
        {
            fctb.VisibleRange.ClearStyle(SameWordsStyle);
            if (!fctb.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fctb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fctb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(SameWordsStyle);
        }

        private void fctb_SelectionChanged_1(object sender, EventArgs e)
        {
            range.Clear();
            //get selected range
            if (rangestart > -1 && rangeend > -1 && rangeend < fctb.LinesCount)
                for (int i = rangestart; i <= rangeend; i++)
                    fctb[i].BackgroundBrush = null;
            GetRange();
            string text = "";
            if (rangestart > -1 && rangeend > -1 && rangeend < fctb.LinesCount)
                for (int i = rangestart; i <= rangeend; i++)
                {
                    range.Add(i);
                    //range += fctb.GetLineLength(i);
                    text += fctb.GetLineText(i) + "\r\n";
                    fctb[i].BackgroundBrush = new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke));
                }

            //update objectfile and frame viewer
            if (rangetype == "<frame_end>")
            {
                while (global.objectfile.frames.Count <= global.framenumber)
                {
                    global.objectfile.frames.Add(new Frame());
                }
                global.retentiveframe = DataParser.getFrame(Regex.Split(text, @"\s").OfType<string>().ToList());
                global.objectfile.frames[global.framenumber] = DataParser.getFrame(Regex.Split(text, @"\s").OfType<string>().ToList());
                if (odc != null)
                {
                    odc.Text = "<frame> " + global.framenumber + " " + global.objectfile.frames[global.framenumber].name;
                    odc.Invalidate();
                }
            }
            else if (rangetype != "")
            {
                if (rangetype == "<bmp_end>")  global.objectfile.bmp_begin = DataParser.getHeader(Regex.Split(text, @"\s").OfType<string>().ToList());
                if (odc != null)
                {
                    global.framenumber = -1;
                    odc.Text = "select a frame";
                    odc.Invalidate();
                }
            }
        }

        public List<int> range = new List<int>();
        public int rangestart = -1;
        public int rangeend = -1;
        public string rangetype = "";
        private void GetRange()
        {
            int s = rangestart;
            int e = rangeend;
            for (rangestart = fctb.Selection.Start.iLine; rangestart >= 0; rangestart--)
            {
                if (fctb.GetLine(rangestart).Text.Contains("<bmp_begin>")
                    || fctb.GetLine(rangestart).Text.Contains("<weapon_strength_list>")
                    || fctb.GetLine(rangestart).Text.Contains("<frame>"))
                {
                    if (fctb.GetLine(rangestart).Text.Contains("<bmp_begin>")) rangetype = "<bmp_end>";
                    else if (fctb.GetLine(rangestart).Text.Contains("<weapon_strength_list>")) rangetype = "<weapon_strength_list_end>";
                    else if (fctb.GetLine(rangestart).Text.Contains("<frame>"))
                    {
                        Match m = Regex.Match(fctb.GetLine(rangestart).Text, @"\s+\d+\s+");
                        if (m.Success) global.framenumber = Convert.ToInt32(m.Value);
                        rangetype = "<frame_end>";
                    }
                    for (rangeend = fctb.Selection.Start.iLine; rangeend < fctb.LinesCount; rangeend++)
                    {
                        if (fctb.GetLine(rangeend).Text.Contains(rangetype)) return;
                        else if (fctb.GetLine(rangeend).Text.Contains("<frame>") && rangeend != fctb.Selection.Start.iLine)
                        {
                            rangestart = s;
                            rangeend = e;
                            rangetype = "";
                            return;
                        }
                    }
                    rangestart = s;
                    rangeend = e;
                    rangetype = "";
                    break;
                }
                else if (fctb.GetLine(rangestart).Text.Contains("<frame_end>") && rangestart != fctb.Selection.Start.iLine)
                {
                    rangestart = s;
                    rangeend = e;
                    rangetype = "";
                    return;
                }
            }
            rangestart = s;
            rangeend = e;
            rangetype = "";
            return;
        }

        private void fctb_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fctb_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (FileList != null) checkopen(FileList[0]);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Selection.SelectAll();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fctb.UndoEnabled)
                fctb.Undo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fctb.RedoEnabled)
                fctb.Redo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = undoToolStripMenuItem1.Enabled = fctb.UndoEnabled;
            redoToolStripMenuItem.Enabled = redoToolStripMenuItem1.Enabled = fctb.RedoEnabled;
            cutToolStripMenuItem.Enabled = copyToolStripMenuItem.Enabled = !fctb.Selection.IsEmpty;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fs == null)
            {
                fs = new FormSettings();
                fs.Owner = this;
                fs.vdc = this;
                fs.Show();
            }
            else
                fs.Focus();
        }

    }

    public class global
    {
        public static ObjectFile objectfile;
        public static Frame retentiveframe = new Frame();
        public static int framenumber;
    }

}