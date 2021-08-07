using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Note_Enemy_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Note_Atk_Area areaScript;
    GameManager gameManager;
    Monster_Spawn monster_Spawn;
    Monster_Loader monster_Loader;
    public bool encounter_Hero;
    bool attacking;
    public int Enemy_hp;
    public float attack_time;
    public int attack_power;
    public float move_speed;
    int value;
    float time = 0;
    void Awake()
    {
        areaScript = transform.Find("note_enemy_attack_area").gameObject.
            GetComponent<Note_Atk_Area>();
        gameManager = GameObject.Find("GameManager").
            GetComponent<GameManager>();
        monster_Spawn = GameObject.Find("GameManager").GetComponent<Monster_Spawn>();
        monster_Loader = GameObject.Find("GameManager").GetComponent<Monster_Loader>();
    }


    private void OnEnable()
    {
        try
        {
            attack_power = monster_Loader.Loaded_Info[1].attack_point;
            Enemy_hp = monster_Loader.Loaded_Info[1].health_point;
            value = monster_Loader.Loaded_Info[1].value;
        }
        catch (ArgumentOutOfRangeException) { }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            if (Enemy_hp > 0)
            {
                if (encounter_Hero == false)
                {
                    Forward();
                }
                else
                {
                    Attack();
                }
            }
            else if (Enemy_hp <= 0)
            {
                monster_Spawn.Obj_isActive(gameObject);
                gameManager.getGold(value);
                gameObject.SetActive(false);
            }
            else if (transform.position.x < -20)
            {
                gameObject.SetActive(false);
            }
        }
    }



    void Forward()
    {
        transform.position = 
            new Vector2(transform.position.x - move_speed, transform.position.y);
    }

    void Attack()
    {
        time += Time.deltaTime;
        if(time > attack_time)
        {
            FindHeroScript_Attack();
            time = 0;
        }
    }

    void FindHeroScript_Attack()
    {
        try
        {
            switch (areaScript.getObject.tag)
            {
                case "Hero":
                    Sample_Hero_Movement sample_Hero =
                        areaScript.getObject.GetComponent<Sample_Hero_Movement>();
                    sample_Hero.hero_hp = sample_Hero.hero_hp - attack_power;
                    break;
                case "ChainSaw_Hero":
                    ChainSaw_Hero_Movement chainsaw_Movement =
                        areaScript.getObject.GetComponent<ChainSaw_Hero_Movement>();
                    chainsaw_Movement.health -= attack_power;
                    break;
                case "Gunner_Hero":
                    Gunner_Hero_Movement gunner_Movement =
                        areaScript.getObject.GetComponent<Gunner_Hero_Movement>();
                    gunner_Movement.health -= attack_power;
                    break;
                case "Corn":
                    Corn_Movement cornScript =
                        areaScript.getObject.GetComponent<Corn_Movement>();
                    cornScript.health = cornScript.health - attack_power;
                    break;
                case "Watermelon":
                    Watermelon_Movement watermelon_Movement =
                        areaScript.getObject.GetComponent<Watermelon_Movement>();
                    watermelon_Movement.health -= attack_power;
                    break;
                case "HQ":
                    HeadQuarter_Movement headQuarter_Movement =
                        areaScript.getObject.GetComponent<HeadQuarter_Movement>();
                    headQuarter_Movement.health -= attack_power;
                    break;
            }
        } catch (MissingReferenceException)
        {
            encounter_Hero = false;
        }
    }
}
