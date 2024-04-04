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
        //Physics Material 2D�� ���� �־� ���� ������ ƨ��� ���� ����

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.down * Speed * yView * Time.deltaTime);
        transform.Translate(Vector2.right * Speed * xView * Time.deltaTime);


        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.

        if(viewPos.x == 0 || viewPos.x == 1)
        {
            xView *= -1;
        }

        if (viewPos.y == 0 || viewPos.y == 1)
        {

            Debug.Log("y��");
            yView *= -1;
        }

    }
}
