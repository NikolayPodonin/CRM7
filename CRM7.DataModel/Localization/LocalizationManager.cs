using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace CRM7.DataModel.Localization
{  
    //чуть позже перенесем в библиотеку tools
    public static class LocalizationManager
    {
        static LocalizationManager()
        {
            //LocalizedStrings = DeserializeFromString(Properties.Resources.LocalizedStrings);
        }

        /// <summary>
        /// Локализованные строки.
        /// </summary>
        public static LocalizedStrings LocalizedStrings { get; set; }

        /// <summary>
        /// Десериализует локализованные строки из указанной строки.
        /// </summary>
        /// <returns></returns>
        public static LocalizedStrings DeserializeFromString(string localizedStrings)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(LocalizedStrings));
            using (var reader = XmlReader.Create(new StringReader(localizedStrings)))
            {
                return (LocalizedStrings)formatter.Deserialize(reader);
            }
        }

        /// <summary>
        /// Десериализует локализованные строки из указанного файла.
        /// </summary>
        /// <returns></returns>
        public static LocalizedStrings Deserialize(string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(LocalizedStrings));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (LocalizedStrings)formatter.Deserialize(fs);
            }
        }

        /// <summary>
        /// Сериализует локализованные строки в указанный файл.
        /// </summary>
        public static void Serialize(string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(LocalizedStrings));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, LocalizedStrings);
            }
        }
    }
}
