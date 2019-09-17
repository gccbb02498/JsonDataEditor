namespace JsonDataEditor.dataBase
{
    public class BaseData
    {
        protected Basetype basetype = Basetype.None;
        public Basetype BaseType { get { return BaseType; } }

        protected BaseData GetBase()
        {
            return this;
        }
    }
}