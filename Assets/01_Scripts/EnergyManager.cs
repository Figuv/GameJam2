using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Image energyBar;
    float energyAmount;
    public Player player;
    public Text distanceText;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        energyAmount = player.energy;
        energyBar.fillAmount = energyAmount/100f;
        distance = player.distance / 10f;
        distanceText.text = distance.ToString() + "m";

    }

    public void consumeEnergy(float energy){
        energyAmount -= energy;
        energyBar.fillAmount = energyAmount/100f;
    }
}
