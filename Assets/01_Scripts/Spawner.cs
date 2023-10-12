using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject flat;
    public GameObject tall;
    public GameObject diag;
    public float flatHeight;
    public float tallHeight;

    private float spawnTime;
    private float initialWait;

    private void Awake()
    {
        spawnTime = 5.0f;
        initialWait = 5.0f;
    }

    private void Update()
    {
        byte rand = (byte)UnityEngine.Random.Range(0, 3);
        spawnTime -= Time.deltaTime;
        initialWait -= Time.deltaTime;
        if (spawnTime <= 0 && initialWait <= 0)
        {
            switch (rand)
            {
                case 0:
                    Invoke("spawnTall", UnityEngine.Random.Range(0.75f, 2));
                    break;
                case 1:
                    Invoke("spawnFlat", UnityEngine.Random.Range(0, 1));
                    break;
                case 2:
                    Invoke("spawnDiagonal", UnityEngine.Random.Range(1, 3));
                    break;
            }
            spawnTime = 5.0f;
        }
    }

    void spawnFlat()
    {
            GameObject go = Instantiate(flat, transform.position, Quaternion.identity);
            go.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-flatHeight, flatHeight), transform.position.z);
            Destroy(go, 20.0f);
    }
    void spawnTall()
    {
            GameObject go = Instantiate(tall, transform.position, Quaternion.identity);
            go.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-tallHeight, tallHeight), transform.position.z);
            Destroy(go, 20.0f);
    }
    void spawnDiagonal()
    {
        Quaternion rotacion = Quaternion.Euler(0, 0, 45);
        GameObject go = Instantiate(diag, transform.position, rotacion);
        go.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-tallHeight, tallHeight), transform.position.z);
        Destroy(go, 20.0f);
    }
}

