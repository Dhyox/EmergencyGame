using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRight : MonoBehaviour
{
    Animator anim;
    float MoveSpd = 3f;
    public BoxCollider2D bc;
    public Rigidbody2D rb;
    public bool Move = false;
    public Transform EnemyAlien;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Move = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();

        
    }

    public void MoveRight()
    {
        if (Move == true)
        {
            transform.Rotate(0f, 180f, 0f);
            rb.velocity = new Vector2(+MoveSpd, rb.velocity.y);

        }
        anim.SetFloat("WalkHorizontal", 1);
    }

}
