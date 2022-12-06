using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTest : MonoBehaviour
{
    int movespeed = 5;
    bool move = false;
    public Transform EnemyAlien;
    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Grid>() != null)
        {
            move = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {

        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {



    }
    void MoveLeft()
    {
        rb.velocity = new Vector2(-movespeed, rb.velocity.y);
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(movespeed, rb.velocity.y);
    }

}