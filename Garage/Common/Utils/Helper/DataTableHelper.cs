using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Garage.Common.Utils.Helper
{
    public static class DataTableHelper
    {
        // Convert List<User> to DataTable
        public static DataTable ConvertListToDataTable(List<Users> users)
        {
            DataTable dataTable = new DataTable("Users");

            // Get all properties of the 'User' class
            PropertyInfo[] properties = typeof(Users).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add columns to DataTable based on 'User' properties
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Add rows to DataTable
            foreach (Users user in users)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(user, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
