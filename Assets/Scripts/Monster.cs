using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 2;
    private float Delay = 1f;
    public Transform ms;
    public Transform ms2;
    public GameObject bullet;
    public GameObject item;

    public int HP;



    void Start()
    {
        //한번 함수 호출
        Invoke("CreateBullet", Delay);

        //Debug.Log("CreateBullet 호출");
    }

    void CreateBullet()
    {
        Debug.Log("bullet 생성");
        Instantiate(bullet, ms.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);


        //자기 자신을 한번 더 부름 - 재귀함수
        //Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        // 아래 방향으로 움직임
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    public void Damage(int attack)
    {
        HP -= attack;
        if(HP < 0)
        {
            ItemSPawn();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemSPawn();
        //Destroy(collision.gameObject);
        //Destroy(gameObject);

    }


    void ItemSPawn()
    {
        int rand = Random.Range(0, 10);

        if (rand > 8)
        {
            Debug.Log("아이템 생성");
            Instantiate(item, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("아이템 생성X");
        }
    }

}
