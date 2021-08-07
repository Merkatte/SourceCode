using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gold_Panel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    GameManager managerScript;
    RectTransform rectTransform;

    int doonlyOne = 0;
    void Awake()
    {
        managerScript = gameManager.GetComponent<GameManager>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doonlyOne == 0 && managerScript.isGameStart == true)
        {
            doonlyOne++;
            rectTransform.DOAnchorPosX(20, 1);
        } else if(doonlyOne == 1 && managerScript.isGameStart == false)
        {
            doonlyOne--;
            rectTransform.DOAnchorPosX(-250, 1);
        }
    }
}
