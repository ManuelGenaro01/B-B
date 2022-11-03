using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2" || collision.gameObject.tag=="ChauSpawn")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * 3 * Time.deltaTime);
    }
}
