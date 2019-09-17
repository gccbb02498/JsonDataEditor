using JsonDataEditor.dataBase;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace JsonDataEditor.Manager
{
    public class BaseDataManager
    {
        public static BaseDataManager Instance;
        private Dictionary<Basetype, BaseData> Basedic;

        public BaseDataManager()
        {
            if (Instance == null)
                Instance = this;
            Basedic = new Dictionary<Basetype, BaseData>();
            InitBaseData();
            GetBase();
        }

        private void InitBaseData()
        {
            foreach (Basetype i in Enum.GetValues(typeof(Basetype)))
            {
                //Console.WriteLine(i.ToString());

                Assembly asm = Assembly.Load("JsonDataEditor");
                string classstr = i.ToString();
                Type type = Type.GetType("JsonDataEditor.dataBase." + i.ToString());
                if (type != null)
                {
                    object obj = Activator.CreateInstance(type);
                    this.Basedic.Add(i, obj as BaseData);
                }
                //{
                Console.WriteLine(i.ToString());
                //}
                //else
                //{
                //}
                //            Basedic.Add(Basetype.Mob.ToString,class)
            }
        }

        public void GetBase()
        {
            foreach (Basetype i in Enum.GetValues(typeof(Basetype)))
            {
                this.Basedic.TryGetValue(i, out BaseData baseData);
                if (baseData != null)
                    Console.WriteLine(baseData.ToString());
            }
        }

        public void LoadData()
        {
            foreach(var i in Basedic)
            {
                //base
            }
        }
    }
}