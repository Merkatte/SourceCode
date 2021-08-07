using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Enemy_Movement : MonoBehaviour
{
    bool encounter_Hero;
    bool attacking;
    public int Enemy_hp;
    int value;
    public float attack_time;
    public int attack_power;
    float time = 0;
    float defaultpos;
    int x;
    GameObject obj;
    GameManager gameManager;
    Monster_Spawn monster_Spawn;
    Monster_Loader monster_Loader;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        monster_Spawn = GameObject.Find("GameManager").GetComponent<Monster_Spawn>();
        monster_Loader = GameObject.Find("GameManager").GetComponent<Monster_Loader>();
    }

    void Start()
    {
        defaultpos = transform.position.y;
        InvokeRepeating("random_number", 0.2f, 0.2f);
    }

    private void OnEnable()
    {
        try
        {
            encounter_Hero = false;
            attacking = false;
            attack_power = monster_Loader.Loaded_Info[0].attack_point;
            Enemy_hp = monster_Loader.Loaded_Info[0].health_point;
            value = monster_Loader.Loaded_Info[0].value;
        }
        catch (ArgumentOutOfRangeException) { }
    }

    // Update is called once per frame
    void Update()
    {
        if (encounter_Hero == false)
        {
            Enemy_RandMove();
        } else
        {
            Enemy_atkMove();
        }
        KillEnemyObj();
    }

    private void FixedUpdate()
    {

    }

    void random_number()
    {
        x = UnityEngine.Random.Range(0, 4);
    }

    void Enemy_RandMove()
    {
        switch(x)
        {
            case 0:
                transform.Translate(Vector2.left * Time.deltaTime * 0.4f);
                break;
            case 1:
                if(defaultpos + 0.4f
                    <= transform.position.y)
                {
                    transform.Translate(Vector2.left * Time.deltaTime * 0.4f);
                } else
                {
                    transform.Translate(new Vector2(-1, 1) * Time.deltaTime * 0.4f);
                }
                break;
            case 2:
                if(defaultpos - 0.4f > transform.position.y) 
                {
                    transform.Translate(Vector2.left * Time.deltaTime * 0.4f);
                } else
                {
                    transform.Translate(new Vector2(-1, -1) * Time.deltaTime * 0.4f);
                }
                break;
            case 3:
                transform.Translate(Vector2.zero);
                break;
        }
        CancelInvoke("Enemy_Randmove");
    }

    void Enemy_atkMove()
    {
        if(attacking == false)
        {
            time = Time.time;
            if (time > attack_time)
            {
                time = 0;
                attacking = true;
            }
        } else
        {
            animator.SetTrigger("Nor_Eny_Atk_Trigger");
        }
    }

    void KillEnemyObj()
    {
        if (transform.position.x <= -100)
        {
            CancelInvoke("random_number");
            gameObject.SetActive(false);
        }
        else if (Enemy_hp <= 0)
        {
            CancelInvoke("random_number");
            monster_Spawn.Obj_isActive(gameObject);
            gameManager.getGold(value);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            obj = collision.gameObject;
            encounter_Hero = true;
        } else if (collision.gameObject.layer == 12)
        {
            obj = collision.gameObject;
            encounter_Hero = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            encounter_Hero = false;
            animator.SetTrigger("Nor_Eny_Move");
            obj = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 12)
        {
            encounter_Hero = false;
            animator.SetTrigger("Nor_Eny_Move");
            obj = null;
        }
    }

    private void Attack()
    {
        try
        {
            switch(obj.gameObject.tag)
            {
                case "Hero":
                    Sample_Hero_Movement heroScript = obj.GetComponent<Sample_Hero_Movement>();
                    heroScript.hero_hp = heroScript.hero_hp - attack_power;
                    Debug.Log("공격했어요!");
                    break;
                case "ChainSaw_Hero":
                    ChainSaw_Hero_Movement chainsaw_Movement =
                        obj.GetComponent<ChainSaw_Hero_Movement>();
                    chainsaw_Movement.health -= attack_power;
                    break;
                case "Gunner_Hero":
                    Gunner_Hero_Movement gunner_Movement =
                        obj.GetComponent<Gunner_Hero_Movement>();
                    gunner_Movement.health -= attack_power;
                    break;
                case "Corn":
                    Corn_Movement cornScript = obj.GetComponent<Corn_Movement>();
                    cornScript.health = cornScript.health - attack_power;
                    break;
                case "Watermelon":
                    Watermelon_Movement watermelon_Movement = obj.GetComponent<Watermelon_Movement>();
                    watermelon_Movement.health -= attack_power;
                    break;
                case "HQ":
                    HeadQuarter_Movement headQuarter_Movement = obj.GetComponent<HeadQuarter_Movement>();
                    headQuarter_Movement.health -= attack_power;
                    break;
            }
        } catch (NullReferenceException) { }
    }
    
    void atk_End()
    {
        attacking = false;
    }
}
