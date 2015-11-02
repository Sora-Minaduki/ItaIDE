using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItaIDE
{
    [System.Xml.Serialization.XmlRoot("config")]
    public class ConfigItem
    {
        /// <summary>
        /// The opacity
        /// </summary>
        [System.Xml.Serialization.XmlElement("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// The path of the image
        /// </summary>
        [System.Xml.Serialization.XmlElement("path")]
        public string Path { get; set; }

        /// <summary>
        /// The position
        /// </summary>
        [System.Xml.Serialization.XmlElement("position")]
        public string Position { get; set; }

        /// <summary>
        /// The stretch method
        /// </summary>
        [System.Xml.Serialization.XmlElement("stretch")]
        public string Stretch { get; set; }
    }
}
