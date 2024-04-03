using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float Speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
