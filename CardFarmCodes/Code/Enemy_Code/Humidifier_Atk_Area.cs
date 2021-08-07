using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humidifier_Atk_Area : MonoBehaviour
{
    Humidifier_Movement parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<Humidifier_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            parent.Target_On_Range = true;
        } else if(collision.gameObject.layer == 8)
        {
            parent.Target_On_Range = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            parent.Target_On_Range = true;
        }
        if(collision.gameObject.layer == 8)
        {
            parent.Target_On_Range = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            parent.Target_On_Range = false;
        }
    }
}
