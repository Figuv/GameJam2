using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    private Vector2 posInicio;
    public float speed = 2f;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        posInicio = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.backgroundSpeed;
        transform.Translate(Vector2.left * 10f * Time.deltaTime);
        if(transform.position.x <posInicio.x- 38){
            transform.position = posInicio;
        }
        
    }
}
