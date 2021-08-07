using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class End_Button : MonoBehaviour
{
    Intro_Button_Panel intro;
    public GameObject quit_Panel;
    Button button;
    public bool quit;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        intro = transform.parent.gameObject.GetComponent<Intro_Button_Panel>();
    }

    private void Awake()
    {
        transform.DOLocalMoveX(300, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(intro.isQuit == true)
        {

            button.interactable = false;
        } else if(intro.isQuit == false)
        {
            button.interactable = true;
        }
    }

    void Quit_Panel_Awake()
    {
        quit_Panel.SetActive(true);
        intro.quit();
    }
}
