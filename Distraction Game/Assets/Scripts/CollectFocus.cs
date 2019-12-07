using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFocus : MonoBehaviour
{
    ItemManager ItmManager;
    private void Start()
    {
        ItmManager = FindObjectOfType<ItemManager>().GetComponent<ItemManager>();
    }
    private void OnMouseDown()
    {
        Debug.Log("Collect Focus");
        ItmManager.Items[0].Active = true;
        ItmManager.Items[0].countUp = 0f;
        Destroy(gameObject);
    }
}
