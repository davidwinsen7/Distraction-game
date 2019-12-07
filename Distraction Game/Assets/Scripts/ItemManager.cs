using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    enum ItemCode
    {
        focus = 0,
        brainStorm = 1
    };
    public PowerUp[] Items;
    GameManager manager;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void Update()
    {
        checkFocus();
    }  
    void checkFocus()
    {
        if (Items[(int)ItemCode.focus].Active)
        {
            Debug.Log(manager.usedProgressMultiplier);
            manager.usedProgressMultiplier = manager.progressMultiplier * 2f;
            Items[(int)ItemCode.focus].countUp += Time.deltaTime;
            if(Items[(int)ItemCode.focus].countUp >= Items[(int)ItemCode.focus].duration)
            {
                Items[(int)ItemCode.focus].Active = false;
            }
        }
        else
        {
            manager.usedProgressMultiplier = manager.progressMultiplier;
        }
    }
}
