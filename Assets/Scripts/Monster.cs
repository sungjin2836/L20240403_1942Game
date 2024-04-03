using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 2;
    private float Delay = 5f;
    public Transform ms;
    public Transform ms2;
    public GameObject bullet;
    public GameObject item;


    void Start()
    {
        //한번 함수 호출
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //자기 자신을 한번 더 부름 - 재귀함수
        Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        // 아래 방향으로 움직임
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(item, transform.position, Quaternion.identity);
        //Destroy(collision.gameObject);
        Destroy(gameObject);

    }

}
