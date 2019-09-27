﻿using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace RestAPI.App_Start
{
    public class AddDefaultValues : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            IDictionary<string, object> parameterValuePairs =
            GetParameterValuePairs(apiDescription.ActionDescriptor);

            foreach (var param in operation.parameters)
            {
                var parameterValuePair = parameterValuePairs.FirstOrDefault(p => p.Key.IndexOf(param.name, StringComparison.InvariantCultureIgnoreCase) >= 0);
                param.@default = parameterValuePair.Value;
            }
        }

        private IDictionary<string, object> GetParameterValuePairs(HttpActionDescriptor actionDescriptor)
        {
            IDictionary<string, object> parameterValuePairs = new Dictionary<string, object>();

            foreach (SwaggerDefaultValue defaultValue in actionDescriptor.GetCustomAttributes<SwaggerDefaultValue>())
            {
                parameterValuePairs.Add(defaultValue.Name, defaultValue.Value);
            }

            foreach (var parameter in actionDescriptor.GetParameters())
            {
                if (!parameter.ParameterType.IsPrimitive)
                {
                    foreach (PropertyInfo property in parameter.ParameterType.GetProperties())
                    {
                        var defaultValue = GetDefaultValue(property);

                        if (defaultValue != null)
                        {
                            parameterValuePairs.Add(property.Name, defaultValue);
                        }
                    }
                }
            }

            return parameterValuePairs;
        }

        private static object GetDefaultValue(PropertyInfo property)
        {
            var customAttribute = property.GetCustomAttributes<SwaggerDefaultValue>().FirstOrDefault();

            if (customAttribute != null)
            {
                return customAttribute.Value;
            }

            return null;
        }
    }

}