using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DispararBomb : MonoBehaviour
{
    public float disparo;
    public float disparo2;
    public float shotgun;
    public float shotgun2;
    public float disparosTirados1;
    public float disparosPegados1;
    public float disparosTirados2;
    public float disparosPegados2;
    public float puntos1;
    public float puntos2;
    public float puntosMenos1;
    public float puntosMenos2;
    public float puntosFinal1;
    public float puntosFinal2;
    public float porcentaje1;
    public float porcentaje2;
    public bool win1;
    public bool win2;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI points;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        porcentaje1 = (disparosPegados1 * 100) / disparosTirados1;
        porcentaje2 = (disparosPegados2 * 100) / disparosTirados2;
        puntos1 = (6000 * porcentaje1) / 100;
        puntos2 = (6000 * porcentaje2) / 100;
        puntosMenos1 = (3000 * porcentaje2) / 100;
        puntosMenos2 = (3000 * porcentaje1) / 100;
        if (float.IsNaN(porcentaje2))
        {
            puntosFinal1 = puntos1;
        }
        else
        {
            puntosFinal1 = puntos1 - puntosMenos1;
        }
        if (float.IsNaN(porcentaje1))
        {
            puntosFinal2 = puntos2;
        }
        else
        {
            puntosFinal2 = puntos2 - puntosMenos2;
        }
        float disparar = Input.GetAxis("Fire2");
        switch (disparo)
        {
            case 2:
                StartCoroutine(bomb1());
                break;
        }
        switch (disparo2)
        {
            case 2:
                StartCoroutine(bomb2());
                break;
        }
        switch (shotgun)
        {
            case 1:
                StartCoroutine(shotg());
                break;
            case 2:
                StartCoroutine(shotMini());
                break;
        }
        switch (shotgun2)
        {
            case 1:
                StartCoroutine(shotg2());
                break;
            case 2:
                StartCoroutine(shotMini1());
                break;
        }
        if (win1 == true)
        {
            int puntosF1 = (int)puntosFinal1;
            player1.text = "Player 1 Wins";
            points.text = puntosF1.ToString() + " points";
            Scene scene = SceneManager.GetActiveScene();
            if (Input.GetAxis("Fire3") > 0 || Input.GetAxis("Submit") > 0)
            {
                SceneManager.LoadScene(scene.name);
            }
        }
        if (win2 == true)
        {
            int puntosF2 = (int)puntosFinal2;
            player1.text = "Player 2 Wins";
            points.text = puntosF2.ToString() + " points";
            Scene scene = SceneManager.GetActiveScene();
            if (Input.GetAxis("Fire3") > 0 || Input.GetAxis("Submit")>0)
            {
                
                SceneManager.LoadScene(scene.name);
            }
        }
    }
    IEnumerator shotg()
    {
        yield return new WaitForSeconds(15f);
        shotgun = 0;
    }
    IEnumerator shotMini()
    {
        yield return new WaitForSeconds(10f);
        shotgun = 0;
    }
    IEnumerator shotMini1()
    {
        yield return new WaitForSeconds(10f);
        shotgun2 = 0;
    }
    IEnumerator shotg2()
    {
        yield return new WaitForSeconds(15f);
        shotgun2 = 0;
    }
    IEnumerator bomb1()
    {
        yield return new WaitForSeconds(0.2f);
        disparo = 0;
    }
    IEnumerator bomb2()
    {
        yield return new WaitForSeconds(0.2f);
        disparo2 = 0;
    }
}
