using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask WorldLayerMask;
    public static int HP;
    public static int Ammo;
    private int MaxAmmo;
    public static bool pauseToggle;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    float MoveSpd;
    bool FaceRight;
    bool Jumping = false;
    private AudioSource JumpSound;



    Animator anim;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Mati>() != null)
        SceneManager.LoadScene("GameOverScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            HP -= 1;
            //SceneManager.LoadScene("GameOverScene");
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        HP = 3;
        Ammo = 10;
        MaxAmmo = Ammo;
        MoveSpd = 5;
        anim = GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        cc = transform.GetComponent<CapsuleCollider2D>();
        pauseToggle = false;
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (Ammo == 0)
        {
            Ammo = MaxAmmo;
        }
        
        if (IsGrounded())UpdatePosition();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseToggle)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
                

            pauseToggle = !pauseToggle;
        }



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
            JumpSound = GetComponent<AudioSource>();
            JumpSound.Play();
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
