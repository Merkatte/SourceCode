using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class GameManager : MonoBehaviour
{
    gold_Script Gold_Script;
    SoundManager soundManager;
    Monster_Spawn monster_Spawn;
    ObjectManager objManager;
    public GameObject pauseMenu;
    public GameObject Warning_Panel;
    public GameObject Intro;
    public GameObject OutroObj;
    public List<GameObject> obj_onTile = new List<GameObject>();
    public bool isGameStart;
    public bool isGameDone;
    public float GameTime = 0;
    public int weather = 1;
    public int x;
    public int stage = 1;
    public int Enemy_Killed;
    public int gold_left;
    public int doOnlyOnce;
    int gold = 500;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        Intro.SetActive(true);
    }
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        monster_Spawn = GetComponent<Monster_Spawn>();
        Gold_Script = GameObject.Find("gold").GetComponent<gold_Script>();
        SeasonCheck();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        StageLv();
        chkPause();
        showGold();
    }

    private void FixedUpdate()
    {
        if(doOnlyOnce == 0)
        {
            doOnlyOnce++;
            gold = 500;
        }
    }

    void Timer() {
        GameTime += Time.deltaTime;
        if ((int)GameTime != x) {
            x = (int)GameTime;
            if (x % 10 == 0) {
                weather += 1;
                if (weather == 5) {
                    weather = 1;
                }
                SeasonCheck();
            }
        }
    }

    private void showGold()
    {
        Gold_Script.printAddedGold(gold);
    }

    public void getGold(int a)
    {
        int gold_took = a;
        goldChk(gold_took);
    }
    private void goldChk(int a)
    {
        gold = gold + a;
        gold_left = gold;
    }
    public bool isGoldEnough(int cost)
    {
        bool isEnough = countGold(cost);
        return isEnough;
    }

    private bool countGold(int cost)
    {
        if(gold - cost >= 0)
        {
            gold -= cost;
            gold_left = gold;
            return true;
        } else
        {
            Warning_text(0);
            return false;
        }
    }

    public void Warning_text(int a)
    {
        Warning_Panel.SetActive(true);
        var warning_Text = Warning_Panel.transform.GetChild(1).GetComponent<Warning_Text>();
        warning_Text.changetxt(a);
    }

    void chkPause()
    {
        if(Input.GetKeyDown("escape") && isGameStart)
        {
            Time.timeScale = 0;
            soundManager.playSound("ESC");
            pauseMenu.SetActive(true);
        }
    }

    public void Defeat()
    {
        StartCoroutine(Outro());
        for (int index = 0; index < obj_onTile.Count; index++)
        {
            obj_onTile[index].SetActive(false);
        }
        obj_onTile.Clear();
        monster_Spawn.DeActiveObj();
    }

    IEnumerator Outro()
    {
        isGameStart = false;
        yield return new WaitForSeconds(2);
        OutroObj.SetActive(true);
        yield return new WaitForSeconds(1);
    }

    public void Victory()
    {
    
    }
    void SeasonCheck() {
        switch(weather) {
            case 1:
                Spring();
                break;
            case 2:
                Summer();
                break;
            case 3:
                Fall();
                break;
            case 4:
                Winter();
                break;
        }
    }

    void Spring() {
        
    }

    void Summer() {

    }

    void Fall() {

    }

    void Winter() {

    }

    void StageLv()
    {

    }
}
