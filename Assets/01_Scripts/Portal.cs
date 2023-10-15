using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private float speed;
    private float timer=0f;
    private float timeToDie = 10f;
    public SecretMissionSpawner secretMissionSpawner;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        secretMissionSpawner = GameObject.FindGameObjectWithTag("SecretMissionSpawner").GetComponent<SecretMissionSpawner>();
        secretMissionSpawner.isPortalLive = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        speed = player.backgroundSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        timer += Time.deltaTime;
        if(timer >= timeToDie){
            Destroy(gameObject);
            timer = 0f;
        }
    }

    void Movement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!secretMissionSpawner.isSecret){
                secretMissionSpawner.isSecret = true;
                secretMissionSpawner.isPortalLive = false;
                secretMissionSpawner.distanceSpawned = player.distance;
                Destroy(gameObject);
            }else{
                secretMissionSpawner.isSecret = false;
                secretMissionSpawner.isPortalLive = false;
                Destroy(gameObject);
            }
           
        }
    }


}
