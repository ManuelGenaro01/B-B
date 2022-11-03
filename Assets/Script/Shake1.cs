using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake1 : MonoBehaviour
{
    public bool start = false; 
    public bool start2 = false;
    public AnimationCurve anim;
    public float duration = 1f;
    void Update()
    {
            StartCoroutine(Shaking()); 
        StartCoroutine(Shaking2());
    }
    IEnumerator Shaking()
    {
        Vector3 StartPosition = transform.position;
        float elapsedTime = 0;

        while (start==true)
        {
            elapsedTime += Time.deltaTime;
            float strenght = anim.Evaluate(elapsedTime / duration);
            transform.position = StartPosition + Random.insideUnitSphere*0.05f;
            yield return null;
        }
        transform.position = StartPosition;
    }
    IEnumerator Shaking2()
    {
        Vector3 StartPosition = transform.position;
        float elapsedTime = 0;

        while (start2 == true)
        {
            elapsedTime += Time.deltaTime;
            float strenght = anim.Evaluate(elapsedTime / duration);
            transform.position = StartPosition + Random.insideUnitSphere * 0.05f;
            yield return null;
        }
        transform.position = StartPosition;
    }
}
