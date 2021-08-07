using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Intro_Script : MonoBehaviour
{
    Text txt;
    public bool textEftDone;
    Intro_Button_Panel parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<Intro_Button_Panel>();
        txt = this.GetComponent<Text>();
        Invoke("EffectOn", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EffectOn()
    {
        txt.DOText("본 게임은 청주대학교 \n 캡스톤 디자인용으로 제작되었습니다. \n 본게임의 저작권은 제작한 학생에게 있음을 알립니다.",
            6, true);
        Invoke("EffectOff", 8);
    }

    void EffectOff()
    {
        txt.DOFade(0, 1);
        Invoke("Deactive", 2);
    }

    void Deactive()
    {
        parent.child_Object[1].SetActive(true);
        gameObject.SetActive(false);
    }
}
