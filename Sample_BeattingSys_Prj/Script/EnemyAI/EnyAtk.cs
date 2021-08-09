using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnyAtk : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            player = other.gameObject.GetComponent<Player>();
            player.PlayerHP -= 10;
        }
    }
}
