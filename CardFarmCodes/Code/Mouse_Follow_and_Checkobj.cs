using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_Follow_and_Checkobj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chk_object;
    public bool tile_chk;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }

    void FixedUpdate()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tile"))
        {

            chk_object = collision.gameObject;
            tile_chk = true;
        }
        if (collision.gameObject.layer == 7)
        {
            chk_object = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("tile"))
        {
            tile_chk = false;
            chk_object = null;
        }
        if(collision.gameObject.layer == 7)
        {
            chk_object = null;
        }
    }
}
