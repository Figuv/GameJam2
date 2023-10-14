using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float distance = 0;
    public float multiplier = 1.05f;
    public float timeToIncrease = 1f;
    public float timer = 0f;
    public float obstacleSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        UpdateDistance();
    }

    void Movement()
    {
        //quiero que cuando se mantenga presionada la tecla space, el jugador se mantenga en el aire
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
        }


    }
    void UpdateDistance()
    {
        Debug.Log(distance);
        timer += Time.deltaTime;
        if (timer >= timeToIncrease)
        {
            distance = distance * multiplier + 1;
            obstacleSpeed = obstacleSpeed * multiplier;
            timer = 0f;
        }
    }
}
