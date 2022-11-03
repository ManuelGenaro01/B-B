using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public float disparo;
    public float disparo2;
    public Transform posicion;
    public GameObject bomba;
    public GameObject exp;
    void Start()
    {
        posicion = GameObject.Find("lugartiro").transform;
        bomba = GameObject.Find("bomb");
    }
    void Update()
    {
        disparo = Input.GetAxis("Fire2");
        if (disparo == 1)
        {
            disparo2 = 1;
            bomba.GetComponent<DispararBomb>().disparo = 1;
        }
        switch (disparo2) {
            case 0:
        transform.position = posicion.position;
                break;
            case 1:
                    transform.Translate(Vector2.right * 20 * Time.deltaTime);
                break;
                
    }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (disparo2 == 1)
        {
            if (collision.gameObject.tag == "Collider" || collision.gameObject.tag == "Player2")
            {
                disparo2 = 0;
                Instantiate(exp, transform.position, transform.rotation);
                GameObject.Find("Main Camera").GetComponent<Shake>().start = true;
                bomba.GetComponent<DispararBomb>().disparo = 2;
                Destroy(gameObject);
            }
        }
    }
}
