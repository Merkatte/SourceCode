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
                textstring = "���� �����ؿ�";
                break;
            case 1:
                textstring = "������ �Խ��ϴ�! �غ��ϼ���!";
                break;
            case 2:
                textstring = "������ ��� óġ�߽��ϴ�. �ϴ��� ������...";
                break;
            case 3:
                textstring = "��ȭ�Ǿ����ϴ�!";
                break;
            case 4:
                textstring = "�۹����� ���� �ð��� �� �ʿ��ؿ�...";
                break;
            case 5:
                textstring = "�������� ������ּ���!";
                break;
            case 6:
                textstring = "��� ���̺긦 Ŭ�����ϼ̽��ϴ�!";
                break;
        }
    }
}
