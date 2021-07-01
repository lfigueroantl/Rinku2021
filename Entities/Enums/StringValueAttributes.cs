using System;

namespace Entities.Enums
{
    public class StringValueAttribute : Attribute
    {
        private string value;

        public StringValueAttribute(string value)
        {
            this.value = value;
        }

        public string Value { get { return value; } }
    }
}
