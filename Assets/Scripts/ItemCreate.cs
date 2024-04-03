using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    public GameObject item;

    void Start()
    {
        InvokeRepeating("CreateItem",5f, 5f);
    }

    void CreateItem()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }



    void Update()
    {
        
    }
}
