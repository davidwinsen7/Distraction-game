using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State{ COUNTDOWN, GAMEPLAY, DISTRACTED, GAMEOVER ,COMPLETE};

    public GameObject spawner;
    public float Deadline;
    [HideInInspector]public float currentDeadline;
    [HideInInspector]public float progress;

    [Range(0f, 100f)]
    public float energy = 100f;
    public float maxEnergy = 50f;
    public float progressMultiplier = 2f;
    [HideInInspector] public float usedProgressMultiplier;

    [HideInInspector]public float countDown;
    [SerializeField] float SetCountDown = 5f;
    public State gameState;
    [SerializeField] GameObject levelIndicator;

    PlayerScript player;
    private void Start()
    {
        currentDeadline = Deadline;
        gameState = State.COUNTDOWN;
        countDown = SetCountDown;
        player = FindObjectOfType<PlayerScript>().GetComponent<PlayerScript>();
        usedProgressMultiplier = progressMultiplier;
    }
    void Update()
    {
        energy = Mathf.Clamp(energy, 0f, maxEnergy);
        currentDeadline = Mathf.Clamp(currentDeadline, 0f, Deadline);
        if (gameState == State.COUNTDOWN)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            {
                gameState = State.GAMEPLAY;
                levelIndicator.SetActive(true);
            }
            
        }
        if (gameState == State.GAMEPLAY||gameState == State.DISTRACTED)
        {
            currentDeadline -= Time.deltaTime;
        }
        if (gameState == State.GAMEPLAY)
        {        
            progress += Time.deltaTime * usedProgressMultiplier;
            spawner.SetActive(true);
            for (int i = 0; i < player.distractedUI.Length; i++)
            {
                player.distractedUI[i].SetActive(false);
            }
        }
        else { return; }
        if (progress >= 100f && currentDeadline > 0f)
        {
            gameState = State.COMPLETE;
            spawner.SetActive(false);
        }
        else if(progress < 100f && currentDeadline <= 0)
        {
            player.StopAllCoroutines();
            gameState = State.GAMEOVER;
            spawner.SetActive(false);
        }                    
    }  
}
