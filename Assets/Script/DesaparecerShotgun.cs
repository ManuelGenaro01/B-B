using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerShotgun : MonoBehaviour
{
    float shot;
    public AudioSource audioS;
    public AudioClip up;
    void Start()
    {
        shot = GameObject.Find("bomb").GetComponent<DispararBomb>().shotgun;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("bomb").GetComponent<DispararBomb>().shotgun=1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player2")
        {
            GameObject.Find("bomb").GetComponent<DispararBomb>().shotgun2 = 1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "ChauSpawn")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * 3 * Time.deltaTime);
    }
}
