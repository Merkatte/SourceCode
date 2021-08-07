using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Loader : MonoBehaviour
{
    public const string path = "card_DB";
    Card_Reader cr;
    public List<Card_Info> Loaded_Info = new List<Card_Info>();
    void Start()
    {
        cr = Card_Reader.Load(path);
        for(int index = 0; index < cr.cards.Count; index++)
        {
            Loaded_Info.Add(cr.cards[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
