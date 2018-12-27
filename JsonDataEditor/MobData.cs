using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataEditor {
    [Serializable]
    class MobData {
        private int id;
        private String name;
        private int lv;
        private int hp;
        private int mp;
        private int exp;
        private int atk;
        private int hit;
        private int flee;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Lv { get => lv; set => lv = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Hit { get => hit; set => hit = value; }
        public int Flee { get => flee; set => flee = value; }

        public MobData(int id, string name, int lv, int hp, int mp, int exp, int atk, int hit, int flee) {
            this.id = id;
            this.name = name;
            this.lv = lv;
            this.hp = hp;
            this.mp = mp;
            this.exp = exp;
            this.atk = atk;
            this.hit = hit;
            this.flee = flee;
        }
    }
}
