using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    GameManager game;
    public int grow = 0;
    public int water = 1000;
    public int frozen;
    float x;
    int y;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }

    void timer() {
        x += Time.deltaTime;
        if((int)x != y) {
            y = (int)x;
            if(grow == 100) {

            } else if(water == 0) {

            } else {
                GrowBySeason();
            }
        }
    }

    void GrowBySeason() {
        switch(game.weather) {
            case 1:
                grow += 20;

                water -= 2;

                break;
            case 2:
                grow += 3;

                water -= 3;

                break;
            case 3:
                grow += 1;

                water -= 1;

                break;
            case 4:
                Debug.Log("겨울이므로 성장하지 않습니다.");
                break;
            default:
                Debug.Log("에러가 발생했습니다.");
                break;
        }
    }
}
