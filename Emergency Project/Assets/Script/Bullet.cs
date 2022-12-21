using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulMoveSpeed = 10;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            Destroy(gameObject);
        }


        if (collision.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * BulMoveSpeed;
        
    }

}
