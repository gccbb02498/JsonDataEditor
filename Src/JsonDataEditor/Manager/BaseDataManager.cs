using JsonDataEditor.dataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace JsonDataEditor.Manager
{
    public class BaseDataManager
    {
        public static BaseDataManager Instance=new BaseDataManager();
        private Dictionary<Basetype, BaseData> Basedic;

        public BaseDataManager()
        {
            if (Instance == null)
                Instance = this;
            Basedic = new Dictionary<Basetype, BaseData>();
            
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
                    this.Basedic.Add(i, obj as BaseData);
                    
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
            BaseData a;
            Basedic.TryGetValue(basetype, out a);
            PropertyInfo[] inf = a.GetType().GetProperties();
            foreach(PropertyInfo propertyInfo in inf)
                Console.WriteLine("{0}={1}", propertyInfo.Name, propertyInfo.GetValue(a, null));
        }

        public void LoadData()
        {
            Console.WriteLine("Load Data");
            foreach (var i in Basedic)
            {
                string path =  Path.Combine(@"C:\andrew.chi\JsonDataEditor\JsonDb", i.Key.ToString());
                string json = File.ReadAllText(path+".json");
                //T
                object skills = JsonConvert.DeserializeObject(json);
                
                Console.WriteLine(skills.ToString());
            }
        }
    }
}