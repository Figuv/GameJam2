using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float energy = 90f;
    public bool isGrounded = false;
    public float distance = 0f;
    public float backgroundSpeed = 2f;
    
    private float jumpForce = 220f;
    private float maxEnergy = 100f;
    private float energyRegenRate = 0.07f;
    private float multiplier = 1.03f;
    private float timeToIncrease = 1f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        distance = 0f;
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
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
            else
            {
                if (energy < maxEnergy)
                {
                    rb.velocity = Vector2.up * speed;
                    energy += energyRegenRate;
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
            distance += speed * timer;
            backgroundSpeed = backgroundSpeed * multiplier;
            speed = speed * multiplier;
            timer = 0f;
        }
    }
}
