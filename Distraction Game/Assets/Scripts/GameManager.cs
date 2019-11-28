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

    [Range(0f,100f)]
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
        energy = Mathf.Clamp(energy, 0f, 100f);
        
        if (gameState == State.COUNTDOWN)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            gameState = State.GAMEPLAY;
        }
        if (gameState == State.GAMEPLAY||gameState == State.DISTRACTED)
        {
            currentDeadline -= Time.deltaTime;
        }
        if (gameState == State.GAMEPLAY)
        {        
            progress += Time.deltaTime * 2;
            spawner.SetActive(true);
        }
        else { return; }
        if (progress >= 100f)
        {
            gameState = State.COMPLETE;
        }
                     
    }
  
}
