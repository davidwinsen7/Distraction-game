using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DistractionProperties
{
    public int health; //How many times we can interact with the distraction before it gets destroyed
    public float duration; //Duration of distraction if it hits player
    public float affectEnergy; //Affected energy whenever distracted by this distraction
    public float affectProgress;
    public GameObject[] itemDrop;
    public int itemDropPercentage;
}
