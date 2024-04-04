using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterCreate : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public GameObject Monster;
    public GameObject Boss1;
    public GameObject Boss2;
    public float StartTime = 2;
    public int BossGenTime = 0;
    public int BossGenCount = 0;

    void Start()
    {
        //StartCoroutine("CreateMonster");
        //InvokeRepeating("CreateMonsterSolo", 1, 3);
        StartCoroutine(CreateMonsterSolo());
        //StartCoroutine(RandomSpawn());
        StartCoroutine(BossGen());
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(StartTime);
            int i = Random.Range(0, gameObjects.Count);
            Debug.Log("·£´ý ¼ýÀÚ " + i);
            Instantiate(gameObjects[i].gameObject, transform.position, Quaternion.identity);
        }
    }



    //void CreateMonsterSolo()
    //{
    //    float xSite = Random.Range(-2, 2);
    //    Vector3 vector3 = new Vector3(xSite, transform.position.y, 0);
    //    Instantiate(Monster, vector3, Quaternion.identity);
    //}

    IEnumerator CreateMonsterSolo()
    {
        while (true)
        {
            yield return new WaitForSeconds(StartTime);
            float xSite = Random.Range(-2, 2);
            Vector3 vector3 = new Vector3(xSite, transform.position.y, 0);
            Instantiate(Monster, vector3, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    IEnumerator RandomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(StartTime);
            int i = Random.Range(0, gameObjects.Count);
            Debug.Log("·£´ý ¼ýÀÚ " + i);
            Instantiate(gameObjects[i].gameObject, transform.position, Quaternion.identity);
        }
    }

    void CreateBoss(int i)
    {
        if(i == 1)
        {
            Instantiate(Boss1, transform.position, Quaternion.identity);
        }
        else
        {
             if(i == 2)
            {
                Instantiate(Boss2, transform.position, Quaternion.identity);
            }
        }

    }

    IEnumerator BossGen()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            BossGenTime += 1;
            

            Debug.Log(BossGenTime);
            if (BossGenTime > 10 && BossGenCount == 0)
            {
                CreateBoss(1);
                BossGenCount++;
            }
            else if(BossGenTime > 20 && BossGenCount == 1)
            {
                CreateBoss(2);
                BossGenCount++;
            }
        }
    }



}
