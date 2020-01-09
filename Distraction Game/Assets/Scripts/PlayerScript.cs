using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    enum distractionCode
    {
        Sleeping = 0,
        Nap = 1,
        Gaming = 2,
        Texting = 3,
        Eat = 4,
        Snack = 5
    };
    [SerializeField] GameObject happyFace;
    [SerializeField] GameObject tiredFace;
    [SerializeField] GameObject resistUI;
    public GameObject[] distractedUI;
    GameManager manager;
    ItemManager ItmManager;
    Animator camAnim;
    bool isBrainStorming;
    Resisting resistUIScript;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        ItmManager = FindObjectOfType<ItemManager>().GetComponent<ItemManager>();
        camAnim = FindObjectOfType<Camera>().GetComponent<Animator>();
    }
    void expressionHappy()
    {
        happyFace.SetActive(true);
        tiredFace.SetActive(false);
    }
    void expressionTired()
    {
        tiredFace.SetActive(true);
        happyFace.SetActive(false);
    }
    private void Update()
    {
        isBrainStorming = ItmManager.Items[(int)ItemManager.ItemCode.brainStorm].Active;
        if (manager.energy <= manager.maxEnergy / 5) 
        {
            expressionTired();
        }
        else
        {
            expressionHappy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Distractions") && manager.gameState != GameManager.State.DISTRACTED)
        {
            if (isBrainStorming)
            {
                Destroy(collision.gameObject);
                //"destroyedWithoutEffect" particle
            }
            else
            {
                camAnim.SetTrigger("Shake1");
                float duration = collision.GetComponent<DragAndDrop>().properties.duration;
                float affectEnergy = collision.GetComponent<DragAndDrop>().properties.affectEnergy;
                string name = collision.gameObject.name;
                Destroy(collision.gameObject);
                manager.gameState = GameManager.State.DISTRACTED;
                resistUI.SetActive(true);
                resistUIScript = FindObjectOfType<Resisting>().GetComponent<Resisting>();
                StartCoroutine(distracted(duration, affectEnergy, name));
            }
            
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
            case "Gaming(Clone)":
                distractedUI[(int)distractionCode.Gaming].SetActive(true);
                yield return new WaitForSeconds(duration);
                manager.energy += affectEnergy;
                distractedUI[(int)distractionCode.Gaming].SetActive(false);
                break;
            case "Texting(Clone)":
                distractedUI[(int)distractionCode.Texting].SetActive(true);
                yield return new WaitForSeconds(duration);
                manager.energy += affectEnergy;
                distractedUI[(int)distractionCode.Texting].SetActive(false);
                break;
            case "Eat(Clone)":
                distractedUI[(int)distractionCode.Eat].SetActive(true);
                yield return new WaitForSeconds(duration);
                manager.energy += affectEnergy;
                distractedUI[(int)distractionCode.Eat].SetActive(false);
                break;
            case "Snack(Clone)":
                distractedUI[(int)distractionCode.Snack].SetActive(true);
                yield return new WaitForSeconds(duration);
                manager.energy += affectEnergy;
                distractedUI[(int)distractionCode.Snack].SetActive(false);
                break;
        }     
        manager.gameState = GameManager.State.GAMEPLAY;
        resistUIScript.resistanceBar.value = 0f;
        resistUI.SetActive(false);
        
    }

}
