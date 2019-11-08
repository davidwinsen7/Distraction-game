using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State{ COUNTDOWN, GAMEPLAY, DISTRACTED, GAMEOVER };

    public GameObject spawner;
    public float Deadline;
    [HideInInspector]public float currentDeadline;
    [HideInInspector]public float progress;
    public float energy = 100f;
    [HideInInspector]public float countDown;
    [SerializeField] float SetCountDown = 5f;
    public State gameState;
    private void Start()
    {
        currentDeadline = Deadline;
        gameState = State.COUNTDOWN;
        countDown = SetCountDown;
    }
    void Update()
    {
        
        if (gameState != State.COUNTDOWN)
        {
            currentDeadline -= Time.deltaTime;
        }
        else { countDown -= Time.deltaTime; }
        if (countDown <= 0 && gameState == State.COUNTDOWN)
        {
            gameState = State.GAMEPLAY;
        }

        if (gameState == State.GAMEPLAY)
        {        
            progress += Time.deltaTime * 2;
            spawner.SetActive(true);
        }
        else { return; }                
    }
}
