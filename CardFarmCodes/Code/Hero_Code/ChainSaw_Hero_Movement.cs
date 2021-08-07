using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChainSaw_Hero_Movement : MonoBehaviour
{
    Note_Enemy_Movement note_Eny;
    Sample_Enemy_Movement nor_Eny;
    Humidifier_Movement humi_Eny;
    ChainSaw_Hero_Atk_Area atk_Area;
    Card_Loader card_Loader;
    Animator animator;
    GameManager gameManager;
    SoundManager soundManager;
    public GameObject hp;
    hp_bar hp_Bar;
    public int health;
    public int Atk_Power;
    int cost;
    float deactive_time = 2;
    float time;
    // Start is called before the first frame update
    void Awake()
    {
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        card_Loader = GameObject.Find("GameManager").GetComponent<Card_Loader>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        atk_Area = transform.GetChild(0).GetComponent<ChainSaw_Hero_Atk_Area>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Chk_Status();
        hp_bar_pos();
        if(gameManager.isGameDone)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        try
        {
            health = card_Loader.Loaded_Info[0].health_point;
            Atk_Power = card_Loader.Loaded_Info[0].attack_point;
            gameObject.layer = 7;
        }
        catch (ArgumentOutOfRangeException) { }
    }

    private void OnDisable()
    {
        try
        {
            gameManager.obj_onTile.Remove(gameObject);
        }
        catch (NullReferenceException) { }
    }

    void Chk_Status()
    {
        if (health > 0)
        {
            if (!atk_Area.eny_On_Area)
            {
                Idle();
            }
            else
            {
                Attack();
            }
        } else
        {
            Die();
        }
    }

    void hp_bar_pos()
    {
        if(hp != null)
        {
            hp_Bar = hp.transform.GetChild(0).gameObject.GetComponent<hp_bar>();
            hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.27f, 0));
            hp_Bar.GetHeroHP(health);
        }
    }

    void Idle()
    {
        animator.SetBool("is_Atk", false);
    }

    void Attack()
    {

        animator.SetBool("is_Atk", true);
    }

    void Die()
    {
        animator.SetBool("is_Dead", true);
        gameObject.layer = 8;
        time += Time.deltaTime;
        if(deactive_time < time)
        {
            gameObject.SetActive(false);
            hp.SetActive(false);
        }
    }

    void playSound()
    {
        soundManager.playSound("chainsaw");
    }
    void Attacking()
    {
        if (atk_Area.Eny_On_Area.Count > 0)
        {
            switch (atk_Area.Eny_On_Area[0].tag)
            {
                case "Radio_Eny":
                    nor_Eny = atk_Area.Eny_On_Area[0].GetComponent<Sample_Enemy_Movement>();
                    nor_Eny.Enemy_hp -= Atk_Power;
                    break;
                case "Note_Eny":
                    note_Eny = atk_Area.Eny_On_Area[0].GetComponent<Note_Enemy_Movement>();
                    note_Eny.Enemy_hp -= Atk_Power;
                    break;
                case "Humidifier_Eny":
                    humi_Eny = atk_Area.Eny_On_Area[0].GetComponent<Humidifier_Movement>();
                    humi_Eny.health -= Atk_Power;
                    break;
            }
        }
    }
}
