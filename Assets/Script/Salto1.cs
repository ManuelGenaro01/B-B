using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto1 : MonoBehaviour
{
    public float Force;
    float exp;
    Vector3 vect;
    float rotation;
    void Start()
    {
        vect = (new Vector3(Random.Range(-3f,3f), Random.Range(-1f,1f), 0f));
        StartCoroutine(camb());
    }

    
    void Update()
    {
        rotation += 10;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        switch (exp)
        {
            case 1:
                Force = 5;
                gameObject.GetComponent<Rigidbody2D>().AddForce(vect * Force);
                break;
        }
    }
    IEnumerator camb()
    {
        yield return new WaitForSeconds(0.5f);
        exp = 1;
    }
}
