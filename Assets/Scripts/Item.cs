using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float Speed = 2;
    private float xView = 1;
    private float yView = 1;

    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;

    void Start()
    {
        //rig = GetComponent<Rigidbody2D>();
        //rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0));
        //Physics Material 2D를 벽에 넣어 벽에 닿으면 튕기게 설정 가능

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.down * Speed * yView * Time.deltaTime);
        transform.Translate(Vector2.right * Speed * xView * Time.deltaTime);


        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.

        if(viewPos.x == 0 || viewPos.x == 1)
        {
            xView *= -1;
        }

        if (viewPos.y == 0 || viewPos.y == 1)
        {

            Debug.Log("y축");
            yView *= -1;
        }

    }
}
