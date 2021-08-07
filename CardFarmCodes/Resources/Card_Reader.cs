using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("card_collection")]
public class Card_Reader
{
    [XmlArray("cards")]
    [XmlArrayItem("card_no")]
    public List<Card_Info> cards = new List<Card_Info>();

    public static Card_Reader Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(Card_Reader));

        StringReader reader = new StringReader(_xml.text);

        Card_Reader item = serializer.Deserialize(reader) as Card_Reader;

        reader.Close();

        return item;
    }
}
