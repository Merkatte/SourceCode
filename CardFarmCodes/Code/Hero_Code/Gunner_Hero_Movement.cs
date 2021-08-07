using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gunner_Hero_Movement : MonoBehaviour
{
    public GameObject hp;
    Gunner_Hero_Atk_Area atk_Area;
    Card_Loader card_Loader;
    hp_bar hp_Bar;
    Animator animator;
    ObjectManager objectManager;
    SoundManager soundManager;
    GameManager gameManager;
    Gunner_Bullet gunner_Bullet;

    public int Atk_power;
    public int health;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        atk_Area = transform.GetChild(0).GetComponent<Gunner_Hero_Atk_Area>();
        card_Loader = GameObject.Find("GameManager").GetComponent<Card_Loader>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        try
        {
            Atk_power = card_Loader.Loaded_Info[5].attack_point;
            health = card_Loader.Loaded_Info[5].health_point;
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
        ChkStatus();
        hp_bar_pos();
        if(gameManager.isGameDone)
        {
            gameObject.SetActive(false);
        }
    }

    void ChkStatus()
    {
        if (health > 0)
        {
            if (atk_Area.Eny_on_Area.Count == 0)
            {
                Idle();
            }
            else if (atk_Area.Eny_on_Area.Count > 0)
            {
                Attack();
            }
        } else
        {
            gameObject.layer = 8;
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
    }

    void Shoot()
    {
        try
        {
            GameObject instance = objectManager.MakeObj("Gunner_Bullet");
            gunner_Bullet = instance.GetComponent<Gunner_Bullet>();
            gunner_Bullet.transform.position = transform.position + new Vector3(0.01f, 0.01f, 0);
            gunner_Bullet.target_loc = atk_Area.Eny_on_Area[0].transform.position;
            gunner_Bullet.GetAngle();
            gunner_Bullet.bullet_Damage = Atk_power;
            soundManager.playSound("Gunner_Attack");
        }
        catch (ArgumentOutOfRangeException) { }
    }

    public void reload()
    {
        soundManager.playSound("reload");
    }

    void DeActive()
    {
        gameObject.SetActive(false);
        hp.SetActive(false);
    }


}
