using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeadQuarter_Movement : MonoBehaviour
{
    public GameObject Object;
    SpriteRenderer spriteRender;
    GameManager gameManager;
    SoundManager soundManager;
    ObjectManager objectManager;
    hp_bar hp_Bar;
    public int health;
    public List<Sprite> hq_Image = new List<Sprite>();
    public int doOnlyOnce = 1;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = Object.GetComponent<GameManager>();
        soundManager = Object.GetComponent<SoundManager>();
        objectManager = Object.GetComponent<ObjectManager>();
        spriteRender = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameStart && doOnlyOnce == 1)
        {
            doOnlyOnce++;
            GameObject hp = objectManager.MakeObj("hp_bar");
            hp_Bar = hp.transform.GetChild(0).GetComponent<hp_bar>();
            hp.transform.position = Camera.main.WorldToScreenPoint(transform.position - new Vector3(3, -1, 0));
        }
        if (health <= 0 && doOnlyOnce == 2)
        {
            doOnlyOnce++;
            soundManager.playSound("HQ_Explode");
            soundManager.playBGM("GameOver");
            spriteRender.sprite = hq_Image[1];
            gameManager.isGameDone = true;
            gameManager.Defeat();
        }
        try
        {
            hp_Bar.GetHeroHP(health);
        }
        catch (NullReferenceException) { }
    }
}
