using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    enum distractionCode
    {
        Sleeping = 0,
        Nap = 1
    };
    [SerializeField] GameObject[] distractedUI;
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
            float affectEnergy = collision.GetComponent<DragAndDrop>().properties.affectEnergy;
            string name = collision.gameObject.name;
            Destroy(collision.gameObject);
            manager.gameState = GameManager.State.DISTRACTED;
            StartCoroutine(distracted(duration, affectEnergy, name));
        }
    }
    IEnumerator distracted(float duration, float affectEnergy, string name)
    {
        switch (name)
        {
            case "Sleep(Clone)":
                distractedUI[(int)distractionCode.Sleeping].SetActive(true);
                yield return new WaitForSeconds(duration);
                manager.energy += affectEnergy;
                distractedUI[(int)distractionCode.Sleeping].SetActive(false);
                break;
            case "Nap(Clone)":
                distractedUI[(int)distractionCode.Nap].SetActive(true);
                yield return new WaitForSeconds(duration);
                manager.energy += affectEnergy;
                distractedUI[(int)distractionCode.Nap].SetActive(false);
                break;
        }     
        manager.gameState = GameManager.State.GAMEPLAY;
    }

}
