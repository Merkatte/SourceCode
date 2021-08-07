using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning_Text : MonoBehaviour
{
    public string textstring;
    Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = textstring;
    }

    public void changetxt(int a)
    {
        switch (a)
        {
            case 0:
                textstring = "돈이 부족해요";
                break;
            case 1:
                textstring = "적들이 왔습니다! 준비하세요!";
                break;
            case 2:
                textstring = "적들을 모두 처치했습니다. 일단은 말이죠...";
                break;
            case 3:
                textstring = "강화되었습니다!";
                break;
            case 4:
                textstring = "작물한테 아직 시간이 더 필요해요...";
                break;
            case 5:
                textstring = "영웅한테 사용해주세요!";
                break;
            case 6:
                textstring = "모든 웨이브를 클리어하셨습니다!";
                break;
        }
    }
}
