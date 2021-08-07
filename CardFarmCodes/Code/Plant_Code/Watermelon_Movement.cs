using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Watermelon_Movement : MonoBehaviour
{
    GameManager gameManager;
    Card_Loader card_Loader;
    BoxCollider2D boxCollider;
    Animator animator;
    GameObject particleObject;
    ParticleSystem particle;
    SoundManager soundManager;

    bool harvest;
    public int health;
    public int value;
    public float growtime;
    public float time;
    public int growLv;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        card_Loader = GameObject.Find("GameManager").GetComponent<Card_Loader>();
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        particleObject = GameObject.Find("Coin_Particle");
        particle = particleObject.GetComponent<ParticleSystem>();

    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        try
        {
            growLv = 0;
            time = 0;
            harvest = false;
            value = card_Loader.Loaded_Info[9].attack_point;
            health = card_Loader.Loaded_Info[9].health_point;
            growtime = card_Loader.Loaded_Info[9].grow_time;
            Debug.Log("성장시간" + growtime);
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
        if (health > 0)
        {
            Grow();
            Chk_Status();
        } else
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }

    void Grow()
    {
        if(time >= growtime)
        {
            growLv++;
            time = 0;
        }
    }

    void Chk_Status()
    {
        switch (growLv)
        {
            case 1:
                animator.SetTrigger("state1");
                break;
            case 2:
                animator.SetTrigger("state2");
                break;
            case 3:
                animator.SetTrigger("state3");
                transform.GetChild(0).gameObject.SetActive(true);
                harvest = true;
                break;
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if(harvest)
        {
            gameManager.getGold(value);
            particleObject.transform.position = transform.position - new Vector3(0, 0.1f, 0);
            particle.Play();
            soundManager.playSound("Coin");
            transform.GetChild(0).gameObject.SetActive(false);
            gameObject.SetActive(false);
        } else
        {
            gameManager.Warning_text(4);
        }
    }
}
