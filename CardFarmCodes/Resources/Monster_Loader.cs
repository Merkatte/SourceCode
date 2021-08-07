using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Loader : MonoBehaviour
{
    public const string path = "monster_DB";
    Monster_Reader mr;
    public List<Monster_Info> Loaded_Info = new List<Monster_Info>();
    void Start()
    {
        mr = Monster_Reader.Load(path);
        for (int index = 0; index < mr.monsters.Count; index++)
        {
            Loaded_Info.Add(mr.monsters[index]);
        }
    }
}
