using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    public GameObject desaparecer;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tiro")
        {
            Destroy(desaparecer);
        }
    }
    void Update()
    {
        
    }
}
