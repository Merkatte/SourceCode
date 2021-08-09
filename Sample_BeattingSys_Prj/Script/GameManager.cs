using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int TotalGold;
    public GameObject[] door;
    public GameObject whichDoor;
    public int playOnlyOnce;
    public talking_Window talking;
    public Vector3 defaultPos;
    public Player player;
    GameObject playerObj;
    public GameObject TextObj;

    public GameObject FadeInPanel;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = new Vector3(0, 1, -10);
        image = FadeInPanel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (whichDoor != null)
        {
            switch (whichDoor.name)
            {
                case "Door":
                    if (playOnlyOnce == 0)
                    {
                        playOnlyOnce++;
                        door[0].transform.DOMoveY(15, 7).OnComplete(() =>
                        {
                            door[0].SetActive(false);
                        });
                        talking.secondDialogue = true;
                    }
                    break;
                case "Door2":
                    if (TotalGold == 5 && playOnlyOnce == 1)
                    {
                        playOnlyOnce++;
                        door[1].transform.DOMoveY(15, 7).OnComplete(() =>
                        {
                            door[1].SetActive(false);
                        });
                        talking.thirdDialogue = true;
                    }
                    break;
                case "Door3":
                    if (TotalGold == 8 && playOnlyOnce == 2)
                    {
                        playOnlyOnce++;
                        door[2].transform.DOMoveY(15, 7).OnComplete(() =>
                        {
                            door[2].SetActive(false);
                        });
                        talking.fourthDialogue = true;
                    }
                    break;
                case "Door4":
                    if (TotalGold == 17 && playOnlyOnce == 3)
                    {
                        playOnlyOnce++;
                        door[3].transform.DOMoveY(30, 7).OnComplete(() =>
                        {
                            door[3].SetActive(false);
                        });
                    }
                    break;
                case "Door5":
                    if (TotalGold == 26 && playOnlyOnce == 4) {
                        playOnlyOnce++;
                        FadeInPanel.SetActive(true);
                        Color color = image.color;
                        StartCoroutine(FadeIn(color));
                    }
                    break;

            }
        }
    }

    IEnumerator FadeIn(Color color) {
        while(color.a <= 1) {
            color.a += 0.01f;
            image.color = color;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        RectTransform rect = TextObj.GetComponent<RectTransform>();
        rect.DOAnchorPosY(0, 3);
    }
    void FixedUpdate(){
        if(player.PlayerHP <= 0) {
            player.PlayerHP = 100;
            playerObj.transform.position = defaultPos;
        } 
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            playerObj = other.gameObject;
            other.gameObject.transform.position =  defaultPos;
        }
    }

    public void toStart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
