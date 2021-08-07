using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class cards1 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Shuffle shuffled;
    public static Vector2 defaultposition;
    public bool Card_onDrag = false;
    public bool Card_onArea;
    public ObjectManager objectManager;
    public GameObject instant_Card;
    Card_Loader card_Loader;
    GameManager gameManager;
    SoundManager soundManager;
    Sample_Hero_Movement hero;
    GameObject moving_instant_Card;
    Mouse_Follow_and_Checkobj chkObj;
    tile_act heron_tile;

    void Awake()
    {
        gameManager = objectManager.GetComponent<GameManager>();
        soundManager = objectManager.GetComponent<SoundManager>();
        chkObj = GameObject.Find("Mouse_Collision").GetComponent<Mouse_Follow_and_Checkobj>();
        card_Loader = objectManager.GetComponent<Card_Loader>();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {

        Card_onDrag = true;
        soundManager.playSound("Card_Pick");
        Vector3 card_pos = Input.mousePosition;
        card_pos.z = -2;
        moving_instant_Card = Instantiate(instant_Card, card_pos, transform.rotation);

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector3 card_pos = Input.mousePosition;
        card_pos.z = -2;
        moving_instant_Card.transform.position = card_pos;
        Time.timeScale = 0.5f;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Card_onDrag = false;
        Time.timeScale = 1;
        if (chkObj.tile_chk == true) {
            heron_tile = chkObj.chk_object.GetComponent<tile_act>();
            if(heron_tile.on_tile == false && gameManager.isGoldEnough(card_Loader.Loaded_Info[3].cost)) 
            {
                soundManager.playSound("Card_Put");
                GameObject instance = objectManager.MakeObj("Nor_Hero");
                Vector3 vec = new Vector3(heron_tile.transform.position.x, heron_tile.transform.position.y, -2);
                instance.transform.position = vec;
                GameObject hp = objectManager.MakeObj("hp_bar");
                hero = instance.GetComponent<Sample_Hero_Movement>();
                hero.hp_obj = hp;

                Destroy(moving_instant_Card);
                shuffled.sendGraveYard(gameObject);
                this.gameObject.SetActive(false);
            } else
            {
                Debug.Log("돈이부족해요");
                Destroy(moving_instant_Card);
            }
        } else
        {
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
    void Update() { 


                    

    }
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

