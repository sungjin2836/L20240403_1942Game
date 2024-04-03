using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int weaponLv = 1;

    Animator ani; // �ִϸ����͸� ������ ����

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;

    public Transform pos = null;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1 - 1

        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //������ ��ġ ���� 

            switch (weaponLv)
            {
                case 1:
                    Instantiate(bullet, pos.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bullet2, pos.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bullet3, pos.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(bullet4, pos.position, Quaternion.identity);
                    break;

            }
            
            
            
        }

        transform.Translate(moveX ,moveY, 0);

        //ȭ�� ��������
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("������");
        if (collision.CompareTag("Item"))
        {
            if(weaponLv < 4)
            {
            weaponLv++;
            }
            Debug.Log("������ ����");  
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Boss") || collision.CompareTag("MBullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }

}
