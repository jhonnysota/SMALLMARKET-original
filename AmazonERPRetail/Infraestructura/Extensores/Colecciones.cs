using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Infraestructura.Extensores
{
    public static class Colecciones
    {

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            //PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            //DataTable table = new DataTable();
            
            //for (int i = 0; i < props.Count; i++)
            //{
            //    PropertyDescriptor prop = props[i];
            //    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);//prop.PropertyType);
            //}

            //object[] values = new object[props.Count];
            
            //foreach (T item in data)
            //{
            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        values[i] = props[i].GetValue(item);
            //    }
            //    table.Rows.Add(values);
            //}
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static T CopiarEntidad<T>(T Origen)
        {
            // Verificamos que sea serializable antes de hacer la copia            
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("La clase " + typeof(T).ToString() + " no es serializable");
            }

            // En caso de ser nulo el objeto, se devuelve tal cual
            if (Object.ReferenceEquals(Origen, null))
            {
                return default(T);
            }

            //Creamos un stream en memoria            
            IFormatter iFormatter = new BinaryFormatter();
            Stream oStream = new MemoryStream();

            using (oStream)
            {
                try
                {
                    iFormatter.Serialize(oStream, Origen);
                    oStream.Seek(0, SeekOrigin.Begin);
                    //Deserializamos la porción de memoria en el nuevo objeto                
                    return (T)iFormatter.Deserialize(oStream);
                }
                catch (SerializationException ex)
                {
                    throw new ArgumentException(ex.Message, ex);
                }
                catch
                {
                    throw;
                }
            }
        }

    }
}
