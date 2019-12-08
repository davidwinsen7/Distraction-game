using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum ItemCode
    {
        focus = 0,
        brainStorm = 1
    };
    public PowerUp[] Items;

    [Header("Power Up UI")]
    [SerializeField] GameObject focusUI;
    [SerializeField] GameObject brainStormUI;

    GameManager manager;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void Update()
    {
        checkFocus();
        checkBrainStorm();
    }  
    void checkFocus()
    {
        if (Items[(int)ItemCode.focus].Active)
        {
            focusUI.SetActive(true);
            manager.usedProgressMultiplier = manager.progressMultiplier * 2f;
            Items[(int)ItemCode.focus].countUp += Time.deltaTime;
            if(Items[(int)ItemCode.focus].countUp >= Items[(int)ItemCode.focus].duration)
            {
                Items[(int)ItemCode.focus].Active = false;
            }
        }
        else
        {
            focusUI.SetActive(false);
            manager.usedProgressMultiplier = manager.progressMultiplier;
        }
    }
    void checkBrainStorm()
    {
        if (Items[(int)ItemCode.brainStorm].Active)
        {
            brainStormUI.SetActive(true);
            Items[(int)ItemCode.brainStorm].countUp += Time.deltaTime;
            if(Items[(int)ItemCode.brainStorm].countUp >= Items[(int)ItemCode.brainStorm].duration)
            {
                Items[(int)ItemCode.brainStorm].Active = false;
            }
        }
        else
        {
            brainStormUI.SetActive(false);
        }
    }
}
