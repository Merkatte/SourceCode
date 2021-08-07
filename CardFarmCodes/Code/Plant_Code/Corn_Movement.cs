using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Corn_Movement : MonoBehaviour
{
    bool growing;
    public float growtime;
    int growLv = 1;
    float time;
    int value;
    public int health;
    public bool harvest;
    Animator animator;
    BoxCollider2D boxCollider;
    Card_Loader card_Loader;
    GameManager gameManager;
    ParticleSystem particle;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Awake()
    {
        card_Loader = GameObject.Find("GameManager").GetComponent<Card_Loader>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        animator = this.GetComponent<Animator>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        harvest = false;
        gameObject.layer = 7;
        growing = true;
        growLv = 1;
        boxCollider.size = new Vector2(0.239f, 0.269f);
        boxCollider.offset = new Vector2(0.004f, 0.137f);
        try
        {
            growtime = card_Loader.Loaded_Info[1].grow_time;
            health = card_Loader.Loaded_Info[1].health_point;
            value = card_Loader.Loaded_Info[1].attack_point;
        }
        catch (ArgumentOutOfRangeException) { }
    }

    private void OnDisable()
    {
        gameManager.obj_onTile.Remove(gameObject);
    }

    void Update()
    {
        chkGrowth();
        chkHealth();
    }
    void FixedUpdate()
    {
        if (growing == true)
        {
            time += Time.deltaTime;
        }
    }

    void chkGrowth()
    {
        if(time >= growtime)
        {
            growLv++;
            playNextAni();
            time = 0;
        }

    }

    void chkHealth()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void playNextAni()
    {
        switch(growLv)
        {
            case 2:
                animator.SetTrigger("growLv2");
                boxCollider.offset = new Vector2(0.005f, 0.286f);
                boxCollider.size = new Vector2(0.183f, 0.568f);
                break;
            case 3:
                animator.SetTrigger("growLv3");
                break;
            case 4:
                animator.SetTrigger("growLv4");
                transform.GetChild(0).gameObject.SetActive(true);
                growing = false;
                harvest = true;
                break;
        }
    }

    private void OnMouseDown()
    {
        if(harvest)
        {
            GameObject Coin_Particle = GameObject.Find("Coin_Particle");
            particle = Coin_Particle.GetComponent<ParticleSystem>();
            Coin_Particle.transform.position = transform.position;
            particle.Play();
            soundManager.playSound("Coin");
            gameManager.getGold(value);
            gameObject.SetActive(false);
        } else
        {
            gameManager.Warning_text(4);
        }
    }


}
