using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HP_Frame : MonoBehaviour
{
    GameObject parent;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        try
        {
            gameManager.obj_onTile.Remove(gameObject);
        }
        catch (NullReferenceException) { }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
