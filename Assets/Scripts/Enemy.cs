using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer sr;

    private float moveTime, waitTime; //Time for make movement dynamic stop x seconds and then move
    private float moveCount, waitCount; //Counter to move or stop


    [Header("Animations")]
    private Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //para desvincularlo del mov del enemigo
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
        
        moveTime = 3;
        waitTime = 2;

        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {

        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            MoveAI();
            

            if (moveCount <=0)
                waitCount = Random.Range(waitTime * 0.75f,waitTime * 1.25f);

           
        }

        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            
            stopMoveAI();

            if (waitCount <= 0)
                moveCount = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
            
        }

    }

    private void MoveAI()
    {
        if (movingRight)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y);
            sr.flipX = true;
            if (transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
            sr.flipX = false;
            if (transform.position.x < leftPoint.position.x)
            {
                movingRight = true;
            }
        }

        animation.SetBool("isMovingAnim", true); //anim is moving
    }

    private void stopMoveAI()
    {
        rb.velocity = new Vector3(0f, rb.velocity.y);
        animation.SetBool("isMovingAnim", false); //anim is moving
    }
}
