using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    

    
    float MoveSpd;
    Animator anim;
    public Rigidbody2D rb;
    private PolygonCollider2D pc;
    private BoxCollider2D bc;
    bool FaceRight;
    private float TravelDistance;
    private float MaxTravelDistance;
    private float HP;
    private int Direction;
    [SerializeField] float MaxHP = 5f;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            MaxHP -= 1;
            if (MaxHP == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    


    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        MoveSpd = 3;
        TravelDistance = 0;
        anim = GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        pc = transform.GetComponent<PolygonCollider2D>();
        bc = transform.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            
        }
        
        /*
        if (TravelDistance > 200f)
            {
                MoveRight();
                if (TravelDistance == 400)
                {
                    TravelDistance = 0;
                }
            }
            else if (TravelDistance <= 200f)
            {
                MoveLeft();
            }
        */
    }


       

    private void MoveLeft()
    {
        rb.velocity = new Vector2(-MoveSpd, rb.velocity.y);
        if (FaceRight == true)
        {
            FaceRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        anim.SetFloat("WalkHorizontal", -1);
        TravelDistance++;
    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(+MoveSpd, rb.velocity.y);
        if (FaceRight == false)
        {
            FaceRight = true;
            transform.Rotate(0f, -180f, 0f);
        }
        anim.SetFloat("WalkHorizontal", 1);
        TravelDistance++;
    }

}
