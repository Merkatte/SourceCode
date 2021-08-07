using UnityEngine;
using System;
public class tile_act : MonoBehaviour
{
    Mouse_Drag mouse_drag;
    GameManager gameManager;
    public bool on_tile;
    tile_image_list tile_image;
    SpriteRenderer spriteRenderer;
    cards1 nor_spawn_card;
    void Start()
    {
        tile_image = GameObject.Find("tile").GetComponent<tile_image_list>();
        mouse_drag = GameObject.Find("Canvas").GetComponent<Mouse_Drag>(); ;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        show_HeronOn_Tile();
    }

    void show_HeronOn_Tile()
    {
        try
        {
            if (mouse_drag.card_object.CompareTag("Card_SpawnHero"))
            {
                if (mouse_drag.mouse_is_clicked == true)
                {
                    if (on_tile == true)
                    {
                        spriteRenderer.sprite = tile_image.Images[1];

                    }
                    else if (on_tile == false)
                    {
                        spriteRenderer.sprite = tile_image.Images[2];
                    }
                }
                else
                {
                    spriteRenderer.sprite = null;
                }
            } else
            {
                spriteRenderer.sprite = null;
            }
        }
        catch (UnassignedReferenceException) { }
    } 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            on_tile = true;
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            on_tile = true;
        } else if(collision.gameObject.layer == 8)
        {
            on_tile = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            on_tile = false;
        }
    }
}
