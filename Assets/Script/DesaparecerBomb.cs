using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerBomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject bomb2;
    public Transform lugarTiro;
    public Transform lugarTiro2;
    public AudioSource audioS;
    public AudioClip up;
   

    private void Start()
    {
        lugarTiro = GameObject.Find("lugartiro").transform;
        lugarTiro2 = GameObject.Find("lugartiro (1)").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Instantiate(bomb, lugarTiro.position, lugarTiro.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player2")
        {
            Instantiate(bomb2, lugarTiro2.position, lugarTiro2.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ChauSpawn")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * 3 * Time.deltaTime);
    }
}
