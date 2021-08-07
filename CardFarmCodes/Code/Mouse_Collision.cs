using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Collision : MonoBehaviour
{

    // Start is called before the first frame update
    Transform trans;
    GameObject obj;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        trans.position = Input.mousePosition;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "card_place")
        {
            obj = collision.gameObject;
        }
    }
}
