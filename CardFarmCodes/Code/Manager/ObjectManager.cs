using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameManager gameManager;

    public GameObject Nor_EnyPrefab;
    public GameObject Note_EnyPrefab;
    public GameObject Humidifier_EnyPrefab;

    public GameObject Nor_HeroPrefab;
    public GameObject ChainSaw_HeroPrefab;
    public GameObject Gunner_HeroPrefab;

    public GameObject Corn_Prefab;
    public GameObject Watermelon_Prefab;

    public GameObject Humidifer_BulletPrefab;
    public GameObject Gunner_BulletPrefab;

    public GameObject HP_BarPrefab;



    GameObject[] Nor_Eny;
    GameObject[] Note_Eny;
    GameObject[] Humidifier_Eny;

    GameObject[] Nor_Hero;
    GameObject[] ChainSaw_Hero;
    GameObject[] Gunner_Hero;

    GameObject[] Corn;
    GameObject[] Watermelon;

    GameObject[] Humidifier_Bullet;
    GameObject[] Gunner_Bullet;

    GameObject[] Hp_Bar;

    GameObject[] targetPool;


    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        Nor_Eny = new GameObject[20];
        Note_Eny = new GameObject[20];
        Humidifier_Eny = new GameObject[10];

        Nor_Hero = new GameObject[10];
        ChainSaw_Hero = new GameObject[10];
        Gunner_Hero = new GameObject[10];

        Corn = new GameObject[10];
        Watermelon = new GameObject[10];

        Humidifier_Bullet = new GameObject[50];
        Gunner_Bullet = new GameObject[50];

        Hp_Bar = new GameObject[50];
        Generate();
    }

    void Generate() {
        //#1 Enemy
        for (int index = 0; index < Nor_Eny.Length; index++) {
            Nor_Eny[index] = Instantiate(Nor_EnyPrefab);
            Nor_Eny[index].SetActive(false);
        }

        for (int index = 0; index < Note_Eny.Length; index++) {
            Note_Eny[index] = Instantiate(Note_EnyPrefab);
            Note_Eny[index].SetActive(false);
        }

        for (int index = 0; index < Humidifier_Eny.Length; index++) {
            Humidifier_Eny[index] = Instantiate(Humidifier_EnyPrefab);
            Humidifier_Eny[index].SetActive(false);
        }

        //#2 Hero
        for (int index = 0; index < Nor_Hero.Length; index++) {
            Nor_Hero[index] = Instantiate(Nor_HeroPrefab);
            Nor_Hero[index].SetActive(false);
        }

        for (int index = 0; index < ChainSaw_Hero.Length; index++) {
            ChainSaw_Hero[index] = Instantiate(ChainSaw_HeroPrefab);
            ChainSaw_Hero[index].SetActive(false);
        }

        for (int index = 0; index < Gunner_Hero.Length; index++)
        {
            Gunner_Hero[index] = Instantiate(Gunner_HeroPrefab);
            Gunner_Hero[index].SetActive(false);
        }

        //#3 Plant
        for (int index = 0; index < Corn.Length; index++) {
            Corn[index] = Instantiate(Corn_Prefab);
            Corn[index].SetActive(false);
        }

        for (int index = 0; index < Watermelon.Length; index++)
        {
            Watermelon[index] = Instantiate(Watermelon_Prefab);
            Watermelon[index].SetActive(false);
        }

        //#4 Bullet
        for (int index = 0; index < Humidifier_Bullet.Length; index++) {
            Humidifier_Bullet[index] = Instantiate(Humidifer_BulletPrefab);
            Humidifier_Bullet[index].SetActive(false);
        }

        for (int index = 0; index < Gunner_Bullet.Length; index++)
        {
            Gunner_Bullet[index] = Instantiate(Gunner_BulletPrefab);
            Gunner_Bullet[index].SetActive(false);
        }

        //#5 hp_bar
        for (int index =0; index < Hp_Bar.Length; index++)
        {
            Hp_Bar[index] = Instantiate(HP_BarPrefab);
            Hp_Bar[index].transform.SetParent(GameObject.Find("Canvas").transform);
            Hp_Bar[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Nor_Eny":
                targetPool = Nor_Eny;
                break;
            case "Note_Eny":
                targetPool = Note_Eny;
                break;
            case "Humidifier_Eny":
                targetPool = Humidifier_Eny;
                break;
            case "Nor_Hero":
                targetPool = Nor_Hero;
                break;
            case "ChainSaw_Hero":
                targetPool = ChainSaw_Hero;
                break;
            case "Gunner_Hero":
                targetPool = Gunner_Hero;
                break;
            case "Corn":
                targetPool = Corn;
                break;
            case "Watermelon":
                targetPool = Watermelon;
                break;
            case "Humidifier_Bullet":
                targetPool = Humidifier_Bullet;
                break;
            case "Gunner_Bullet":
                targetPool = Gunner_Bullet;
                break;
            case "hp_bar":
                targetPool = Hp_Bar;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                if(targetPool[index].layer == 7 || targetPool[index].layer == 8)
                    gameManager.obj_onTile.Add(targetPool[index]);
                return targetPool[index];
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
