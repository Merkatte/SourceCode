using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnG : MonoBehaviour
{
    public GameObject GuidePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) {
            GuidePanel.SetActive(true);
        }    
    }

}
