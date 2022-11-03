using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Move : MonoBehaviour
{
    public AudioSource audioS;
    public AudioSource audioFoot;
    public GameObject tipo;
    public GameObject tiro;
    public Transform lugarTiro;
    public float veloc;
    float tiempoBala;
    float tiempoBala2 = 0.1f;
    float tiempoBalaS;
    float tiempoBalaS2 = 0.6f;
    float tiempoBalaM;
    float tiempoBalaM2=0.03f;
    float queBala;
    public GameObject pied1;
    public GameObject pied2;
    public GameObject layer1;
    public GameObject layer2;
    public GameObject colli1;
    public GameObject colli2;
    float vida = 100;
    float bala = 100;
    public GameObject healthbar;
    DispararBomb shot;
    public TextMeshProUGUI bullets;
    float shotgun;
    float shotgun2;
    public bool win;
    public GameObject blood;
    public AudioClip foot;
    bool sound;
    float tiempoPaso;
    float tiempoPaso2 = 0.5f;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioFoot = GameObject.Find("Footsteps").GetComponent<AudioSource>();
        int piedra1 = Random.Range(3, 5);
        int piedra2 = Random.Range(0, 2);
        pied1 = GameObject.Find("piedra_" + piedra1);
        pied2 = GameObject.Find("piedra_" + piedra2);
        layer1 = GameObject.Find("layer" + piedra1);
        layer2 = GameObject.Find("layer" + piedra2);
        colli1 = GameObject.Find("collision" + piedra1);
        colli2 = GameObject.Find("collision" + piedra2);
        Destroy(pied2);
        Destroy(pied1);
        Destroy(colli2);
        Destroy(colli1);
    }
    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float disparo = Input.GetAxis("Fire1");
        shotgun = GameObject.Find("bomb").GetComponent<DispararBomb>().shotgun;
        shotgun2 = GameObject.Find("bomb").GetComponent<DispararBomb>().shotgun2;
        transform.Translate(new Vector3(horizontal, vertical, 0) * veloc * Time.deltaTime);
        if (vertical != 0f || horizontal != 0f)
        {
            tipo.GetComponent<Animator>().Play("move");
            if (Time.time > tiempoPaso)
            {
                tiempoPaso = Time.time + tiempoPaso2;
                audioFoot.PlayOneShot(foot);
            }
        }
        else
        {
            tipo.GetComponent<Animator>().Play("iddle");
        }
        if (vida > 100)
        {
            vida = 100;
        }
        else if (vida < 0)
        {
            GameObject.Find("tipo2").GetComponent<Move1>().win = true;
            Destroy(gameObject);
        }
        healthbar.GetComponent<Slider>().value = vida / 100;
        bullets.text = bala.ToString();
        switch (shotgun)
        {
            case 0:
            if (disparo > 0 && Time.time > tiempoBala && bala > 0 && win==false)
            {
                tiempoBala = Time.time + tiempoBala2;
                Instantiate(tiro, lugarTiro.position, lugarTiro.rotation);
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosTirados1 += 1;
                    bala -= 1;
                    audioS.PlayOneShot(GetComponent<Sounds>().tiro, 1f);
                }
                
                veloc = 10;
                GameObject.Find("Main Camera").GetComponent<Shake1>().start = false;
                GameObject.Find("shot_3").GetComponent<Animator>().Play("shot");
                break;
            case 1:
                
                if (disparo > 0 && Time.time > tiempoBalaS && win==false)
                {
                    tiempoBalaS = Time.time + tiempoBalaS2;
                    Instantiate(tiro, lugarTiro.position, lugarTiro.rotation);
                    Instantiate(tiro, lugarTiro.position, Quaternion.Euler(0, 0, 27));
                    Instantiate(tiro, lugarTiro.position, Quaternion.Euler(0, 0, 45));
                    Instantiate(tiro, lugarTiro.position, Quaternion.Euler(0, 0, -45));
                    Instantiate(tiro, lugarTiro.position, Quaternion.Euler(0, 0, -27));
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosTirados1 += 1;
                    audioS.PlayOneShot(GetComponent<Sounds>().tiroShot, 1f);
                }
                GameObject.Find("Main Camera").GetComponent<Shake1>().start = false;
                veloc = 8;
                GameObject.Find("shot_3").GetComponent<Animator>().Play("shotgun");
                break;
            case 2: 
                if(disparo>0 && Time.time > tiempoBalaM && win == false && queBala == 0)
                {
                    tiempoBalaM = Time.time + tiempoBalaM2;
                    Instantiate(tiro, new Vector3(lugarTiro.position.x+0.7f, lugarTiro.position.y - 0.12f, lugarTiro.position.z), lugarTiro.rotation);
                    queBala = 1;
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosTirados1 += 1;
                    audioS.PlayOneShot(GetComponent<Sounds>().tiro, 0.5f);
                }
                else if (disparo > 0 && Time.time > tiempoBalaM && win == false && queBala == 1)
                {
                    tiempoBalaM = Time.time + tiempoBalaM2;
                    Instantiate(tiro, new Vector3(lugarTiro.position.x+0.7f, lugarTiro.position.y - 0.4f, lugarTiro.position.z), lugarTiro.rotation);
                    queBala = 2;
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosTirados1 += 1;
                    audioS.PlayOneShot(GetComponent<Sounds>().tiro, 0.5f);
                }
                else if (disparo > 0 && Time.time > tiempoBalaM && win == false && queBala == 2)
                {
                    tiempoBalaM = Time.time + tiempoBalaM2;
                    Instantiate(tiro, new Vector3(lugarTiro.position.x+0.7f, lugarTiro.position.y - 0.2f, lugarTiro.position.z), lugarTiro.rotation);
                    queBala = 0;
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosTirados1 += 1;
                    tipo.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1f);
                    audioS.PlayOneShot(GetComponent<Sounds>().tiro, 0.5f);
                }
                if (disparo > 0)
                {
                    GameObject.Find("Main Camera").GetComponent<Shake1>().start = true;
                }
                else
                {
                    GameObject.Find("Main Camera").GetComponent<Shake1>().start = false;
                }
                veloc = 4;
                GameObject.Find("shot_3").GetComponent<Animator>().Play("mini");
                break;
        }
        switch (win)
        {
            case true:
                GameObject.Find("bomb").GetComponent<DispararBomb>().win1=true;
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (shotgun2)
        {
            case 0:
                if (collision.gameObject.tag == "Tiro2")
                {
                    vida -= 1;
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosPegados2 += 1;
                    Instantiate(blood, new Vector3(tipo.transform.position.x + Random.Range(0.3f, -0.3f) - 0.3f, tipo.transform.position.y + Random.Range(0.3f, -0.3f), 0), Quaternion.Euler(0,0,0));
                }
                break;
            case 1:
                if (collision.gameObject.tag == "Tiro2")
                {
                    vida -= 4;
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosPegados2 += 1;
                    Instantiate(blood, new Vector3(tipo.transform.position.x + Random.Range(0.3f, -0.3f) - 0.3f, tipo.transform.position.y + Random.Range(0.3f, -0.3f), 0), Quaternion.Euler(0, 0, 0));
                }
                break;
            case 2:
                if (collision.gameObject.tag == "Tiro2")
                {
                    vida -= 1f;
                    GameObject.Find("bomb").GetComponent<DispararBomb>().disparosPegados2 += 1;
                    Instantiate(blood, new Vector3(tipo.transform.position.x + Random.Range(0.3f, -0.3f) - 0.3f, tipo.transform.position.y + Random.Range(0.3f, -0.3f), 0), Quaternion.Euler(0, 0, 0));
                }
                break;

        }
        
        if (collision.gameObject.tag == "Bomba2")
        {
            vida -= 30;
            Instantiate(blood, tipo.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (collision.gameObject.tag == "balas"){
            bala += 50;
            audioS.PlayOneShot(GetComponent<Sounds>().powerBala);
        }
        if (collision.gameObject.tag == "vida")
        {
            vida += 50;
            audioS.PlayOneShot(GetComponent<Sounds>().powerHealth);
        }
        if (collision.gameObject.tag == "ShotSound")
        {
            audioS.PlayOneShot(GetComponent<Sounds>().powerShotyMin);
        }
        
        if (collision.gameObject.tag == "BombSound")
        {
            audioS.PlayOneShot(GetComponent<Sounds>().powerBomb);
        }
    }
    void Update()
    {
    }
   
}
