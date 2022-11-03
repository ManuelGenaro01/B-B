using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float Force;
    float exp;
    Vector3 vect;
    void Start()
    {
        vect = (new Vector3(0, 1, 0f));
        StartCoroutine(camb());
    }

    
    void Update()
    {
        switch (exp)
        {
            case 0:
                Force = 20;
                gameObject.GetComponent<Rigidbody2D>().AddForce(vect * Force);
                break;
            case 1:
                Force = 0;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                break;
        }
    }
    IEnumerator camb()
    {
        yield return new WaitForSeconds(0.5f);
        exp = 1;
    }
}
