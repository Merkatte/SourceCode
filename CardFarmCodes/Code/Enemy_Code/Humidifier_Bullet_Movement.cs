using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humidifier_Bullet_Movement : MonoBehaviour
{

    public int Atk_Power;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            switch (collision.gameObject.tag)
            {
                case "Hero":
                    Sample_Hero_Movement hero_Movement;
                    hero_Movement = collision.gameObject.GetComponent<Sample_Hero_Movement>();
                    hero_Movement.hero_hp -= Atk_Power;
                    gameObject.SetActive(false);
                    break;
                case "ChainSaw_Hero":
                    ChainSaw_Hero_Movement chainsaw_Movement;
                    chainsaw_Movement = collision.gameObject.GetComponent<ChainSaw_Hero_Movement>();
                    chainsaw_Movement.health -= Atk_Power;
                    gameObject.SetActive(false);
                    break;
                case "Gunner_Hero":
                    Gunner_Hero_Movement gunner_Movement;
                    gunner_Movement = collision.gameObject.GetComponent<Gunner_Hero_Movement>();
                    gunner_Movement.health -= Atk_Power;
                    gameObject.SetActive(false);
                    break;
                case "Corn":
                    Corn_Movement corn_Movement
                        = collision.gameObject.GetComponent<Corn_Movement>();
                    corn_Movement.health -= Atk_Power;
                    gameObject.SetActive(false);
                    break;
                case "Watermelon":
                    Watermelon_Movement watermelon_Movement
                        = collision.gameObject.GetComponent<Watermelon_Movement>();
                    watermelon_Movement.health -= Atk_Power;
                    gameObject.SetActive(false);
                    break;
                case "HQ":
                    HeadQuarter_Movement headQuarter_Movement
                        = collision.gameObject.GetComponent<HeadQuarter_Movement>();
                    headQuarter_Movement.health -= Atk_Power;
                    gameObject.SetActive(false);
                    break;
            }
        } else if(collision.gameObject.layer == 11)
        {
            gameObject.SetActive(false);
        }
    }
}

