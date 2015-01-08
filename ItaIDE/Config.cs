using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItaIDE
{
    class Config
    {
        private static Config instance;

        public static Config Instance { get { return instance ?? (instance = new Config()); } }
        public double Opacity { get; set; }
        public string Path { get; set; }
        public string Position { get; set; }
        public string Stretch { get; set; }
        public string ConfigPath
        {
            get { return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"ItaIDE.config.xml"); }
        }

        private Config()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            string path = ConfigPath;

            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ConfigItem));
                ConfigItem item = (ConfigItem)serializer.Deserialize(fs);

                Opacity = item.Opacity;
                Path = item.Path;
                Position = item.Position;
                Stretch = item.Stretch;
            }
        }
    }
}
