using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class Conversation_Manager : MonoBehaviour
{
    public GameObject talkingObj;
    public GameObject[] UIObj;
    public GameObject Player;
    public bool isTalk = false;
    RectTransform rectTransform;
    talking_Window talking;
    int playOnlyOnce = 0;
    void Awake()
    {
        rectTransform = UIObj[0].GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(talkingObj != null && playOnlyOnce == 0) {
            playOnlyOnce++;
            UIObj[0].SetActive(true);
            rectTransform.DOAnchorPosX(20, 0.5f);
        } else if(talkingObj == null && playOnlyOnce == 1) {
            rectTransform.DOAnchorPosX(-200, 0.5f).OnComplete(() => {
                UIObj[0].SetActive(false);
            });
            playOnlyOnce--;
        }
        if(UIObj[0].activeInHierarchy == true) {
            if(Input.GetKeyDown(KeyCode.G)) {
                isTalk = true;
                StartConverSation();
            }
        }
    }

    void StartConverSation() {
        rectTransform.DOAnchorPosX(-200, 0.5f).OnComplete(() => {
            UIObj[0].SetActive(false);
        });
        talkingObj.transform.LookAt(Player.transform);
        UIObj[1].SetActive(true);
    }
}
