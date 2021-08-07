using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner_Bullet : MonoBehaviour
{
    Note_Enemy_Movement noteScript;
    Sample_Enemy_Movement radioScript;
    Humidifier_Movement humiScript;
    public Vector3 target_loc = new Vector3();
    Vector3 dir = new Vector3();
    float angle;
    bool go;
    public float bullet_speed;
    public int bullet_Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            transform.position += dir * bullet_speed * Time.deltaTime;
        }
        if(transform.position.x > 90)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            switch (collision.tag)
            {
                case "Note_Eny":
                    noteScript = collision.gameObject.GetComponent<Note_Enemy_Movement>();
                    noteScript.Enemy_hp -= bullet_Damage;
                    gameObject.SetActive(false);
                    break;
                case "Radio_Eny":
                    radioScript = collision.gameObject.GetComponent<Sample_Enemy_Movement>();
                    radioScript.Enemy_hp -= bullet_Damage;
                    gameObject.SetActive(false);
                    break;
                case "Humidifier_Eny":
                    humiScript = collision.gameObject.GetComponent<Humidifier_Movement>();
                    humiScript.health -= bullet_Damage;
                    gameObject.SetActive(false);
                    break;

            }
        } else if(collision.gameObject.layer == 11)
                {
            gameObject.SetActive(false);
        }
    }

    public void GetAngle()
    {
        transform.rotation = Quaternion.Euler(target_loc - transform.position);
        go = true;
        dir = new Vector2(target_loc.x, target_loc.y) - new Vector2(transform.position.x, transform.position.y);
    }
}
