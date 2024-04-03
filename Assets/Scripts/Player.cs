using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int weaponLv = 1;

    Animator ani; // 애니메이터를 가져올 변수

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
            //프리팹 위치 방향 

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

        //화면 못나가게
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("아이템");
        if (collision.CompareTag("Item"))
        {
            if(weaponLv < 4)
            {
            weaponLv++;
            }
            Debug.Log("아이템 먹음");  
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Boss") || collision.CompareTag("MBullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }

}
