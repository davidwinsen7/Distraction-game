using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUP : MonoBehaviour
{
    
    ItemManager ItmManager;
    private void Start()
    {
        ItmManager = FindObjectOfType<ItemManager>().GetComponent<ItemManager>();
    }
    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "FocusItem(Clone)":
                Debug.Log("Collected Focus");
                ItmManager.Items[0].Active = true;
                ItmManager.Items[0].countUp = 0f;
                Destroy(gameObject);
                break;
            case "BrainStormItem(Clone)":
                Debug.Log("Collected BrainStorm");
                ItmManager.Items[1].Active = true;
                ItmManager.Items[1].countUp = 0f;
                Destroy(gameObject);
                break;
        }
        
    }
}
