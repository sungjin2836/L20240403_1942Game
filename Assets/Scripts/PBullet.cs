using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�̻��� ���ʹ������� �����̱�
        //���� ���� * ���ǵ� * ����
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
      Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //���� ����
            Destroy(collision.gameObject);
            //������ �ֱ�

            //����Ʈ ����

            //�̻��� ����
            Destroy(gameObject);
        }
    }
}
