using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romper : MonoBehaviour
{
    public float vida = 300f;
    public GameObject bombs;
    public GameObject pedazo;
    void Start()
    {
        
    }

    
    void Update()
    {
        BoxCollider2D roto = GetComponent<BoxCollider2D>();
        if (vida <= 300 && vida>200)
        {
            gameObject.GetComponent<Animator>().Play("romper");
        }
        else if(vida<=200 && vida>100)
        {
            gameObject.GetComponent<Animator>().Play("romper2");
        }
        else if (vida <= 100 && vida>0)
        {
            gameObject.GetComponent<Animator>().Play("romper3");
        }
        else if (vida <= 0)
        {
            gameObject.GetComponent<Animator>().Play("romper4");
            Destroy(roto);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Tiro" || collision.gameObject.tag == "Tiro2")
        {
            vida -= 1f;
            Instantiate(pedazo, new Vector3(gameObject.transform.position.x + Random.Range(0.3f, -0.3f), gameObject.transform.position.y + Random.Range(0.3f, -0.3f), 0), Quaternion.Euler(0,0,0));
        }
        if (bombs.GetComponent<DispararBomb>().disparo > 0 )
        {
            if (collision.gameObject.tag == "Bomba" )
            {
                vida = 0;
                Instantiate(pedazo, new Vector3(gameObject.transform.position.x + Random.Range(0.3f, -0.3f), gameObject.transform.position.y + Random.Range(0.3f, -0.3f), 0), gameObject.transform.rotation);
            }
        }
        else if (bombs.GetComponent<DispararBomb>().disparo2 > 0)
        {
            if (collision.gameObject.tag == "Bomba2")
            {
                vida = 0;
                Instantiate(pedazo, new Vector3(gameObject.transform.position.x + Random.Range(0.3f, -0.3f), gameObject.transform.position.y + Random.Range(0.3f, -0.3f), 0), gameObject.transform.rotation);
            }
        }
    }
}
