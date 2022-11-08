using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Player : MonoBehaviour
{



    [SerializeField] private LayerMask WorldLayerMask;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    float MoveSpd;
    bool FaceRight;
    bool Jumping = false;

    Animator anim;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<InstaDeath>() != null)
        SceneManager.LoadScene("Level1");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            SceneManager.LoadScene("Level1");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        MoveSpd = 5;
        anim = GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        cc = transform.GetComponent<CapsuleCollider2D>();
        

    }

    

    // Update is called once per frame
    void Update()
    {
        
        
        if (IsGrounded())UpdatePosition();
        
            


        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        
        if (IsGrounded() == true && Input.GetKeyDown(KeyCode.W) || IsGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            Jumping = true;
            Jump();
            
        }
        anim.SetBool("Jumping", !IsGrounded());
    }

    
    private void UpdatePosition()
    { 
        anim.SetFloat("WalkHorizontal", Input.GetAxisRaw("Horizontal"));
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-MoveSpd, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(+MoveSpd, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void MoveLeft()
    {
        if (FaceRight == false)
        {
            FaceRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void MoveRight()
    {
            
        if (FaceRight == true)
        {
            FaceRight = false;
            transform.Rotate(0f, -180f, 0f);
        }
        
    }

    private void Jump()
    {
        if(Jumping)
        {
            
            Jumping = false;
            float JumpVelocity = 10;
            rb.velocity = Vector2.up * JumpVelocity;
        }
         
        
    }

    private bool IsGrounded ()
    {
        RaycastHit2D rcH = Physics2D.CapsuleCast(cc.bounds.center, cc.bounds.size/2, CapsuleDirection2D.Vertical, 0, Vector2.down, 1f, WorldLayerMask);
        return rcH.collider != null;
    }
    
}
