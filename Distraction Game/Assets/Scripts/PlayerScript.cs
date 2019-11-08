using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameManager manager;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Distractions"))
        {
            float duration = collision.GetComponent<DragAndDrop>().properties.duration;
            Destroy(collision.gameObject);
            manager.gameState = GameManager.State.DISTRACTED;
            StartCoroutine(distracted(duration));
        }
    }
    IEnumerator distracted(float duration)
    {
        yield return new WaitForSeconds(duration);
        manager.gameState = GameManager.State.GAMEPLAY;
    }

}
