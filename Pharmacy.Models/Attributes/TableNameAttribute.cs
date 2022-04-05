using System;

namespace Pharmacy.Models.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class TableNameAttribute : Attribute
    {
        private readonly string _name;

        public string Name { get { return _name; } }

        public TableNameAttribute(string tableName)
        {
            _name = tableName;
        }
    }
}