using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    public GameObject tipo;
    public int pipo;
    public int pipo2;
    public GameObject tipo2;
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tipo.GetComponent<SpriteRenderer>().sortingOrder = pipo;
        }
        if (collision.gameObject.tag == "Player2")
        {
            tipo2.GetComponent<SpriteRenderer>().sortingOrder = pipo;
        }
    }
}
