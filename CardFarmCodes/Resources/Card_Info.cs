using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;


public class Card_Info
{
    [XmlAttribute("card_no")]
    public string card_no;

    [XmlElement("card_type")]
    public string card_type;

    [XmlElement("card_name")]
    public string card_name;

    [XmlElement("card_data")]
    public string card_data;

    [XmlElement("attack_point")]
    public int attack_point;

    [XmlElement("health_point")]
    public int health_point;

    [XmlElement("cost")]
    public int cost;

    [XmlElement("grow_time")]
    public float grow_time;

    [XmlElement("attack_delay")]
    public float attack_delay;
}
