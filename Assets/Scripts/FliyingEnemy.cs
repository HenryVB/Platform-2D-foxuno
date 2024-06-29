using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliyingEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private float speed;
    private int currentPoint;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private float distanceToAtk, chaseSpeed;

    private Vector3 attackTarget;
    public float waitAfterAttack;
    private float attackCounter;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null; //independizar los puntos del enemigo
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(attackCounter > 0)
            attackCounter -= Time.deltaTime;

        else
        {
            if (Vector3.Distance(transform.position, Player.instance.transform.position) > distanceToAtk)
            {
                attackTarget = Vector3.zero;
                MoveAI();
            }

            else
            {
                if (attackTarget == Vector3.zero)
                {
                    attackTarget = Player.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }

            
    }

    private void MoveAI() {
        
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.5f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0; // reinit recorrido
            }
        }

        if (transform.position.x < points[currentPoint].position.x)
        {
            sr.flipX = true;
        }
        else if (transform.position.x > points[currentPoint].position.x)
        {
            sr.flipX = false;
        }

    }
}
