using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Quit_panel : MonoBehaviour
{
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void to_loc()
    {
        transform.DOLocalMoveY(0, 0.5f).SetUpdate(true);
    }

    public void accept()
    {
        soundManager.playSound("button");
        Application.Quit();
    }

    public void deny()
    {
        soundManager.playSound("button");
        transform.DOLocalMoveY(-850, 0.5f).SetUpdate(true);
    }
}
