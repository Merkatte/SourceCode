using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Atk_Area : MonoBehaviour
{
    GameObject parent;
    public GameObject getObject;
    Note_Enemy_Movement parentScript;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        parentScript = parent.GetComponent<Note_Enemy_Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        { 
            parentScript.encounter_Hero = true;
            getObject = collision.gameObject;
        } else if(collision.gameObject.layer == 8)
        {
            parentScript.encounter_Hero = false;
            getObject = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            parentScript.encounter_Hero = true;
            getObject = collision.gameObject;
        }
        else if (collision.gameObject.layer == 8)
        {
            parentScript.encounter_Hero = false;
            getObject = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            parentScript.encounter_Hero = false;
            getObject = null;
        }
    }
}
