using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject flat;
    public GameObject tall;
    public GameObject diag;
    public GameObject mas;
    public float flatHeight;
    public float tallHeight;

    private float spawnTime;
    private float initialWait;

    private void Awake()
    {
        spawnTime = 4.0f;
        initialWait = 4.0f;
    }

    private void Update()
    {
        byte rand = (byte)UnityEngine.Random.Range(0, 4);
        spawnTime -= Time.deltaTime;
        initialWait -= Time.deltaTime;
        if (spawnTime <= 0 && initialWait <= 0)
        {
            switch (rand)
            {
                case 0:
                    Invoke("spawnTall", 0f);
                    break;
                case 1:
                    Invoke("spawnFlat", 0f);
                    break;
                case 2:
                    Invoke("spawnDiagonal", 0f);
                    break;
                case 3:
                    Invoke("spawnMasista", 0f);
                    break;
            }
            spawnTime = 4.0f;
        }
    }

    void spawnFlat()
    {
            GameObject go = Instantiate(flat, transform.position, Quaternion.identity);
            go.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-4.3f, flatHeight), transform.position.z);
            Destroy(go, 20.0f);
    }
    void spawnTall()
    {
            GameObject go = Instantiate(tall, transform.position, Quaternion.identity);
            go.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-1.6f, tallHeight), transform.position.z);
            Destroy(go, 20.0f);
    }
    void spawnDiagonal()
    {
        Quaternion rotacion = Quaternion.Euler(0, 0, 45);
        GameObject go = Instantiate(diag, transform.position, rotacion);
        go.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(-1.6f, tallHeight), transform.position.z);
        Destroy(go, 20.0f);
    }
    void spawnMasista()
    {
        GameObject go = Instantiate(mas, transform.position, Quaternion.identity);
        go.transform.position = new Vector3(transform.position.x, -3.99f, transform.position.z);
        Destroy(go, 20.0f);
    }
}

