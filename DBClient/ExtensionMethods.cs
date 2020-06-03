using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DBClient.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string GetPluralForm(this String str)
        {
            if (str.EndsWith("y"))
                str = str.Remove(str.Length - 1) + "ie";
            str += 's';
            return str;
        }

        public static DataTable ToDataTable<T>(this List<T> list)
        {
            var dt = list.GetDataTableTemplate();
            list.FillDataTable(dt);
            return dt;
        }

        public static DataTable GetDataTableTemplate<T>(this List<T> list)
        {
            DataTable dataTable = new DataTable();
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propsToShow = Props
                .Where(p => p.GetCustomAttribute<DisplayNameAttribute>(false) != null)
                .ToArray();
            DataColumn instances = new DataColumn("Instance", typeof(T))
            {
                ColumnMapping = MappingType.Hidden
            };
            dataTable.Columns.Add(instances);
            foreach (PropertyInfo prop in propsToShow)
            {
                var dnAttr = prop.GetCustomAttribute<DisplayNameAttribute>(false);
                if (dnAttr != null)
                {
                    var type = (prop.PropertyType.IsGenericType
                        && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                            ? Nullable.GetUnderlyingType(prop.PropertyType)
                            : prop.PropertyType);
                    dataTable.Columns.Add(dnAttr.DisplayName, type);
                }
            }
            return dataTable;
        }

        public static void FillDataTable<T>(this List<T> list, DataTable dataTable)
        {
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propsToShow = Props
                .Where(p => p.GetCustomAttribute<DisplayNameAttribute>(false) != null)
                .ToArray();
            foreach (T item in list)
            {
                var values = new object[propsToShow.Length + 1];
                values[0] = item;
                for (int i = 1; i < propsToShow.Length + 1; i++)
                {
                    values[i] = propsToShow[i - 1].GetValue(item, null);
                }
                try
                {
                    dataTable.Rows.Add(values);
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }
        }
    }
}
