using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    float timeSpawn1Bala=1;
    float timeSpawn1Cora=2;
    float timeSpawn1Bomb=3;
    float timeSpawn1Shot=4;
    float timeSpawn1Mini = 5;
    public GameObject bala;
    public GameObject cora;
    public GameObject bomb;
    public GameObject shotgun;
    public GameObject mini;
    float whatSpawn;
    float timeSpawn2Bala;
    float timeSpawn2Cora;
    void Start()
    {
        timeSpawn1Bala = Random.Range(4, 7);
        timeSpawn1Cora = Random.Range(7, 13);
        timeSpawn1Bomb = Random.Range(25, 35);
        timeSpawn1Shot = Random.Range(35, 40);
        timeSpawn1Mini = Random.Range(60, 85);
    }

    // Update is called once per frame
    void Update()
    {

        float timeSpawn2Bala = Random.Range(4f, 7f);
        if (Time.time > timeSpawn1Bala)
        {
            timeSpawn1Bala = Time.time + timeSpawn2Bala;
            int spawn = Random.Range(0, 9);
            Transform spawns = GameObject.Find("spawn" + spawn).GetComponent<Transform>();
            Instantiate(bala, spawns.position, spawns.rotation);
        }
        float timeSpawn2Cora = Random.Range(7f, 13f);
        if (Time.time > timeSpawn1Cora)
        {
            timeSpawn1Cora = Time.time + timeSpawn2Cora;
            int spawn = Random.Range(0, 9);
            Transform spawns = GameObject.Find("spawn" + spawn).GetComponent<Transform>();
            Instantiate(cora, spawns.position, spawns.rotation);
        }
        float timeSpawn2Bomb = Random.Range(25f, 35f);
        if (Time.time > timeSpawn1Bomb)
        {
            timeSpawn1Bomb = Time.time + timeSpawn2Bomb;
            int spawn = Random.Range(0, 9);
            Transform spawns = GameObject.Find("spawn" + spawn).GetComponent<Transform>();
            Instantiate(bomb, spawns.position, spawns.rotation);
        }
        float timeSpawn2Shot = Random.Range(35f, 40f);
        if (Time.time > timeSpawn1Shot)
        {
            timeSpawn1Shot = Time.time + timeSpawn2Shot;
            int spawn = Random.Range(0, 9);
            Transform spawns = GameObject.Find("spawn" + spawn).GetComponent<Transform>();
            Instantiate(shotgun, spawns.position, spawns.rotation);
        }
        float timeSpawn2Mini = Random.Range(60f, 85f);
        if (Time.time > timeSpawn1Mini)
        {
            timeSpawn1Mini = Time.time + timeSpawn2Mini;
            int spawn = Random.Range(0, 9);
            Transform spawns = GameObject.Find("spawn" + spawn).GetComponent<Transform>();
            Instantiate(mini, spawns.position, spawns.rotation);
        }
    }
    
}
