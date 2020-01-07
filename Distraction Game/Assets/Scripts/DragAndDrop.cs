using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    public float DragDelay;
    private float currentDelay;
    public float drainEnergy; //Energy drained per 1 drag and drop
    GameManager manager;
    private bool selected;
    private bool delaying = false;
    private Animator anim;

    public DistractionProperties properties;
    private void Start()
    {
        anim = GetComponent<Animator>();
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        currentDelay = DragDelay;
    }
    void Update()
    {
        if(properties.health <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
        if (selected == true)
        {
            
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
        if (delaying)
        {
            currentDelay -= Time.deltaTime;
        }
        if(currentDelay <= 0)
        {
            delaying = false;
            currentDelay = DragDelay;
        }
       
    }
    void DropItem()
    {
        int index = Random.Range(0, properties.itemDropPercentage);
        //Debug.Log(index);
        //i.e. itemdropPercentage+1 =10+1 , Range(0,11)
        if (index < properties.itemDrop.Length)
        {
            Instantiate(properties.itemDrop[index], transform.position, transform.rotation); //Drop Item if index < itemDrop.Length
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && delaying == false && manager.energy > 0&&manager.gameState == GameManager.State.GAMEPLAY && Time.timeScale != 0)
        {
            anim.SetTrigger("Clicked");
            selected = true;
        }
    }
    private void OnMouseUp()
    {
        if (!delaying && manager.energy >0 && manager.gameState == GameManager.State.GAMEPLAY) {      
            manager.energy -= drainEnergy;
            properties.health -= 1;
        }
        delaying = true;
    }
}
