using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public GameObject Monster;
    void Start()
    {
        InvokeRepeating("CreateMonster", 1, 7);
        InvokeRepeating("CreateMonsterSolo", 1, 3);
    }

    void CreateMonster()
    {
        int i = Random.Range(0, gameObjects.Count);
        Debug.Log("·£´ý ¼ýÀÚ "+i);
        Instantiate(gameObjects[i].gameObject, transform.position, Quaternion.identity);
    }

    void CreateMonsterSolo()
    {
        float xSite = Random.Range(-2, 2);
        Vector3 vector3 = new Vector3(xSite, transform.position.y, 0);
        Instantiate(Monster, vector3, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
