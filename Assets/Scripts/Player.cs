using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Movement")]
    [SerializeField]
    private float speed;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce;
    private bool canDoubleJump;

    [Header("Bounce after enemy dies")]
    [SerializeField]
    private float bounceForce;

    [Header("Components")]
    private Rigidbody2D rb;

    //Point in map to check player in ground
    [Header("Ground Check")]
    [SerializeField]
    private Transform groundCheckPoint;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;

    [Header("Animations")]
    private Animator animation;
    private SpriteRenderer sr;

    private bool stopInputMove;

    public Animator Animation { get => animation; set => animation = value; }
    public bool StopInputMove { get => stopInputMove; set => stopInputMove = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    private void Awake()
    {
        if (instance == null)
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.IsPaused && !stopInputMove)
        {
            HorizontalMovement();

            Jump();

            UpdateAnimations();
        }
    }

    private void HorizontalMovement()
    {
        float horizontalMove = speed * Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontalMove, rb.velocity.y);

        //Flip Sprite to X side. Can use rotation also
        if (rb.velocity.x < 0)
            sr.flipX = true;
        else sr.flipX = false;

        //Is on the floor or not adding collider to compare with ground vs point ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (isGrounded)
            canDoubleJump = true;

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            

            if (isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
                AudioManager.instance.PlaySFX(10);
            }
                

            else
                if (canDoubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
                AudioManager.instance.PlaySFX(10);
                canDoubleJump = false;
            }

        }
    }

    private void UpdateAnimations()
    {
        //set animations values
        animation.SetFloat("speedAnim", Mathf.Abs(rb.velocity.x)); //Absolute value of movement
        animation.SetBool("isGroundedAnim", isGrounded); //Value of isGrounded
    }

    public void Bounce()
    {
        rb.velocity = new Vector3(rb.velocity.x,bounceForce);
    }
}
