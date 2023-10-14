using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    public Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        speed = player.obstacleSpeed;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.LogError("Choque con el jugador");
        }
    }
}
