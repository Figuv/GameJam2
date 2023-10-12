using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //quiero que cuando se mantenga presionada la tecla space, el jugador se mantenga en el aire
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * speed;
        }


    }
}
