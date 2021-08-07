using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class cards5 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Shuffle shuffled;
    public static Vector2 defaultposition;
    public bool Card_onDrag = false;
    public bool Card_onArea;
    public ObjectManager objectManager;
    public GameObject instant_Card;
    public GameObject reinforce_particle;
    Card_Loader card_Loader;
    GameManager gameManager;
    SoundManager soundManager;
    ParticleSystem particle;
    GameObject moving_instant_Card;
    Mouse_Follow_and_Checkobj chkObj;
    

    void Awake()
    {
        gameManager = objectManager.GetComponent<GameManager>();
        chkObj = GameObject.Find("Mouse_Collision").GetComponent<Mouse_Follow_and_Checkobj>();
        card_Loader = objectManager.GetComponent<Card_Loader>();
        soundManager = objectManager.GetComponent<SoundManager>();
        particle = reinforce_particle.GetComponent<ParticleSystem>();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {

        Card_onDrag = true;
        soundManager.playSound("Card_Pick");
        Vector3 card_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        card_pos.z = -2;
        moving_instant_Card = Instantiate(instant_Card, card_pos, transform.rotation);

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 card_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moving_instant_Card.transform.position = card_pos;
        Time.timeScale = 0.5f;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Time.timeScale = 1;
        Card_onDrag = false;
        if (chkObj.chk_object.layer == 7)
        {
            if (gameManager.isGoldEnough(card_Loader.Loaded_Info[2].cost))
            {
                soundManager.playSound("Power_Up");
                reinforce_particle.transform.position = chkObj.chk_object.transform.position -
                    new Vector3(0, 0.1f, 0);
                particle.Play();
                switch (chkObj.chk_object.tag)
                {
                    case "Hero":
                        Sample_Hero_Movement nor_hero;
                        nor_hero = chkObj.chk_object.GetComponent<Sample_Hero_Movement>();
                        nor_hero.Atk_Power += card_Loader.Loaded_Info[2].attack_point;
                        gameManager.Warning_text(3);
                        break;
                    case "Gunner_Hero":
                        Gunner_Hero_Movement gunner_hero;
                        gunner_hero = chkObj.chk_object.GetComponent<Gunner_Hero_Movement>();
                        gunner_hero.Atk_power += card_Loader.Loaded_Info[2].attack_point;
                        gameManager.Warning_text(3);
                        break;
                    case "ChainSaw_Hero":
                        ChainSaw_Hero_Movement chainsaw_hero;
                        chainsaw_hero = chkObj.chk_object.GetComponent<ChainSaw_Hero_Movement>();
                        chainsaw_hero.Atk_Power += card_Loader.Loaded_Info[2].attack_point;
                        gameManager.Warning_text(3);
                        break;
                }
                shuffled.sendGraveYard(gameObject);

                gameObject.SetActive(false);
                Destroy(moving_instant_Card);
            }
            else
            {
                gameManager.Warning_text(0);
                Destroy(moving_instant_Card);
            }
        }
        else
        {
            gameManager.Warning_text(5);
            Destroy(moving_instant_Card);

        }
        //카드가 사용 됬으니 어디다가 트루를 반환해서 카드 효과를 구현함

    }

    // Start is called before the first frame update

    void OnEnable()
    {
        shuffled = GameObject.Find("Shuffling").GetComponent<Shuffle>();
        int return_value = shuffled.Cards_Onhand.IndexOf(this.gameObject);
        transform.localPosition = new Vector3((return_value - 2) * 120, -700, 1);
        transform.DOLocalMoveY(-400, (float)0.5);
    }

    void OnDisable()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void die()
    {
        transform.DOLocalMoveY(-700, (float)0.5);
        Card_onArea = true;
        Invoke("OnDisable", (float)0.6);
    }
    public void Re_Loc()
    {
        int return_value = shuffled.Cards_Onhand.IndexOf(gameObject);
        transform.DOLocalMoveX((return_value - 2) * 120, 0.3f);
    }
}
