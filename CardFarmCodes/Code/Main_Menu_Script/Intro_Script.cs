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
        txt.DOText("�� ������ û�ִ��б� \n ĸ���� �����ο����� ���۵Ǿ����ϴ�. \n �������� ���۱��� ������ �л����� ������ �˸��ϴ�.",
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
