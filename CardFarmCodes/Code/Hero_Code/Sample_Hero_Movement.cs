using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Hero_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public int hero_hp;
    public int Atk_Power;
    public bool Attacking;
    bool died;
    float dead_Time;

    public GameObject hp_obj;
    Animator animator;
    Nor_Hero_Atk_Area areaScript;
    Card_Loader card_Loader;
    ObjectManager objectManager;
    SoundManager soundManager;
    GameManager gameManager;
    hp_bar hp_Bar;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        card_Loader = GameObject.Find("GameManager").GetComponent<Card_Loader>();
        objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        animator = gameObject.GetComponent<Animator>();
        areaScript = transform.GetChild(0).gameObject.
            GetComponent<Nor_Hero_Atk_Area>();
    }

    void OnEnable()
    {
        try
        {
            hero_hp = card_Loader.Loaded_Info[3].health_point;
            Atk_Power = card_Loader.Loaded_Info[3].attack_point;
            gameObject.layer = 7;
        }
        catch (ArgumentOutOfRangeException) { }
    }

    private void OnDisable()
    {
        gameManager.obj_onTile.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ChkHealth();
        Hero_AtkMove();
        if (hp_obj != null)
        {
            hp_bar_pos();
        }
        if(gameManager.isGameDone)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (died == true)
        {
            dead_Time += Time.deltaTime;
            float died_time = 1f;
            if (dead_Time > died_time)
            {
                dead_Time = 0;
                died = false;
                hp_obj.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    void ChkHealth()
    {
        if (hero_hp <= 0)
        {
            animator.SetBool("Die", true);
            float time = Time.deltaTime;
            gameObject.layer = 8;
        }
    }

    void hp_bar_pos()
    {
        hp_obj.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.27f, 0));
        hp_Bar = hp_obj.transform.GetChild(0).gameObject.GetComponent<hp_bar>();
        hp_Bar.GetHeroHP(hero_hp);
    }

    void Die()
    {
        died = true;
    }

    public void Hero_AtkMove()
    {
        try
        {
            if (Attacking == true && areaScript.in_Area_Eny.Count > 0)
            {
                animator.SetBool("Attack", true);
            } else
            {
                animator.SetBool("Attack", false);
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }
    }

    void Attack()
    {
        soundManager.playSound("Nor_Attack");
        try
        {
            switch (areaScript.in_Area_Eny[0].tag)
            {
                case "Radio_Eny":
                    if (areaScript.in_Area_Eny[0] != null)
                    {
                        Sample_Enemy_Movement radioScript;
                        radioScript = areaScript.in_Area_Eny[0].GetComponent<Sample_Enemy_Movement>();
                        radioScript.Enemy_hp = radioScript.Enemy_hp - Atk_Power;
                        Debug.Log("라디오 공격");
                    }
                    break;
                case "Note_Eny":
                    if (areaScript.in_Area_Eny[0] != null)
                    {
                        Note_Enemy_Movement noteScript;
                        noteScript = areaScript.in_Area_Eny[0].GetComponent<Note_Enemy_Movement>();
                        noteScript.Enemy_hp = noteScript.Enemy_hp - Atk_Power;
                        Debug.Log("음표 공격");
                    }
                    break;
                case "Humidifier_Eny":
                    if (areaScript.in_Area_Eny[0] != null)
                    {
                        Humidifier_Movement humiScript;
                        humiScript = areaScript.in_Area_Eny[0].GetComponent<Humidifier_Movement>();
                        humiScript.health = humiScript.health - Atk_Power;
                        Debug.Log("가습기 공격");
                    }
                    break;
            }
        }
        catch (NullReferenceException)
        {

        }
        catch (ArgumentOutOfRangeException)
        {

        }
    }
}
