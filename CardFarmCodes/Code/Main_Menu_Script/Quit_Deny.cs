using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Quit_Deny : MonoBehaviour
{
    Quit_Window quitW;
    public bool quit_Cancel;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Quit_Cancel()
    {
        quitW = transform.parent.gameObject.GetComponent<Quit_Window>();
        quitW.quit_Denied();
    }
}
