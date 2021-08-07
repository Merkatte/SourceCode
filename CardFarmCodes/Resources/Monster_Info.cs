using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Monster_Info
{
    [XmlAttribute("monster")]
    public int monster;

    [XmlElement("monster_name")]
    public string monster_name;

    [XmlElement("attack_point")]
    public int attack_point;

    [XmlElement("health_point")]
    public int health_point;

    [XmlElement("value")]
    public int value;
}
