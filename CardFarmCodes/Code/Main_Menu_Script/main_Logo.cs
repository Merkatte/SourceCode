using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class main_Logo : MonoBehaviour
{
    public GameManager managerObject;
    SoundManager soundManager;
    GameManager gameManager;
    Monster_Spawn monster_Spawn;
    RectTransform rectTransform;
    void Awake()
    {
        gameManager = managerObject.GetComponent<GameManager>();
        soundManager = managerObject.GetComponent<SoundManager>();
        monster_Spawn = managerObject.GetComponent<Monster_Spawn>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        rectTransform.DOAnchorPosY(300, 1);
        StartCoroutine(BGM_Start());
    }

    IEnumerator BGM_Start()
    {
        yield return new WaitForSeconds(1f);
        soundManager.playBGM("Intro");
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        soundManager.playSound("Start");
        soundManager.playBGM("InGame");
        gameManager.isGameStart = true;
        gameManager.isGameDone = false;
        gameManager.doOnlyOnce = 0;
        monster_Spawn.stageNum = 0;
        monster_Spawn.OnStage = 1;
        rectTransform.DOAnchorPosY(-600, 1);
        StartCoroutine(disable());
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(5f);
        monster_Spawn = managerObject.GetComponent<Monster_Spawn>();
        monster_Spawn.ReadSpawnFile();
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
