using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPlayer : MonoBehaviour
{
    [Range(0.5f,5f)]
    [SerializeField] float currentSpeed = 1f;
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, currentSpeed * Time.deltaTime);
    }
}
