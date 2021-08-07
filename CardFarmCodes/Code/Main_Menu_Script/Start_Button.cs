using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Start_Button : MonoBehaviour
{
    Intro_Button_Panel parent;
    Button button;
    public GameObject Fade_In;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        parent = transform.parent.GetComponent<Intro_Button_Panel>();
    }

    private void Awake()
    {
        transform.DOLocalMoveX(300, 2);
        Invoke("EffectOn", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.isQuit == true)
        {
            button.interactable = false;
        } else if(parent.isQuit == false)
        {
            button.interactable = true;
        }
    }

    void Fade_in()
    {
        Fade_In.SetActive(true);
    }

    void EffectOn()
    {
        parent.child_Object[2].SetActive(true);
    }
}
