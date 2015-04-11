using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDC
{

    public class ObjectFile
    {
        public bmp_begin bmp_begin = new bmp_begin();
        public weapon_strength_list weapon_strength_list = new weapon_strength_list();
        public List<Frame> frames = new List<Frame>(400);
    }

    public class bmp_begin
    {
        public string name;
        public string head;
        public string small;
        public List<bmp> bmps = new List<bmp>(10);
        public int walking_frame_rate;
        public double walking_speed;
        public double walking_speedz;
        public int running_frame_rate;
        public double running_speed;
        public double running_speedz;
        public double heavy_walking_speed;
        public double heavy_walking_speedz;
        public double heavy_running_speed;
        public double heavy_running_speedz;
        public double jump_height;
        public double jump_distance;
        public double jump_distancez;
        public double dash_height;
        public double dash_distance;
        public double dash_distancez;
        public double rowing_height;
        public double rowing_distance;
        public int weapon_hp;
        public int weapon_drop_hurt;
        public string weapon_hit_sound;
        public string weapon_drop_sound;
        public string weapon_broken_sound;
    }

    public class bmp
    {
        public string path;
        public int w;
        public int h;
        public int row;
        public int col;
    }

    public class weapon_strength_list
    {
        public List<entry> entries = new List<entry>(4);
    }

    public class entry
    {
        public string name;
        public Itr itr = new Itr();
    }

    public class Frame
    {
        public int number;
        public string name;
        public int pic;
        public int state;
        public int wait;
        public int next;
        public int dvx;
        public int dvy;
        public int dvz;
        public int centerx;
        public int centery;
        public int hit_a;
        public int hit_d;
        public int hit_j;
        public int hit_Fa;
        public int hit_Ua;
        public int hit_Da;
        public int hit_Fj;
        public int hit_Uj;
        public int hit_Dj;
        public int hit_ja;
        public int mp;
        public string sound;
        public Opoint opoint = null;
        public Bpoint bpoint = null;
        public Cpoint cpoint = null;
        public Wpoint wpoint = null;
        public List<Itr> itrs = new List<Itr>(3);
        public List<Bdy> bdys = new List<Bdy>(3);
    }

    public class Opoint
    {
        public int kind;
        public int x;
        public int y;
        public int action;
        public int dvx;
        public int dvy;
        public int dvz;
        public int oid;
        public int facing;
    }

    public class Bpoint
    {
        public int x;
        public int y;
    }

    public class Cpoint
    {
        public int kind;
        public int x;
        public int y;
        public int cover;
        public int injury;
        public int vaction;
        public int aaction;
        public int taction;
        public int jaction;
        public int daction;
        public int throwvx;
        public int throwvy;
        public int throwvz;
        public int hurtable;
        public int throwinjury;
        public int decrease;
        public int dircontrol;
        public int fronthurtact;
        public int backhurtact;
    }

    public class Wpoint
    {
        public int kind;
        public int x;
        public int y;
        public int weaponact;
        public int attacking;
        public int cover;
        public int dvx;
        public int dvy;
        public int dvz;
    }

    public class Itr
    {
        public int kind;
        public int x;
        public int y;
        public int w;
        public int h;
        public int zwidth;
        public int dvx;
        public int dvy;
        public int fall;
        public int arest;
        public int vrest;
        public int bdefend;
        public int injury;
        public int effect;
        public int catchingact;
        public int caughtact;
    }

    public class Bdy
    {
        public int kind;
        public int x;
        public int y;
        public int w;
        public int h;
    }

    public class Spawn
    {
        public int id;
        public int x;
        public int hp;
        public int times;
        public int reserve;
        public int join;
        public int join_reserve;
        public int act;
        public double ratio;
        public int role;
    }

    public class Phase
    {
        public int bound;
        public string music;
        public Spawn[] spawns = new Spawn[60];
        public int when_clear_goto_phase;
    }

    public class Stage
    {
        public int phase_count;
        public Phase[] phases = new Phase[100];
    }

    public class Background
    {
        public int bg_width;
        public int bg_zwidth1;
        public int bg_zwidth2;
        public int perspective1;
        public int perspective2;
        public int shadow1;
        public int shadow2;
        public int layer_count;
        public string[] layer_bmps = new string[30];
        public string shadow_bmp;
        public string name;
        public int[] transparency = new int[30];
        public int[] layer_width = new int[30];
        public int[] layer_x = new int[30];
        public int[] layer_y = new int[30];
        public int[] layer_height = new int[30];
    }

}
