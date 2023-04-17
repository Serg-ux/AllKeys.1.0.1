using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Usuarios.Modelo
{
  public  class Conversor
    {
        //sirve para convertir una lista pen una tabla de datos
       public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        //coger un item a traver de un parametro
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        if (dr[column.ColumnName].ToString() != "")
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                }
            }
            return obj;
        }

    }
}
