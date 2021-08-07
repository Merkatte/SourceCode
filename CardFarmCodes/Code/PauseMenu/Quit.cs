using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject Quit_Panel;
    Quit_panel quit_panel;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        quit_panel = Quit_Panel.GetComponent<Quit_panel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quit()
    {
        soundManager.playSound("button");
        quit_panel.to_loc();
    }
}
