using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace VDC
{

    class DataParser
    {

        public static string PrintData(ObjectFile objectfile)
        {
            string text = writeHeader(objectfile);
            text += writeWeaponStrengthList(objectfile);
            text += writeFrames(objectfile);
            return text;
        }

        private static string writeWeaponStrengthList(ObjectFile objectfile)
        {
            string text = "";
            if (objectfile.weapon_strength_list.entries.Count > 0)
            {
                text += "\r\n\r\n<weapon_strength_list>";
                for (int i = 0; i < objectfile.weapon_strength_list.entries.Count; i++)
                {
                    text += "\r\n   entry: " + (i + 1) + " " + objectfile.weapon_strength_list.entries[i].name + "\r\n   ";
                    text = addString(text, "  dvx: ", objectfile.weapon_strength_list.entries[i].itr.dvx.ToString());
                    text = addString(text, "  dvy: ", objectfile.weapon_strength_list.entries[i].itr.dvy.ToString());
                    text = addString(text, "  fall: ", objectfile.weapon_strength_list.entries[i].itr.fall.ToString());
                    text = addString(text, "  arest: ", objectfile.weapon_strength_list.entries[i].itr.arest.ToString());
                    text = addString(text, "  vrest: ", objectfile.weapon_strength_list.entries[i].itr.vrest.ToString());
                    text = addString(text, "  bdefend: ", objectfile.weapon_strength_list.entries[i].itr.bdefend.ToString());
                    text = addString(text, "  injury: ", objectfile.weapon_strength_list.entries[i].itr.injury.ToString());
                    text = addString(text, "  effect: ", objectfile.weapon_strength_list.entries[i].itr.effect.ToString());
                }
                text += "\r\n<weapon_strength_list_end>";
            }
            return text;
        }

        private static string writeFrames(ObjectFile objectfile)
        {
            string text = "";
            for (int i = 0; i < objectfile.frames.Count; i++)
            {
                if (objectfile.frames[i].name != null)//i == 0 || (objectfile.frames[i].name != null && objectfile.frames[i-1].name == null))
                {
                    text += "\r\n";
                }
                if (objectfile.frames[i].name != null)
                {
                    text += "\r\n<frame>";
                    text = addString(text, " " + i + " ", objectfile.frames[i].name);
                    text += "\r\n ";
                    text = addString(text, "  pic: ", objectfile.frames[i].pic.ToString());
                    text = addString(text, "  state: ", objectfile.frames[i].state.ToString());
                    text = addString(text, "  wait: ", objectfile.frames[i].wait.ToString());
                    text = addString(text, "  next: ", objectfile.frames[i].next.ToString());
                    text = addString(text, "  dvx: ", objectfile.frames[i].dvx.ToString());
                    text = addString(text, "  dvy: ", objectfile.frames[i].dvy.ToString());
                    text = addString(text, "  dvz: ", objectfile.frames[i].dvz.ToString());
                    text = addString(text, "  centerx: ", objectfile.frames[i].centerx.ToString());
                    text = addString(text, "  centery: ", objectfile.frames[i].centery.ToString());
                    text = addString(text, "  hit_a: ", objectfile.frames[i].hit_a.ToString());
                    text = addString(text, "  hit_j: ", objectfile.frames[i].hit_j.ToString());
                    text = addString(text, "  hit_d: ", objectfile.frames[i].hit_d.ToString());
                    text = addString(text, "  hit_Fa: ", objectfile.frames[i].hit_Fa.ToString());
                    text = addString(text, "  hit_Ua: ", objectfile.frames[i].hit_Ua.ToString());
                    text = addString(text, "  hit_Da: ", objectfile.frames[i].hit_Da.ToString());
                    text = addString(text, "  hit_Fj: ", objectfile.frames[i].hit_Fj.ToString());
                    text = addString(text, "  hit_Uj: ", objectfile.frames[i].hit_Uj.ToString());
                    text = addString(text, "  hit_Dj: ", objectfile.frames[i].hit_Dj.ToString());
                    text = addString(text, "  hit_ja: ", objectfile.frames[i].hit_ja.ToString());
                    text = addString(text, "  mp: ", objectfile.frames[i].mp.ToString());
                    text = addString(text, "\r\n  sound: ", objectfile.frames[i].sound);
                    text += writeOpoint(objectfile.frames[i].opoint);
                    text += writeBpoint(objectfile.frames[i].bpoint);
                    text += writeCpoint(objectfile.frames[i].cpoint);
                    text += writeWpoint(objectfile.frames[i].wpoint);
                    text += writeItrs(objectfile.frames[i].itrs);
                    text += writeBdys(objectfile.frames[i].bdys);
                    text += "\r\n<frame_end>";
                }
            }
            return text;
        }

        public static string writeFrame(Frame frame)
        {
            string text = "";
            text += "<frame>";
            text = addString(text, " " + frame.number + " ", frame.name);
            text += "\r\n ";
            text = addString(text, "  pic: ", frame.pic.ToString());
            text = addString(text, "  state: ", frame.state.ToString());
            text = addString(text, "  wait: ", frame.wait.ToString());
            text = addString(text, "  next: ", frame.next.ToString());
            text = addString(text, "  dvx: ", frame.dvx.ToString());
            text = addString(text, "  dvy: ", frame.dvy.ToString());
            text = addString(text, "  dvz: ", frame.dvz.ToString());
            text = addString(text, "  centerx: ", frame.centerx.ToString());
            text = addString(text, "  centery: ", frame.centery.ToString());
            text = addString(text, "  hit_a: ", frame.hit_a.ToString());
            text = addString(text, "  hit_j: ", frame.hit_j.ToString());
            text = addString(text, "  hit_d: ", frame.hit_d.ToString());
            text = addString(text, "  hit_Fa: ", frame.hit_Fa.ToString());
            text = addString(text, "  hit_Ua: ", frame.hit_Ua.ToString());
            text = addString(text, "  hit_Da: ", frame.hit_Da.ToString());
            text = addString(text, "  hit_Fj: ", frame.hit_Fj.ToString());
            text = addString(text, "  hit_Uj: ", frame.hit_Uj.ToString());
            text = addString(text, "  hit_Dj: ", frame.hit_Dj.ToString());
            text = addString(text, "  hit_ja: ", frame.hit_ja.ToString());
            text = addString(text, "  mp: ", frame.mp.ToString());
            text = addString(text, "\r\n  sound: ", frame.sound);
            text += writeOpoint(frame.opoint);
            text += writeBpoint(frame.bpoint);
            text += writeCpoint(frame.cpoint);
            text += writeWpoint(frame.wpoint);
            text += writeItrs(frame.itrs);
            text += writeBdys(frame.bdys);
            text += "\r\n<frame_end>\r\n";
            return text;
        }

        private static string writeItrs(List<Itr> itrs)
        {
            string text = "";
            foreach (Itr itr in itrs)
            {
                if (itrs != null)
                {
                    text += "\r\n   itr:\r\n  ";
                    text = addString(text, "  kind: ", itr.kind.ToString());
                    text = addString(text, "  x: ", itr.x.ToString());
                    text = addString(text, "  y: ", itr.y.ToString());
                    text = addString(text, "  w: ", itr.w.ToString());
                    text = addString(text, "  h: ", itr.h.ToString());
                    text = addString(text, "  zwidth: ", itr.zwidth.ToString());
                    text = addString(text, "  dvx: ", itr.dvx.ToString());
                    text = addString(text, "  dvy: ", itr.dvy.ToString());
                    text = addString(text, "  fall: ", itr.fall.ToString());
                    text = addString(text, "  arest: ", itr.arest.ToString());
                    text = addString(text, "  vrest: ", itr.vrest.ToString());
                    text = addString(text, "  bdefend: ", itr.bdefend.ToString());
                    text = addString(text, "  injury: ", itr.injury.ToString());
                    text = addString(text, "\r\n    effect: ", itr.effect.ToString());
                    text = addString(text, "\r\n    catchingact: ", itr.catchingact.ToString());
                    text = addString(text, "  caughtact: ", itr.caughtact.ToString());
                    text += "\r\n   itr_end:";
                }
            }
            return text;
        }

        private static string writeBdys(List<Bdy> bdys)
        {
            string text = "";
            foreach (Bdy bdy in bdys)
            {
                if (bdys != null)
                {
                    text += "\r\n   bdy:\r\n  ";
                    text = addString(text, "  kind: ", bdy.kind.ToString());
                    text = addString(text, "  x: ", bdy.x.ToString());
                    text = addString(text, "  y: ", bdy.y.ToString());
                    text = addString(text, "  w: ", bdy.w.ToString());
                    text = addString(text, "  h: ", bdy.h.ToString());
                    text += "\r\n   bdy_end:";
                }
            }
            return text;
        }

        private static string writeOpoint(Opoint opoint)
        {
            string text = "";
            if (opoint != null)
            {
                text += "\r\n   opoint:\r\n  ";
                text = addString(text, "  kind: ", opoint.kind.ToString());
                text = addString(text, "  x: ", opoint.x.ToString());
                text = addString(text, "  y: ", opoint.y.ToString());
                text = addString(text, "  action: ", opoint.action.ToString());
                text = addString(text, "  dvx: ", opoint.dvx.ToString());
                text = addString(text, "  dvy: ", opoint.dvy.ToString());
                text = addString(text, "  dvz: ", opoint.dvz.ToString());
                text = addString(text, "  oid: ", opoint.oid.ToString());
                text = addString(text, "  facing: ", opoint.facing.ToString());
                text += "\r\n   opoint_end:";
            }
            return text;
        }

        private static string writeBpoint(Bpoint bpoint)
        {
            string text = "";
            if (bpoint != null)
            {
                text += "\r\n   bpoint:\r\n  ";
                text = addString(text, "  x: ", bpoint.x.ToString());
                text = addString(text, "  y: ", bpoint.y.ToString());
                text += "\r\n   bpoint_end:";
            }
            return text;
        }

        private static string writeCpoint(Cpoint cpoint)
        {
            string text = "";
            if (cpoint != null)
            {
                text += "\r\n   cpoint:\r\n  ";
                text = addString(text, "  kind: ", cpoint.kind.ToString());
                text = addString(text, "  x: ", cpoint.x.ToString());
                text = addString(text, "  y: ", cpoint.y.ToString());
                text = addString(text, "  cover: ", cpoint.cover.ToString());
                text = addString(text, "  injury: ", cpoint.injury.ToString());
                text = addString(text, "\r\n    vaction: ", cpoint.vaction.ToString());
                text = addString(text, "  aaction: ", cpoint.aaction.ToString());
                text = addString(text, "  jaction: ", cpoint.jaction.ToString());
                text = addString(text, "  daction: ", cpoint.daction.ToString());
                text = addString(text, "  taction: ", cpoint.taction.ToString());
                text = addString(text, "  throwvx: ", cpoint.throwvx.ToString());
                text = addString(text, "  throwvy: ", cpoint.throwvy.ToString());
                text = addString(text, "  throwvz: ", cpoint.throwvz.ToString());
                text = addString(text, "  hurtable: ", cpoint.hurtable.ToString());
                text = addString(text, "  throwinjury: ", cpoint.throwinjury.ToString());
                text = addString(text, "  decrease: ", cpoint.decrease.ToString());
                text = addString(text, "  dircontrol: ", cpoint.dircontrol.ToString());
                text = addString(text, "\r\n    fronthurtact: ", cpoint.fronthurtact.ToString());
                text = addString(text, "  backhurtact: ", cpoint.backhurtact.ToString());
                text += "\r\n   cpoint_end:";
            }
            return text;
        }

        private static string writeWpoint(Wpoint wpoint)
        {
            string text = "";
            if (wpoint != null)
            {
                text += "\r\n   wpoint:\r\n  ";
                text = addString(text, "  kind: ", wpoint.kind.ToString());
                text = addString(text, "  x: ", wpoint.x.ToString());
                text = addString(text, "  y: ", wpoint.y.ToString());
                text = addString(text, "  weaponact: ", wpoint.weaponact.ToString());
                text = addString(text, "  attacking: ", wpoint.attacking.ToString());
                text = addString(text, "  cover: ", wpoint.cover.ToString());
                text = addString(text, "  dvx: ", wpoint.dvx.ToString());
                text = addString(text, "  dvy: ", wpoint.dvy.ToString());
                text = addString(text, "  dvz: ", wpoint.dvz.ToString());
                text += "\r\n   wpoint_end:";
            }
            return text;
        }

        private static string writeHeader(ObjectFile objectfile)
        {
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            string text = "<bmp_begin>";
            text = addString(text, "\r\n         name: ", objectfile.bmp_begin.name);
            text = addString(text, "\r\n         head: ", objectfile.bmp_begin.head);
            text = addString(text, "\r\n        small: ", objectfile.bmp_begin.small);
            int i = 0;
            int j = 0;
            while (i < objectfile.bmp_begin.bmps.Count)
            {
                text = addString(text, "\r\nfile(" + j.ToString("000") + "-" + (objectfile.bmp_begin.bmps[i].row * objectfile.bmp_begin.bmps[i].col + j - 1).ToString("000") + "): ", objectfile.bmp_begin.bmps[i].path);
                text = addString(text, "  w: ", objectfile.bmp_begin.bmps[i].w.ToString());
                text = addString(text, "  h: ", objectfile.bmp_begin.bmps[i].h.ToString());
                text = addString(text, "  row: ", objectfile.bmp_begin.bmps[i].row.ToString());
                text = addString(text, "  col: ", objectfile.bmp_begin.bmps[i].col.ToString());
                j += objectfile.bmp_begin.bmps[i].row * objectfile.bmp_begin.bmps[i].col;
                i++;
            }
            text = addString(text, "\r\n  walking_frame_rate ", objectfile.bmp_begin.walking_frame_rate.ToString(nfi));
            text = addString(text, "\r\n       walking_speed ", objectfile.bmp_begin.walking_speed.ToString(nfi));
            text = addString(text, "\r\n      walking_speedz ", objectfile.bmp_begin.walking_speedz.ToString(nfi));
            text = addString(text, "\r\n  running_frame_rate ", objectfile.bmp_begin.running_frame_rate.ToString(nfi));
            text = addString(text, "\r\n       running_speed ", objectfile.bmp_begin.running_speed.ToString(nfi));
            text = addString(text, "\r\n      running_speedz ", objectfile.bmp_begin.running_speedz.ToString(nfi));
            text = addString(text, "\r\n heavy_walking_speed ", objectfile.bmp_begin.heavy_walking_speed.ToString(nfi));
            text = addString(text, "\r\nheavy_walking_speedz ", objectfile.bmp_begin.heavy_walking_speedz.ToString(nfi));
            text = addString(text, "\r\n heavy_running_speed ", objectfile.bmp_begin.heavy_running_speed.ToString(nfi));
            text = addString(text, "\r\nheavy_running_speedz ", objectfile.bmp_begin.heavy_running_speedz.ToString(nfi));
            text = addString(text, "\r\n         jump_height ", objectfile.bmp_begin.jump_height.ToString(nfi));
            text = addString(text, "\r\n       jump_distance ", objectfile.bmp_begin.jump_distance.ToString(nfi));
            text = addString(text, "\r\n      jump_distancez ", objectfile.bmp_begin.jump_distancez.ToString(nfi));
            text = addString(text, "\r\n         dash_height ", objectfile.bmp_begin.dash_height.ToString(nfi));
            text = addString(text, "\r\n       dash_distance ", objectfile.bmp_begin.dash_distance.ToString(nfi));
            text = addString(text, "\r\n      dash_distancez ", objectfile.bmp_begin.dash_distancez.ToString(nfi));
            text = addString(text, "\r\n       rowing_height ", objectfile.bmp_begin.rowing_height.ToString(nfi));
            text = addString(text, "\r\n     rowing_distance ", objectfile.bmp_begin.rowing_distance.ToString(nfi));
            text = addString(text, "\r\n          weapon_hp: ", objectfile.bmp_begin.weapon_hp.ToString(nfi));
            text = addString(text, "\r\n   weapon_drop_hurt: ", objectfile.bmp_begin.weapon_drop_hurt.ToString(nfi));
            text = addString(text, "\r\n   weapon_hit_sound: ", objectfile.bmp_begin.weapon_hit_sound);
            text = addString(text, "\r\n  weapon_drop_sound: ", objectfile.bmp_begin.weapon_drop_sound);
            text = addString(text, "\r\nweapon_broken_sound: ", objectfile.bmp_begin.weapon_broken_sound);
            text += "\r\n<bmp_end>";
            return text;
        }

        private static string addString(string text, string add, string value)
        {
            if (value != null && value != "0")
            {
                return text + add + value;
            }
            else
            {
                return text;
            }
        }

        public static ObjectFile ParseData(string text)
        {
            ObjectFile data = new ObjectFile();
            string[] words = Regex.Split(text, @"\s");
            List<string> list = words.OfType<string>().ToList();
            data.bmp_begin = getHeader(list);
            data.weapon_strength_list = getWeaponStrengthList(list);
            data.frames = getFrames(list);
            return data;
        }

        private static weapon_strength_list getWeaponStrengthList(List<string> list)
        {
            weapon_strength_list wsl = new weapon_strength_list();
            int i = list.FindIndex(0, s => new Regex("<weapon_strength_list>").Match(s).Success);
            if (i == -1) return wsl;
            int j = getInt(list, "<weapon_strength_list>", i);
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "entry:":
                        j = getInt(list, "entry:", i) - 1;
                        while (wsl.entries.Count <= j)
                        {
                            wsl.entries.Add(new entry());
                        }
                        wsl.entries[j].name = getString(list, (j + 1).ToString(), i + 1);
                        break;
                    case "dvx:":
                        wsl.entries[j].itr.dvx = getInt(list, "dvx:", i);
                        break;
                    case "dvy:":
                        wsl.entries[j].itr.dvy = getInt(list, "dvy:", i);
                        break;
                    case "fall:":
                        wsl.entries[j].itr.fall = getInt(list, "fall:", i);
                        break;
                    case "arest:":
                        wsl.entries[j].itr.arest = getInt(list, "arest:", i);
                        break;
                    case "vrest:":
                        wsl.entries[j].itr.vrest = getInt(list, "vrest:", i);
                        break;
                    case "bdefend:":
                        wsl.entries[j].itr.bdefend = getInt(list, "bdefend:", i);
                        break;
                    case "injury:":
                        wsl.entries[j].itr.injury = getInt(list, "injury:", i);
                        break;
                    case "effect:":
                        wsl.entries[j].itr.effect = getInt(list, "effect:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").Match(list[i]).Success
                            || list[i] == "<frame>")
                            return wsl;
                        break;
                }
                i++;
            }
            return wsl;
        }

        public static bmp_begin getHeader(List<string> list)
        {
            bmp_begin bmp_begin = new bmp_begin();
            bmp_begin.name = getString(list, "name:");
            bmp_begin.head = getString(list, "head:");
            bmp_begin.small = getString(list, "small:");
            int i = list.FindIndex(0, s => new Regex("file*").Match(s).Success);
            int j = 0;
            while (i > -1)
            {
                bmp_begin.bmps.Add(new bmp());
                bmp_begin.bmps[j].path = getString(list, "file*", i);
                bmp_begin.bmps[j].w = getInt(list, "w:", i);
                bmp_begin.bmps[j].h = getInt(list, "h:", i);
                bmp_begin.bmps[j].row = getInt(list, "row:", i);
                bmp_begin.bmps[j].col = getInt(list, "col:", i);
                i = list.FindIndex(i + 1, s => new Regex("file*").Match(s).Success);
                j++;
            }
            bmp_begin.walking_frame_rate = getInt(list, "walking_frame_rate");
            bmp_begin.walking_speed = getDouble(list, "walking_speed");
            bmp_begin.walking_speedz = getDouble(list, "walking_speedz");
            bmp_begin.running_frame_rate = getInt(list, "running_frame_rate");
            bmp_begin.running_speed = getDouble(list, "running_speed");
            bmp_begin.running_speedz = getDouble(list, "running_speedz");
            bmp_begin.heavy_walking_speed = getDouble(list, "heavy_walking_speed");
            bmp_begin.heavy_walking_speedz = getDouble(list, "heavy_walking_speedz");
            bmp_begin.heavy_running_speed = getDouble(list, "heavy_running_speed");
            bmp_begin.heavy_running_speedz = getDouble(list, "heavy_running_speedz");
            bmp_begin.jump_height = getDouble(list, "jump_height");
            bmp_begin.jump_distance = getDouble(list, "jump_distance");
            bmp_begin.jump_distancez = getDouble(list, "jump_distancez");
            bmp_begin.dash_height = getDouble(list, "dash_height");
            bmp_begin.dash_distance = getDouble(list, "dash_distance");
            bmp_begin.dash_distancez = getDouble(list, "dash_distancez");
            bmp_begin.rowing_height = getDouble(list, "rowing_height");
            bmp_begin.rowing_distance = getDouble(list, "rowing_distance");
            bmp_begin.weapon_hp = getInt(list, "weapon_hp");
            bmp_begin.weapon_drop_hurt = getInt(list, "weapon_drop_hurt");
            bmp_begin.weapon_hit_sound = getString(list, "weapon_hit_sound:");
            bmp_begin.weapon_drop_sound = getString(list, "weapon_drop_sound:");
            bmp_begin.weapon_broken_sound = getString(list, "weapon_broken_sound:");
            return bmp_begin;
        }

        private static List<Frame> getFrames(List<string> list)
        {
            List<Frame> frames = new List<Frame>();
            int i = list.FindIndex(0, s => new Regex("<frame>").Match(s).Success);
            int j = getInt(list, "<frame>", i);
            int itr = 0;
            int bdy = 0;
            while (i > 0 && i < list.Count)
            {
                switch (list[i])
                {
                    case "<frame>":
                        j = getInt(list, "<frame>", i);
                        while (frames.Count <= j)
                        {
                            frames.Add(new Frame());
                        }
                        itr = 0;
                        bdy = 0;
                        frames[j].name = getString(list, j.ToString(), i + 1);
                        break;
                    case "pic:":
                        frames[j].pic = getInt(list, "pic:", i);
                        break;
                    case "state:":
                        frames[j].state = getInt(list, "state:", i);
                        break;
                    case "wait:":
                        frames[j].wait = getInt(list, "wait:", i);
                        break;
                    case "next:":
                        frames[j].next = getInt(list, "next:", i);
                        break;
                    case "dvx:":
                        frames[j].dvx = getInt(list, "dvx:", i);
                        break;
                    case "dvy:":
                        frames[j].dvy = getInt(list, "dvy:", i);
                        break;
                    case "dvz:":
                        frames[j].dvz = getInt(list, "dvz:", i);
                        break;
                    case "centerx:":
                        frames[j].centerx = getInt(list, "centerx:", i);
                        break;
                    case "centery:":
                        frames[j].centery = getInt(list, "centery:", i);
                        break;
                    case "hit_a:":
                        frames[j].hit_a = getInt(list, "hit_a:", i);
                        break;
                    case "hit_j:":
                        frames[j].hit_j = getInt(list, "hit_j:", i);
                        break;
                    case "hit_d:":
                        frames[j].hit_d = getInt(list, "hit_d:", i);
                        break;
                    case "hit_Fa:":
                        frames[j].hit_Fa = getInt(list, "hit_Fa:", i);
                        break;
                    case "hit_Ua:":
                        frames[j].hit_Ua = getInt(list, "hit_Ua:", i);
                        break;
                    case "hit_Da:":
                        frames[j].hit_Da = getInt(list, "hit_Da:", i);
                        break;
                    case "hit_Fj:":
                        frames[j].hit_Fj = getInt(list, "hit_Fj:", i);
                        break;
                    case "hit_Uj:":
                        frames[j].hit_Uj = getInt(list, "hit_Uj:", i);
                        break;
                    case "hit_Dj:":
                        frames[j].hit_Dj = getInt(list, "hit_Dj:", i);
                        break;
                    case "hit_ja:":
                        frames[j].hit_ja = getInt(list, "hit_ja:", i);
                        break;
                    case "mp:":
                        frames[j].mp = getInt(list, "mp:", i);
                        break;
                    case "sound:":
                        frames[j].sound = getString(list, "sound:", i);
                        break;
                    case "opoint:":
                        frames[j].opoint = getOpoint(list, i);
                        break;
                    case "bpoint:":
                        frames[j].bpoint = getBpoint(list, i);
                        break;
                    case "cpoint:":
                        frames[j].cpoint = getCpoint(list, i);
                        break;
                    case "wpoint:":
                        frames[j].wpoint = getWpoint(list, i);
                        break;
                    case "itr:":
                        frames[j].itrs.Add(new Itr());
                        frames[j].itrs[itr] = getItr(list, i);
                        i = list.FindIndex(i, s => new Regex("itr:").Match(s).Success);
                        itr++;
                        break;
                    case "bdy:":
                        frames[j].bdys.Add(new Bdy());
                        frames[j].bdys[bdy] = getBdy(list, i);
                        i = list.FindIndex(i, s => new Regex("bdy:").Match(s).Success);
                        bdy++;
                        break;
                }
                i++;
            }
            return frames;
        }

        public static Frame getFrame(List<string> list)
        {
            Frame frame = new Frame();
            int i = 0;
            frame.number = getInt(list, "<frame>", i);
            int itr = 0;
            int bdy = 0;
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "<frame_end>":
                        return frame;
                    case "<frame>":
                        frame.name = getString(list, frame.number.ToString(), i + 1);
                        break;
                    case "pic:":
                        frame.pic = getInt(list, "pic:", i);
                        break;
                    case "state:":
                        frame.state = getInt(list, "state:", i);
                        break;
                    case "wait:":
                        frame.wait = getInt(list, "wait:", i);
                        break;
                    case "next:":
                        frame.next = getInt(list, "next:", i);
                        break;
                    case "dvx:":
                        frame.dvx = getInt(list, "dvx:", i);
                        break;
                    case "dvy:":
                        frame.dvy = getInt(list, "dvy:", i);
                        break;
                    case "dvz:":
                        frame.dvz = getInt(list, "dvz:", i);
                        break;
                    case "centerx:":
                        frame.centerx = getInt(list, "centerx:", i);
                        break;
                    case "centery:":
                        frame.centery = getInt(list, "centery:", i);
                        break;
                    case "hit_a:":
                        frame.hit_a = getInt(list, "hit_a:", i);
                        break;
                    case "hit_j:":
                        frame.hit_j = getInt(list, "hit_j:", i);
                        break;
                    case "hit_d:":
                        frame.hit_d = getInt(list, "hit_d:", i);
                        break;
                    case "hit_Fa:":
                        frame.hit_Fa = getInt(list, "hit_Fa:", i);
                        break;
                    case "hit_Ua:":
                        frame.hit_Ua = getInt(list, "hit_Ua:", i);
                        break;
                    case "hit_Da:":
                        frame.hit_Da = getInt(list, "hit_Da:", i);
                        break;
                    case "hit_Fj:":
                        frame.hit_Fj = getInt(list, "hit_Fj:", i);
                        break;
                    case "hit_Uj:":
                        frame.hit_Uj = getInt(list, "hit_Uj:", i);
                        break;
                    case "hit_Dj:":
                        frame.hit_Dj = getInt(list, "hit_Dj:", i);
                        break;
                    case "hit_ja:":
                        frame.hit_ja = getInt(list, "hit_ja:", i);
                        break;
                    case "mp:":
                        frame.mp = getInt(list, "mp:", i);
                        break;
                    case "sound:":
                        frame.sound = getString(list, "sound:", i);
                        break;
                    case "opoint:":
                        frame.opoint = getOpoint(list, i);
                        break;
                    case "bpoint:":
                        frame.bpoint = getBpoint(list, i);
                        break;
                    case "cpoint:":
                        frame.cpoint = getCpoint(list, i);
                        break;
                    case "wpoint:":
                        frame.wpoint = getWpoint(list, i);
                        break;
                    case "itr:":
                        frame.itrs.Add(new Itr());
                        frame.itrs[itr] = getItr(list, i);
                        i = list.FindIndex(i, s => new Regex("itr:").Match(s).Success);
                        itr++;
                        break;
                    case "bdy:":
                        frame.bdys.Add(new Bdy());
                        frame.bdys[bdy] = getBdy(list, i);
                        i = list.FindIndex(i, s => new Regex("bdy:").Match(s).Success);
                        bdy++;
                        break;
                }
                i++;
            }
            return frame;
        }

        private static Itr getItr(List<string> list, int i)
        {
            Itr itr = new Itr();
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "kind:":
                        itr.kind = getInt(list, "kind:", i);
                        break;
                    case "x:":
                        itr.x = getInt(list, "x:", i);
                        break;
                    case "y:":
                        itr.y = getInt(list, "y:", i);
                        break;
                    case "w:":
                        itr.w = getInt(list, "w:", i);
                        break;
                    case "h:":
                        itr.h = getInt(list, "h:", i);
                        break;
                    case "zwidth:":
                        itr.zwidth = getInt(list, "zwidth:", i);
                        break;
                    case "dvx:":
                        itr.dvx = getInt(list, "dvx:", i);
                        break;
                    case "dvy:":
                        itr.dvy = getInt(list, "dvy:", i);
                        break;
                    case "fall:":
                        itr.fall = getInt(list, "fall:", i);
                        break;
                    case "arest:":
                        itr.arest = getInt(list, "arest:", i);
                        break;
                    case "vrest:":
                        itr.vrest = getInt(list, "vrest:", i);
                        break;
                    case "bdefend:":
                        itr.bdefend = getInt(list, "bdefend:", i);
                        break;
                    case "injury:":
                        itr.injury = getInt(list, "injury:", i);
                        break;
                    case "effect:":
                        itr.effect = getInt(list, "effect:", i);
                        break;
                    case "catchingact:":
                        itr.catchingact = getInt(list, "catchingact:", i);
                        break;
                    case "caughtact:":
                        itr.caughtact = getInt(list, "caughtact:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").Match(list[i]).Success
                            || new Regex(".*point.*").Match(list[i]).Success
                            || list[i] == "bdy:")
                            return itr;
                        break;
                }
                i++;
            }
            return itr;
        }

        private static Bdy getBdy(List<string> list, int i)
        {
            Bdy bdy = new Bdy();
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "kind:":
                        bdy.kind = getInt(list, "kind:", i);
                        break;
                    case "x:":
                        bdy.x = getInt(list, "x:", i);
                        break;
                    case "y:":
                        bdy.y = getInt(list, "y:", i);
                        break;
                    case "w:":
                        bdy.w = getInt(list, "w:", i);
                        break;
                    case "h:":
                        bdy.h = getInt(list, "h:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").IsMatch(list[i])
                            || new Regex(".*point.*").IsMatch(list[i])
                            || list[i] == "itr:")
                            return bdy;
                        break;
                }
                i++;
            }
            return bdy;
        }

        private static Opoint getOpoint(List<string> list, int i)
        {
            Opoint opoint = new Opoint();
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "kind:":
                        opoint.kind = getInt(list, "kind:", i);
                        break;
                    case "x:":
                        opoint.x = getInt(list, "x:", i);
                        break;
                    case "y:":
                        opoint.y = getInt(list, "y:", i);
                        break;
                    case "action:":
                        opoint.action = getInt(list, "action:", i);
                        break;
                    case "dvx:":
                        opoint.dvx = getInt(list, "dvx:", i);
                        break;
                    case "dvy:":
                        opoint.dvy = getInt(list, "dvy:", i);
                        break;
                    case "dvz:":
                        opoint.dvz = getInt(list, "dvz:", i);
                        break;
                    case "oid:":
                        opoint.oid = getInt(list, "oid:", i);
                        break;
                    case "facing:":
                        opoint.facing = getInt(list, "facing:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").IsMatch(list[i])
                            || (new Regex(".*point.*").IsMatch(list[i]) && !new Regex("o.*").IsMatch(list[i]))
                            || list[i] == "itr:"
                            || list[i] == "bdy:")
                            return opoint;
                        break;
                }
                i++;
            }
            return opoint;
        }

        private static Bpoint getBpoint(List<string> list, int i)
        {
            Bpoint bpoint = new Bpoint();
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "x:":
                        bpoint.x = getInt(list, "x:", i);
                        break;
                    case "y:":
                        bpoint.y = getInt(list, "y:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").IsMatch(list[i])
                            || (new Regex(".*point.*").IsMatch(list[i]) && !new Regex("b.*").IsMatch(list[i]))
                            || list[i] == "itr:"
                            || list[i] == "bdy:")
                            return bpoint;
                        break;
                }
                i++;
            }
            return bpoint;
        }

        private static Cpoint getCpoint(List<string> list, int i)
        {
            Cpoint cpoint = new Cpoint();
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "kind:":
                        cpoint.kind = getInt(list, "kind:", i);
                        break;
                    case "x:":
                        cpoint.x = getInt(list, "x:", i);
                        break;
                    case "y:":
                        cpoint.y = getInt(list, "y:", i);
                        break;
                    case "cover:":
                        cpoint.cover = getInt(list, "cover:", i);
                        break;
                    case "injury:":
                        cpoint.injury = getInt(list, "injury:", i);
                        break;
                    case "vaction:":
                        cpoint.vaction = getInt(list, "vaction:", i);
                        break;
                    case "aaction:":
                        cpoint.aaction = getInt(list, "aaction:", i);
                        break;
                    case "taction:":
                        cpoint.taction = getInt(list, "taction:", i);
                        break;
                    case "jaction:":
                        cpoint.jaction = getInt(list, "jaction:", i);
                        break;
                    case "daction:":
                        cpoint.daction = getInt(list, "daction:", i);
                        break;
                    case "throwvx:":
                        cpoint.throwvx = getInt(list, "throwvx:", i);
                        break;
                    case "throwvy:":
                        cpoint.throwvy = getInt(list, "throwvy:", i);
                        break;
                    case "throwvz:":
                        cpoint.throwvz = getInt(list, "throwvz:", i);
                        break;
                    case "hurtable:":
                        cpoint.hurtable = getInt(list, "hurtable:", i);
                        break;
                    case "throwinjury:":
                        cpoint.throwinjury = getInt(list, "throwinjury:", i);
                        break;
                    case "decrease:":
                        cpoint.decrease = getInt(list, "decrease:", i);
                        break;
                    case "dircontrol:":
                        cpoint.dircontrol = getInt(list, "dircontrol:", i);
                        break;
                    case "fronthurtact:":
                        cpoint.fronthurtact = getInt(list, "fronthurtact:", i);
                        break;
                    case "backhurtact:":
                        cpoint.backhurtact = getInt(list, "backhurtact:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").IsMatch(list[i])
                            || (new Regex(".*point.*").IsMatch(list[i]) && !new Regex("c.*").IsMatch(list[i]))
                            || list[i] == "itr:"
                            || list[i] == "bdy:")
                            return cpoint;
                        break;
                }
                i++;
            }
            return cpoint;
        }

        private static Wpoint getWpoint(List<string> list, int i)
        {
            Wpoint wpoint = new Wpoint();
            while (i < list.Count)
            {
                switch (list[i])
                {
                    case "kind:":
                        wpoint.kind = getInt(list, "kind:", i);
                        break;
                    case "x:":
                        wpoint.x = getInt(list, "x:", i);
                        break;
                    case "y:":
                        wpoint.y = getInt(list, "y:", i);
                        break;
                    case "weaponact:":
                        wpoint.weaponact = getInt(list, "weaponact:", i);
                        break;
                    case "attacking:":
                        wpoint.attacking = getInt(list, "attacking:", i);
                        break;
                    case "cover:":
                        wpoint.cover = getInt(list, "cover:", i);
                        break;
                    case "dvx:":
                        wpoint.dvx = getInt(list, "dvx:", i);
                        break;
                    case "dvy:":
                        wpoint.dvy = getInt(list, "dvy:", i);
                        break;
                    case "dvz:":
                        wpoint.dvz = getInt(list, "dvz:", i);
                        break;
                    default:
                        if (new Regex(".*_end.*").IsMatch(list[i])
                            || (new Regex(".*point.*").IsMatch(list[i]) && !new Regex("w.*").IsMatch(list[i]))
                            || list[i] == "itr:"
                            || list[i] == "bdy:")
                            return wpoint;
                        break;
                }
                i++;
            }
            return wpoint;
        }

        private static string getString(List<string> list, string name)
        {
            return getString(list, name, 0);
        }

        private static string getString(List<string> list, string name, int start)
        {
            if (start < 0) return null;

            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            int pos = list.FindIndex(start, s => new Regex(name).Match(s).Success);
            if (pos > -1)
            {
                double j;
                int i = 1;
                while (pos + i < list.Count || (i == 1 && pos + i < list.Count))
                {
                    bool result = double.TryParse(list[pos + i], NumberStyles.Any, nfi, out j);
                    if (list[pos + i] != "")
                    {
                        return list[pos + i];
                    }
                    else if (result)
                    {
                        return null;
                    }
                    i++;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        private static double getDouble(List<string> list, string name)
        {
            return getDouble(list, name, 0);
        }

        private static double getDouble(List<string> list, string name, int start)
        {
            if (start < 0) return 0;

            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            int pos = list.FindIndex(start, s => new Regex(name).Match(s).Success);
            if (pos > -1)
            {
                double j;
                int i = 1;
                while (pos + i < list.Count || (i == 1 && pos + i < list.Count))
                {
                    bool result = double.TryParse(list[pos + i], NumberStyles.Any, nfi, out j);
                    if (true == result)
                    {
                        return j;
                    }
                    else if (list[pos + i] != "")
                    {
                        return 0;
                    }
                    i++;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private static int getInt(List<string> list, string name)
        {
            return getInt(list, name, 0);
        }

        private static int getInt(List<string> list, string name, int start)
        {
            if (start < 0) return 0;
            int pos = list.FindIndex(start, s => new Regex(name).Match(s).Success);
            if (pos > -1)
            {
                int j;
                int i = 1;
                while (pos + i < list.Count || (i == 1 && pos + i < list.Count))
                {
                    bool result = Int32.TryParse(list[pos + i], out j);
                    if (true == result)
                    {
                        return j;
                    }
                    else if (list[pos + i] != "")
                    {
                        return 0;
                    }
                    i++;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

    }
}