using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChainSaw_Hero_Atk_Area : MonoBehaviour
{
    public bool eny_On_Area;
    ChainSaw_Hero_Movement parent_Movement;
    public List<GameObject> Eny_On_Area = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        parent_Movement = transform.parent.gameObject.GetComponent<ChainSaw_Hero_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Eny_On_Area.Count > 0)
            {
                if (Eny_On_Area[0].activeInHierarchy == true)
                {
                    eny_On_Area = true;
                }
                else
                {
                    Eny_On_Area.RemoveAt(0);
                }
            } else if(Eny_On_Area.Count == 0)
            {
                eny_On_Area = false;
            }
        }
        catch (ArgumentOutOfRangeException) { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Eny_On_Area.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(Eny_On_Area.Contains(collision.gameObject))
        {
            try
            {
                Eny_On_Area.Remove(collision.gameObject);
            }
            catch (NullReferenceException) {
                Debug.Log("삭제할 개체 없음");
            }
        }
    }
}
