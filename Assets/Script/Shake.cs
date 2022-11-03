using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve anim;
    public float duration = 1f;
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 StartPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = anim.Evaluate(elapsedTime / duration);
            transform.position = StartPosition + Random.insideUnitSphere*strenght;
            yield return null;
        }
        transform.position = StartPosition;
    }
}
