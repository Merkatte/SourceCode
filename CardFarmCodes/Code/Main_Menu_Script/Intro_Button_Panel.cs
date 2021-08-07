using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Button_Panel : MonoBehaviour
{
    public List<GameObject> child_Object = new List<GameObject>();
    public bool isQuit;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            child_Object.Add(childObject);
            Debug.Log(child_Object[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quit()
    {
        isQuit = true;
    }
}
