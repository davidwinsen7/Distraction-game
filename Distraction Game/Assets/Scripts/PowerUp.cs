using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp
{
    public string Name;
    public bool Active;
    [Range(0f,10f)]public float duration;
    [HideInInspector] public float countUp = 0f;
}
