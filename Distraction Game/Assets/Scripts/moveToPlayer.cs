using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPlayer : MonoBehaviour
{
    [Range(0.5f,5f)]
    [SerializeField] float currentSpeed = 1f;
    GameManager manager;
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void Update()
    {
        if(manager.gameState == GameManager.State.GAMEPLAY)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, currentSpeed * Time.deltaTime);
        }
        
    }
}
