using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 5f;
    float distance = 0;
    public float backgroundSpeed = 2f;
    float multiplier = 1.05f;
    float timeToIncrease = 1f;
    float timer = 0f;

    public float energy = 90f;
    public bool isGrounded = false;


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
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * 220f, ForceMode2D.Impulse);
                isGrounded = false;
            }
            else
            {
                if (energy < 100)
                {
                    rb.velocity = Vector2.up * speed;
                    energy += 0.07f;
                }
            }
        }
    }

    void consumeEnergy(float energy)
    {
        this.energy -= energy;
        if (this.energy < 0)
        {
            this.energy = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void UpdateDistance()
    {
        timer += Time.deltaTime;
        if (timer >= timeToIncrease)
        {
            distance = distance * multiplier + 1;
            backgroundSpeed = backgroundSpeed * multiplier;
            speed = speed * multiplier;
            timer = 0f;
        }
    }
}
