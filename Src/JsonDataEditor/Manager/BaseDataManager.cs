using JsonDataEditor.dataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JsonDataEditor.Manager
{
    public class BaseDataManager
    {
        public static BaseDataManager Instance = new BaseDataManager();
        private Dictionary<Basetype, Dictionary<int,BaseData>> Basedic;

        public BaseDataManager()
        {
            if (Instance == null)
                Instance = this;
            Basedic = new Dictionary<Basetype, Dictionary<int,BaseData>>();

            InitBaseData();
            LoadData();
        }

        private void InitBaseData()
        {
            Console.WriteLine("初始化資料庫");
            foreach (Basetype i in Enum.GetValues(typeof(Basetype)))
            {
                //Console.WriteLine(i.ToString());

                Assembly asm = Assembly.Load("JsonDataEditor");
                string classstr = i.ToString();
                Type type = Type.GetType("JsonDataEditor.dataBase." + i.ToString());
                if (type != null)
                {
                    object obj = Activator.CreateInstance(type);
                    this.Basedic.Add(i, new Dictionary<int,BaseData>());

                    Console.WriteLine(obj.GetType());
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

        public void GetBase(Basetype basetype)
        {
            Dictionary<int ,BaseData> list;
            Basedic.TryGetValue(basetype, out list);
            BaseData baseData = list.FirstOrDefault().Value;
            PropertyInfo[] inf = baseData.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in inf)
                Console.WriteLine("{0}={1}", propertyInfo.Name, propertyInfo.GetValue(baseData, null));
        }

        public void LoadData()
        {
            Console.WriteLine("Load Data");
            Dictionary<Basetype, Dictionary<int ,BaseData>> o = new Dictionary<Basetype, Dictionary<int,BaseData>>(Basedic);
            foreach (var i in o)
            {
                string path = Path.Combine(@"C:\andrew.chi\JsonDataEditor\JsonDb", i.Key.ToString());
                string json = File.ReadAllText(path + ".json");
                //T
                SkillDatas skills = JsonConvert.DeserializeObject<SkillDatas>(json);

                skills.skillDatas.ForEach(e => this.Basedic[Basetype.SkillInfo].Add(e.GetId(),e));
            }
        }
    }
}