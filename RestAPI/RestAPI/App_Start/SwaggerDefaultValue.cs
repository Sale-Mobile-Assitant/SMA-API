using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.App_Start
{
    public class SwaggerDefaultValue : Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SwaggerDefaultValue(string value)
        {
            this.Value = value;
        }

        public SwaggerDefaultValue(string name, string value) : this(value)
        {
            this.Name = name;
        }
    }
}