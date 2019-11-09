﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public float DragDelay;
    private float currentDelay;
    public float drainEnergy; //Energy drained per 1 drag and drop
    GameManager manager;
    private bool selected;
    private bool delaying = false;

    public DistractionProperties properties;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        currentDelay = DragDelay;
    }
    void Update()
    {
        if(properties.health <= 0)
        {
            Destroy(gameObject);
        }
        if (selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
        if (delaying)
        {
            currentDelay -= Time.deltaTime;
        }
        if(currentDelay <= 0)
        {
            delaying = false;
            currentDelay = DragDelay;
        }
       
    }
  
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && delaying == false && manager.energy > 0&&manager.gameState == GameManager.State.GAMEPLAY)
        {
            selected = true;
        }
    }
    private void OnMouseUp()
    {
        if (!delaying && manager.energy >0 && manager.gameState == GameManager.State.GAMEPLAY) {
            manager.energy -= drainEnergy;
            properties.health -= 1;
        }
        delaying = true;
    }
}
