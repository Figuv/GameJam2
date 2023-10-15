using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretMissionSpawner : MonoBehaviour
{
    public GameObject portal;
    private Player player;
    private float distance;
    public float distanceSpawned;
    public bool isSecret = false;
    public bool isPortalLive = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.distance;
        SpawnPortal();
        SpawnExit();
    }
    
    void SpawnPortal()
    {
        if (distance % 2 == 0 && !isSecret && !isPortalLive)
        {
            Instantiate(portal, new Vector3(12f, Random.Range(-4f, 4f), 0), Quaternion.identity);
        }
        if(isSecret && !isPortalLive && distance >= distanceSpawned+30){
            Instantiate(portal, new Vector3(12f, Random.Range(-4f, 4f), 0), Quaternion.identity);
        }
    }

    void SpawnExit()
    {
        if (isSecret && distance >= distanceSpawned + 30)
        {
            Instantiate(portal, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
