using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Shuffle : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    public GameObject managerObject;
    GameManager gameManager;
    SoundManager soundManager;
    RectTransform rectTransform;
    Image image;
    public List<GameObject> Cards_deck = new List<GameObject>();
    public List<GameObject> Cards_Onhand = new List<GameObject>();
    public List<GameObject> Cards_Graveyard = new List<GameObject>();
    public bool card_toGrave;
    public float cooltime;
    public bool cooling;
    bool goodtoGo;
    int doonlyOne = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        soundManager.playSound("Shuffle");
        if (cooling == false)
        {
            image.fillAmount = 0;
            ShuffleList(Cards_deck);
            //덱의 카드가 15장 이상이면
            if (Cards_deck.Count >= 5)
            {
                //손에 패가 있으면 무덤으로 보내기
                if (Cards_Onhand.Count > 0)
                {
                    card_toGrave = true;
                    for (int j = 0; j < Cards_Onhand.Count; j++)
                    {
                        Cards_Onhand[j].SendMessage("die");
                        Cards_Graveyard.Add(Cards_Onhand[j]);
                    }
                    Cards_Onhand.RemoveRange(0, Cards_Onhand.Count);//Clear도 쓸 수 있음
                }
                card_toGrave = false;
                //덱에서 5장 을 가져오기
                for (int i = 0; i < 5; i++)
                {
                    Cards_Onhand.Add(Cards_deck[i]);
                    Cards_Onhand[i].SetActive(true);
                }
                Cards_deck.RemoveRange(0, 5);

                //덱의 카드가 15장 미만이면
            }
            else
            {
                //무덤과 합치기
                for (int i = 0; i < Cards_Graveyard.Count; i++)
                {
                    Cards_deck.Add(Cards_Graveyard[i]);
                }
                Cards_Graveyard.Clear();
                //손에 패가 있으면 버리기
                if (Cards_Onhand.Count > 0)
                {
                    card_toGrave = true;
                    for (int j = 0; j < Cards_Onhand.Count; j++)
                    {
                        Cards_Onhand[j].SendMessage("die");
                        Cards_Graveyard.Add(Cards_Onhand[j]);
                    }
                    Cards_Onhand.RemoveRange(0, Cards_Onhand.Count);//Clear도 쓸 수 있음
                }
                //덱에서 5장 을 가져오기
                for (int i = 0; i < 5; i++)
                {
                    Cards_Onhand.Add(Cards_deck[i]);
                    Cards_Onhand[i].SetActive(true);
                }
                Cards_deck.RemoveRange(0, 5);

                Debug.Log("15장 미만이 되어 무덤과 합쳤습니다. : " + Cards_deck.Count);
            }
            cooling = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    void Awake()
    {
        image = gameObject.GetComponent<Image>();
        gameManager = managerObject.GetComponent<GameManager>();
        rectTransform = GetComponent<RectTransform>();
        soundManager = managerObject.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doonlyOne == 0 && gameManager.isGameStart == true)
        {
            doonlyOne++;
            rectTransform.DOAnchorPosX(-20, 1);
        } else if (doonlyOne == 1 && gameManager.isGameStart == false)
        {
            doonlyOne--;
            rectTransform.DOAnchorPosX(250, 1);
            if(Cards_Onhand.Count != 0)
            {
                for(int index = 0; index < Cards_Onhand.Count; index++)
                {
                    Cards_deck.Add(Cards_Onhand[index]);
                    Cards_Onhand[index].SetActive(false);
                }
                Cards_Onhand.Clear();
            }
            if(Cards_Graveyard.Count != 0)
            {
                for (int index = 0; index < Cards_Graveyard.Count; index++)
                {
                    Cards_deck.Add(Cards_Graveyard[index]);
                }
                Cards_Graveyard.Clear();
            }
        }
        if (cooling == true)
        {
            image.fillAmount += 1.0f / cooltime * Time.deltaTime;
            if (image.fillAmount >= 1.0f)
            {
                cooling = false;
            }
        }

        if(gameManager.isGameDone)
        {

        }
    }

    public void sendGraveYard(GameObject gameObject)
    {
        if (Cards_Onhand.Contains(gameObject))
        {
            Cards_Graveyard.Add(gameObject);
            Cards_Onhand.Remove(gameObject);
            for(int i = 0; i < Cards_Onhand.Count; i++)
            {
                Cards_Onhand[i].SendMessage("Re_Loc");
            }
        }
    }

    //피셔 예이츠 셔플
    public static void ShuffleList<T>(List<T> list) {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; index++) {
            random1 = UnityEngine.Random.Range(0, list.Count);
            random2 = UnityEngine.Random.Range(0, list.Count);

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }
    }
}
