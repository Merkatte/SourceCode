using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    string[] stage;
    public string[] enemyObjs;
    public List<GameObject> chk_Obj = new List<GameObject>();
    public List<GameObject> point = new List<GameObject>();
    public List<SpawnStructure> spawnList = new List<SpawnStructure>();

    GameObject instance;
    GameManager gameManager;


    float time;
    float Spawn_Time;
    int enemyNum;
    int enyPos;
    public int stageNum = 0;
    public int OnStage = 1;
    bool isStart;
    public float waiting_Time;
    public bool Rdy_Spawn;
    public int spawnIndex;
    ObjectManager objectManager;
    SoundManager soundManager;

    private void Awake()
    {
        gameManager = this.GetComponent<GameManager>();
        objectManager = this.GetComponent<ObjectManager>();
        soundManager = this.GetComponent<SoundManager>();
        enemyObjs = new string[] { "Nor_Eny", "Note_Eny", "Humidifier_Eny" };
        stage = new string[] { "stage_0", "stage_1", "stage_2", "stage_3"};
    }

    // Update is called once per frame

    public void ReadSpawnFile()
    {
        // 변수 초기화
        spawnList.Clear();
        spawnIndex = 0;

        // 리스폰 파일 읽기
        TextAsset textFile = Resources.Load(stage[stageNum]) as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);
        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
                break;

            SpawnStructure spawnData = new SpawnStructure();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.Enytype = line.Split(',')[1];
            spawnData.point = int.Parse(line.Split(',')[2]);
            spawnList.Add(spawnData);
        }
        stringReader.Close();
        Rdy_Spawn = true;
        gameManager.Warning_text(1);
        soundManager.playSound("roundStart");
    }
    void Update()
    {
        if (gameManager.isGameStart == true)
        {

            time = time + Time.deltaTime;
            if (Rdy_Spawn == true && time > spawnList[spawnIndex].delay)
            {
                Stage_Chk();
            }
        } else
        {
            stageNum = 0;
            OnStage = 1;
            spawnList.Clear();
            spawnIndex = 0;

        }
    }

    private void FixedUpdate()
    {

    }



    void Stage_Chk()
    {
        switch (gameManager.stage)
        {
            case 1:
                if (Rdy_Spawn == true)
                {
                    Stage_1();
                }
                break;
            case 2:
                Stage_2();
                break;
            case 3:
                Stage_3();
                break;
            case 4:
                Stage_4();
                break;
        }
    }

    void Stage_1()
    {
        if (gameManager.isGameDone == false)
        {
            switch (spawnList[spawnIndex].Enytype)
            {
                case "Nor":
                    enemyNum = 0;
                    break;
                case "Note":
                    enemyNum = 1;
                    break;
                case "Humi":
                    enemyNum = 2;
                    break;
            }
            instance = objectManager.MakeObj(enemyObjs[enemyNum]);
            chk_Obj.Add(instance);
            enyPos = spawnList[spawnIndex].point;
            instance.transform.position = point[enyPos].transform.position;
            spawnIndex++;
            if (spawnIndex == spawnList.Count)
            {
                Rdy_Spawn = false;
                spawnIndex = 0;
                return;
            }
            time = 0;
        }
    }

    public void Obj_isActive(GameObject obj)
    {
        chk_Obj.Remove(obj);
        gameManager.Enemy_Killed++;
        if (chk_Obj.Count == 0)
            StartCoroutine(toNextStage());
    }

    IEnumerator toNextStage()
    {
        gameManager.Warning_text(2);
        stageNum++;
        if(stageNum == 5)
        {
            yield return new WaitForSeconds(2);
            gameManager.Warning_text(6);
            StopCoroutine(toNextStage());
        }
        yield return new WaitForSeconds(10);
        OnStage++;
        ReadSpawnFile();
    }

    public void DeActiveObj()
    {
        for(int index = 0; index < chk_Obj.Count; index++)
        {
            chk_Obj[index].SetActive(false);
        }
        chk_Obj.Clear();
    }

    void Stage_2()
    {
        Debug.Log("스테이지 2로 넘어감");
    }

    void Stage_3()
    {

    }

    void Stage_4()
    {

    }

}
