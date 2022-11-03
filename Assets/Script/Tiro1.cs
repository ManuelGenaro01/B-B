using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro1 : MonoBehaviour
{
    void Start()
    {
        
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collider" || collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.left * 30 * Time.deltaTime);
    }
}
