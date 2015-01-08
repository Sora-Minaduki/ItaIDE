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
        /// 不透明度
        /// </summary>
        [System.Xml.Serialization.XmlElement("opacity")]
        public double Opacity { get; set; }

        /// <summary>
        /// 画像のパス
        /// </summary>
        [System.Xml.Serialization.XmlElement("path")]
        public string Path { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [System.Xml.Serialization.XmlElement("position")]
        public string Position { get; set; }

        /// <summary>
        /// サイズ変更方法
        /// </summary>
        [System.Xml.Serialization.XmlElement("stretch")]
        public string Stretch { get; set; }
    }
}
