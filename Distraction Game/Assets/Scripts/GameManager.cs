using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State{ COUNTDOWN, GAMEPLAY, GAMEOVER };

    public GameObject spawner;
    public float Deadline;
    [HideInInspector]public float currentDeadline;
    [HideInInspector]public float progress;
    public float energy = 100f;
    float countDown;
    [SerializeField] float SetCountDown = 5f;
    public State gameState;
    private void Start()
    {
        currentDeadline = Deadline;
        gameState = State.COUNTDOWN;
        countDown = SetCountDown;
    }
   
    bool Pause = false;
    void Update()
    {
        countDown -= Time.deltaTime;
        //Debug.Log(countDown);
        if (countDown <= 0)
        {
            gameState = State.GAMEPLAY;
        }

        if (gameState == State.GAMEPLAY)
        { 
            currentDeadline -= Time.deltaTime;
            progress += Time.deltaTime * 2;
            spawner.SetActive(true);
        }
        else { return; }
                  
    }
}
