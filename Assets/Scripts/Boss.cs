using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float Speed = 2;
    private float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public Transform ms3;
    public Transform ms4;
    public GameObject bullet;
    public GameObject item;
    public GameObject effect;

    private float bossHP = 100f;


    void Start()
    {
        //�ѹ� �Լ� ȣ��
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Debug.Log("���� ����");
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
        Instantiate(bullet, ms3.position, Quaternion.identity);
        Instantiate(bullet, ms4.position, Quaternion.identity);

        //�ڱ� �ڽ��� �ѹ� �� �θ� - ����Լ�
        Invoke("CreateBullet", Delay);
    }

    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("MBullet"))
        {
            
            bossHP -= 10;
            Destroy(collision.gameObject);

            if (bossHP < 0)
            {
                Instantiate(item, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        

    }
}
