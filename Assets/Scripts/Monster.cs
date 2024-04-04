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
        //�ѹ� �Լ� ȣ��
        Invoke("CreateBullet", Delay);

        //Debug.Log("CreateBullet ȣ��");
    }

    void CreateBullet()
    {
        Debug.Log("bullet ����");
        Instantiate(bullet, ms.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);


        //�ڱ� �ڽ��� �ѹ� �� �θ� - ����Լ�
        //Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        // �Ʒ� �������� ������
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
            Debug.Log("������ ����");
            Instantiate(item, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("������ ����X");
        }
    }

}
