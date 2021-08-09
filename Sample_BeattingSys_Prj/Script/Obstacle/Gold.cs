using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    GameManager gameManager;
    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();    
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            gameManager.TotalGold++;
            gameObject.SetActive(false);
        }
    }
}
