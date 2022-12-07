using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseLeft : MonoBehaviour
{
    Animator anim;
    float MoveSpd = 3f;
    public BoxCollider2D bc;
    public Rigidbody2D rb;
    public bool Move = false;
    public Transform EnemyAlien;
    public bool test = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            
            Move = true;
        }
        if (collision.gameObject.GetComponent<Player>() != null)
        {

            test = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Move = false;
        }
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            test = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        MoveLeft();
        if (Move == false && test == true)
        {
            Move = false;
            Move = true;
            Debug.Log("1 false");
        }
        else if (test == false && Move == true)
        {
            test = false;
            test = true;
            Debug.Log("1 false");
        }
        else if (test == false && Move == false)
        {
            Debug.Log("The f");
        }

    }

    public void MoveLeft()
    {
        if (Move == true && test == true)
        {
            rb.velocity = new Vector2(-MoveSpd, rb.velocity.y);
            Debug.Log("All clear");
        }
        
        
    }

    
}
