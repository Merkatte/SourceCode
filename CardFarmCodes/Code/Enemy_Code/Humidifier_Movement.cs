using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Humidifier_Movement : MonoBehaviour
{
    public bool Target_On_Range;
    bool moving_on_Cool;
    bool Atk_on_Cool;
    bool moving;
    bool up = true;
    public int health;
    public int atk_power;
    int value;
    int doonlyOnce;
    public int Move_Cool;
    public int Atk_Cool;
    float Move_Cool_Chk;
    float Atk_Cool_Chk;
    float Start_loc_x;
    float Start_loc_y;
    ObjectManager objectManager;
    Animator animator;
    Monster_Spawn monster_Spawn;
    Monster_Loader monster_Loader;
    // Start is called before the first frame update
    void Awake()
    {
        objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        monster_Spawn = GameObject.Find("GameManager").GetComponent<Monster_Spawn>();
        monster_Loader = GameObject.Find("GameManager").GetComponent<Monster_Loader>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        try
        {
            atk_power = monster_Loader.Loaded_Info[2].attack_point;
            health = monster_Loader.Loaded_Info[2].health_point;
            value = monster_Loader.Loaded_Info[2].value;
            gameObject.layer = 6;
            doonlyOnce = 0;
        }
        catch (ArgumentOutOfRangeException) { }
    }

    // Update is called once per frame
    void Update()
    {
        Status_Chk();
        if(moving == true)
        {
            Move_Front();
        }
    }

    void FixedUpdate()
    {
        if (Move_Cool_Chk < Move_Cool)
        {
            Move_Cool_Chk += Time.deltaTime;
            moving_on_Cool = true;
        }
        else
        {
            moving_on_Cool = false;
        }

        if (Atk_Cool_Chk < Atk_Cool)
        {
            Atk_Cool_Chk += Time.deltaTime;
            Atk_on_Cool = true;
        }
        else
        {
            Atk_on_Cool = false;
        }
    }

    void Status_Chk()
    {
        if (health > 0)
        {
            if (!Target_On_Range && moving_on_Cool)
            {
                Idle();
            }
            else if (!Target_On_Range && !moving_on_Cool)
            {
                Move();
            }
            else if (Target_On_Range && moving_on_Cool && Atk_on_Cool)
            {
                Idle();
            }
            else if (Target_On_Range && !Atk_on_Cool)
            {
                Attack();
            }
        } else
        {
            Die();
        }
    }

    void Idle()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Move", false);
    }

    void Move()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Move", true);
    }

    void Attack()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Attack", true);
        animator.SetBool("Move", false);
        Atk_Cool_Chk = 0;
        Atk_on_Cool = true;
    }

    void Die()
    {
        if (doonlyOnce == 0)
        {
            doonlyOnce++;
            gameObject.layer = 9;
            animator.SetBool("Die", true);
            monster_Spawn.Obj_isActive(gameObject);
            Invoke("Deactive", 2);
        }
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }

    void IdleEnd()
    {

    }

    void Moving()
    {
        moving = true;
        Start_loc_x = transform.position.x;
        Start_loc_y = transform.position.y;
    }

    void Move_Front()
    {
        if(Start_loc_x - 0.4f < transform.position.x)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 0.4f);
            if(Start_loc_y + 0.2f > transform.position.y && up == true)
            {
                transform.Translate(Vector2.up * Time.deltaTime * 0.4f);
                if(transform.position.y >= Start_loc_y + 0.2f)
                {
                    up = false;
                }
            } else if (up == false)
            {
                if (Start_loc_y < transform.position.y)
                {
                    transform.Translate(Vector2.down * Time.deltaTime * 0.4f);
                }
            }
        } else
        {
            transform.position = new Vector3(transform.position.x,
                Start_loc_y, -2);
            moving = false;
            MoveEnd();
        }
    }
    void MoveEnd()
    {
        Move_Cool_Chk = 0;
        moving_on_Cool = true;
        up = true;
    }

    void ShootBullet()
    {
        GameObject instance = objectManager.MakeObj("Humidifier_Bullet");
        Humidifier_Bullet_Movement bulletScript = instance.GetComponent<Humidifier_Bullet_Movement>();
        bulletScript.Atk_Power = atk_power;
        instance.transform.position = gameObject.transform.position;
    }

    void AttackEnd()
    {

        animator.SetBool("Idle", true);
        animator.SetBool("Attack", false);

    }

}
