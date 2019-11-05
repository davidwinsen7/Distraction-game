using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    GameManager manager;
    private int roundedDeadline;

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
    
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void Update()
    {
        UpdateTimer();
        UpdateProgress();
        UpdateEnergy();
    }  
}
