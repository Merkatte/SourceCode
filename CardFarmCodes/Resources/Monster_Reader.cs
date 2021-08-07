using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("monster_collection")]
public class Monster_Reader
{
    [XmlArray("monsters")]
    [XmlArrayItem("monster")]
    public List<Monster_Info> monsters = new List<Monster_Info>();

    public static Monster_Reader Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(Monster_Reader));

        StringReader reader = new StringReader(_xml.text);

        Monster_Reader item = serializer.Deserialize(reader) as Monster_Reader;

        reader.Close();

        return item;
    }
}
