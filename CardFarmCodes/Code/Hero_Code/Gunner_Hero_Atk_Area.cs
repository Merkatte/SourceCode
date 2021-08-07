using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner_Hero_Atk_Area : MonoBehaviour
{
    public List<GameObject> Eny_on_Area = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chk_Object();
    }

    void Chk_Object()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if(!Eny_on_Area.Contains(collision.gameObject))
                Eny_on_Area.Add(collision.gameObject);
        } else if(collision.gameObject.layer == 9)
        {
            if(Eny_on_Area.Contains(collision.gameObject))
                Eny_on_Area.Remove(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if (!Eny_on_Area.Contains(collision.gameObject))
                Eny_on_Area.Add(collision.gameObject);
        } else if(collision.gameObject.layer == 9)
        {
            if (Eny_on_Area.Contains(collision.gameObject))
                Eny_on_Area.Remove(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if (Eny_on_Area.Contains(collision.gameObject))
                Eny_on_Area.Remove(collision.gameObject);
        }
    }
}
