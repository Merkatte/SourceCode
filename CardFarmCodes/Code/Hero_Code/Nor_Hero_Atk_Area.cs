using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nor_Hero_Atk_Area : MonoBehaviour
{
    Sample_Hero_Movement heroScript;
    public List<GameObject> in_Area_Eny = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        heroScript = transform.parent.gameObject.GetComponent<Sample_Hero_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        EraseEmptyList();
    }

    void EraseEmptyList()
    {
        try
        {
            if (in_Area_Eny.Count > 0)
            {
                heroScript.Attacking = true;
                if (!in_Area_Eny[0].activeInHierarchy)
                {
                    in_Area_Eny.RemoveAt(0);
                }
            } else
            {
                heroScript.Attacking = false;
            }
        }
        catch (ArgumentOutOfRangeException)
        {  }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (in_Area_Eny.Contains(collision.gameObject) == false)
            {
                in_Area_Eny.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if(!in_Area_Eny.Contains(collision.gameObject))
            {
                in_Area_Eny.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (in_Area_Eny.Contains(collision.gameObject))
        {
            in_Area_Eny.Remove(collision.gameObject);
        }
    }
}
