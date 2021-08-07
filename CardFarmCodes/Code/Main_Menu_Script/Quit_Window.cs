using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Quit_Window : MonoBehaviour
{
    public GameObject panel;
    Intro_Button_Panel intro_Panel;
    // Start is called before the first frame update
    private void Awake()
    {
        intro_Panel = panel.GetComponent<Intro_Button_Panel>();

    }

    private void OnEnable()
    {
        transform.DOLocalMoveY(0, 2).SetEase(Ease.OutElastic);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quit_Denied()
    {
        transform.DOLocalMoveY(-550, 1);
        intro_Panel.isQuit = false;
        Invoke("kill", (float)1.2);
    }

    void kill()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
