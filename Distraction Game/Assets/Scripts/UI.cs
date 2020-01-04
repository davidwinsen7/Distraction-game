using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    GameManager manager;
    private int roundedDeadline;

    [SerializeField] GameObject levelCompleteUI;
    [SerializeField] GameObject GameOverUI;

    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] GameObject countdownUI;

    [Header("Deadline Management")]
    [SerializeField] Text deadlineUI;
    [SerializeField] Image deadlineBar;
    void UpdateTimer()
    {
        deadlineBar.fillAmount = manager.currentDeadline / manager.Deadline * 1;
        roundedDeadline = (int)manager.currentDeadline;
        deadlineUI.text = roundedDeadline.ToString();      
    }

    [Header("Level Progression")]
    [SerializeField] Slider progressBar;
    void UpdateProgress()
    {
        progressBar.value = manager.progress;
    }

    [Header("Energy Management")]
    [SerializeField] Slider energyBar;
    void UpdateEnergy()
    {
        energyBar.value = manager.energy;
    }

    

    void CheckCompletion()
    {     
        if (manager.gameState == GameManager.State.COMPLETE)
        {
            levelCompleteUI.SetActive(true);
        }
        else
        {
            levelCompleteUI.SetActive(false);
        }
    }

    void CheckGameOver()
    {
        if (manager.gameState == GameManager.State.GAMEOVER)
        {
            GameOverUI.SetActive(true);
        }
        else
        {
            GameOverUI.SetActive(false);
        }
    }

    [SerializeField] GameObject PauseUI;
    bool gameIsPaused = false;
    public void pauseMethod()
    {    
        if (!gameIsPaused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            gameIsPaused = true;
        }
        else
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
          
    }
    void pauseSystem()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMethod();
        }
    }

    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void Update()
    {
        countdown.text = ((int)manager.countDown).ToString();
        if (manager.gameState == GameManager.State.GAMEPLAY)
        {
            countdownUI.SetActive(false);
        }
        pauseSystem();
        CheckCompletion();
        CheckGameOver();
        UpdateTimer();
        UpdateProgress();
        UpdateEnergy();
    }  
}
