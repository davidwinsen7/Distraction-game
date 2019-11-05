using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Distractions"))
        {
            switch (collision.gameObject.name)
            {
                case "Sleep(Clone)":
                    Destroy(collision.gameObject);
                    break;
                case "Nap(Clone)":
                    Destroy(collision.gameObject);
                    break;
            }
        }
    }
 
}
