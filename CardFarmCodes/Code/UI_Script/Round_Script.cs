using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Round_Script : MonoBehaviour
{
    public Monster_Spawn monster_Spawn;
    GameManager gameManager;
    RectTransform rectTransform;
    Text txt;
    int doOnlyonce = 0;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gameManager = monster_Spawn.GetComponent<GameManager>();
        txt = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameStart)
        {
            if(doOnlyonce == 0)
            {
                doOnlyonce++;
                rectTransform.DOAnchorPosX(-90, 1);
            }
        }
        if(!gameManager.isGameStart)
        {
            if(doOnlyonce == 1)
            {
                doOnlyonce--;
                rectTransform.DOAnchorPosX(200, 1);
            }
        }
        txt.text = monster_Spawn.OnStage.ToString();
    }


}
