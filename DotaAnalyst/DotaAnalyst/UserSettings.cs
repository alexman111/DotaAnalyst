using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace DotaAnalyst
{
    public class UserSettings
    {
        public string Language { get; set; }
        public bool AnimationMode { get; set; }
        public double AnimationTime { get; set; }
        public string Mode { get; set; }
        private static XmlSerializer xs;

        static UserSettings()
        {
            xs = new XmlSerializer(typeof(UserSettings));
        }
        public void SaveToFile(string Filename)
        {
            using (StreamWriter sr = new StreamWriter(Filename))
            {
                xs.Serialize(sr, this);
            }
        }
        public static string DefaultPath()
        {
            string PathToSave = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string FileName = Path.Combine(PathToSave, "allsettings.xml");
            return FileName;
        }
        public static UserSettings ReadFromFile(string Filename)
        {
            using (StreamReader sr = new StreamReader(Filename))
            {
                return xs.Deserialize(sr) as UserSettings;
            }
        }
    }
}
