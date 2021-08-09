using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class talking_Window : MonoBehaviour, IPointerDownHandler
{
    public FriendlyAI friendly;
    public GameObject TalkingObj;
    public GameObject textArea;
    public GameObject Name;
    public GameObject Pointer;
    RectTransform rectTransform;
    public Conversation_Manager manager;
    public bool secondDialogue;
    public bool thirdDialogue;
    public bool fourthDialogue;
    Text[] text = new Text[2];
    int x = 0;
    int playOnlyOnce;
    string[] Dialogue = {
        "안녕?",
        "보아하니 이곳에 온 건 처음인가보네",
        "내 이름은 바둑이야. 잘부탁해!",
        "제작자가 너를 위해서 만든 일종의 교관이지",
        "교관이라고 해봤자 막 널 굴리거나 하지는 않아",
        "그저 튜토리열 몇 가지를 알려주기만 할 뿐이야",
        "지금부터 내가 하는 말을 잘 들어야해. 알겠지?",
        "걱정할거 없어",
        "내가 말하는 것만 잘 기억하면\n이곳에서 무사히 빠져나갈 수 있을거야",
        "덤으로 내가 너의 여정에\n도움을 줄 수 있을지도 모르지",
        "그럼 첫 번째부터 얘기를 해주도록 할게",
        "일단은 이동키!",
        "W, A, S, D 키로 움직일 수 있어",
        "너무 당연한건가?",
        "하지만 이곳은\n여러가지 장애물들로 가득하니까\n조심해야할 필요가 있어",
        "다음은 점프키로 Space Bar야",
        "이것도 너무 당연한건가?",
        "마지막으로 공격키!",
        "마우스 왼쪽 버튼으로\n너를 방해하는 녀석들을\n두들겨 패줄 수 있지!",
        "하지만 조심해야해\n그 녀석들도 맞고만 있지는 않을거야",
        "왼쪽 위에 있는 체력바가 보이지?",
        "그게 다 닳게 되면 넌 기절하게 될거야",
        "그러면 뭐... 내가 널 이끌고\n다시 이곳으로 돌아오게 되겠지",
        "널 치료할 수 있는 곳이 여기밖에 없으니까",
        "그러니까 조심하라고",
        "자! 이게 끝이야\n간단하지?",
        "아까 얘기했다시피 걱정하지는 마",
        "어떤 상황에 처하더라도 내가 널 구해줄테니까",
        "그러면 탈출을 위해서 앞으로 나아가볼까?",
        "아! 맞다 저걸 깜빡했네!",
        "뭐 일단 보이는데로 골드야",
        "근데 평범한 골드는 아니고\n다음 방으로 넘어가기위한 열쇠지",
        "다 모아야만 다음 문이 열리는 방식이니까\n놓치는게 없도록 해!",
        "저길봐",
        "딱봐도 적같아 보이는 녀석이 나타났어",
        "일정 범위내에 들어가면\n녀석이 널 공격할거야",
        "물론 너도 공격할 수 있으니까\n조심해서 나아가봐",
        "여기서부터 이제 이동하는 발판이 나오기 시작해",
        "골드를 다 수집해야 문이 열리는 것도 똑같아",
        "적이 나오는 것도 똑같고",
        "...나 더이상 설명할게 없지않나?",

    };
    string[] ObjName = {
        "바둑이",
        "실러캔스",
        "아무것도 없는"
    };
    void OnEnable()
    {
        TalkingObj = manager.talkingObj;
        rectTransform = GetComponent<RectTransform>();
        text[0] = textArea.GetComponent<Text>();
        text[1] = Name.GetComponent<Text>();
        rectTransform.DOAnchorPosY(50, 0.5f);
        text[1].DOText(ObjName[0], 0.5f);
        if (x > 28 && x < 32 && secondDialogue != true)
        {
            text[0].DOText("계속해서 전진해보자!\n새로운걸 알려줘야하면 그때 알려줄게", 0.5f).OnComplete(() =>
            {
                DOVirtual.DelayedCall(1.5f, deactive);
            });
        }
        else if (x >= 32 && thirdDialogue != true)
        {
            text[0].DOText("계속해서 전진해보자!\n새로운걸 알려줘야하면 그때 알려줄게", 0.5f).OnComplete(() =>
            {
                DOVirtual.DelayedCall(1.5f, deactive);
            });
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (x >= 0 && x <= 28)
        {
            x++;
        }
        else if (x >= 29 && x <= 32)
        {
            if (secondDialogue == true)
            {
                x++;
            } else {
                deactive();
            }
        }
        else if (x >= 33 && x <= 36)
        {
            if (thirdDialogue == true)
            {
                x++;
            } else {
                deactive();
            }
        }
        else if (x >= 37 && x <= 41)
        {
            if (fourthDialogue == true)
            {
                x++;
            } else {
                deactive();
            }
        }
        else
        {
            deactive();
        }
        try
        {
            Pointer.SetActive(false);
            text[0].text = "";
            text[0].DOText(Dialogue[x - 1], 0.5f).OnComplete(() =>
            {
                Pointer.SetActive(true);
            });
        }
        catch (IndexOutOfRangeException)
        {
            deactive();
        }
    }

    void deactive(){
        manager.isTalk = false;
        rectTransform.DOAnchorPosY(-400, 0.7f).OnComplete(() => {
            friendly.following = true;
            gameObject.SetActive(false);
        });
    }
}
