using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    public GameObject[] inventory; 
    public int inventorySize = 5;  

    private void Start()
    {
       
        inventory = new GameObject[inventorySize];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            
            int layerMask = LayerMask.GetMask("UI");

            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
              
                if (Vector3.Distance(transform.position, hit.transform.position) <= 2f)
                {
                    AddToInventory(hit.collider.gameObject);
                }
            }
        }
    }

    private void AddToInventory(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null) 
            {
                inventory[i] = item; 
                item.SetActive(false); 
                break; 
            }
        }
    }
}
