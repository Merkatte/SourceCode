using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    PauseMenu pauseMenu;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resume()
    {
        pauseMenu = transform.parent.gameObject.GetComponent<PauseMenu>();
        soundManager.playSound("button");
        pauseMenu.Ani_Enable();
    }
}
