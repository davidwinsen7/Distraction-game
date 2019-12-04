using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resisting : MonoBehaviour
{
    
    public Slider resistanceBar;
    public float resistanceMultiplier = 10f;
    public float resistanceDecrease = 20f;
    GameManager manager;
    PlayerScript player;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
    }
    private void Update()
    {
        
        resistanceBar.value -= resistanceDecrease * Time.deltaTime;
        
        if(resistanceBar.value >= 100f)
        {
            resistanceBar.value = 0f;
            player.StopAllCoroutines();
            manager.gameState = GameManager.State.GAMEPLAY;
            gameObject.SetActive(false);
        }
    }
    public void resist()
    {
        if (manager.energy > 0)
        {
            resistanceBar.value += resistanceMultiplier;
            manager.energy -= 1f;
        }     
    }
}
