using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTank : MonoBehaviour
{
    private enum bossStateMachine { shooting,hurt,moving,defeated};
    private bossStateMachine currentState;

    [SerializeField]
    private Transform boss;
    [SerializeField]
    private Animator anim;

    [Header("Movement")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform leftPoint, rightPoint;
    private bool moveRight;

    [Header("Mine")]
    [SerializeField]
    private GameObject mine;
    [SerializeField]
    private Transform minePoint;
    [SerializeField]
    private float timeBetweenMines;
    private float mineCounter;



    [Header("Shooting")]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float timeBetweenShots;
    private float shotCounter;
        
    [Header("Hurt")]
    [SerializeField]
    private float hurtTime;
    private float hurtCounter;

    [SerializeField]
    private GameObject hitBox;

    [Header("Health")]
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject explosion,winPlatform;
    private bool isDefeated;

    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStateMachine.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossStateMachine.shooting:
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0) { 
                    shotCounter = timeBetweenShots;

                    var newBullet = Instantiate(bullet,firePoint.position,firePoint.rotation);
                    newBullet.transform.localScale = boss.localScale;
                }
                break;
            case bossStateMachine.hurt:
                if (hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;
                    if (hurtCounter < 0)
                    {
                        currentState = bossStateMachine.moving;
                        mineCounter = 0;

                        if (isDefeated)
                        {
                            boss.gameObject.SetActive(false);
                            Instantiate(explosion, boss.position, boss.rotation);

                            winPlatform.SetActive(true);

                            AudioManager.instance.StopBossMusic();

                            currentState = bossStateMachine.defeated;
                        }
                    }
                        
                }
                break;
            case bossStateMachine.moving:
                if (moveRight)
                {
                    boss.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

                    if (boss.position.x > rightPoint.position.x)
                    {
                        boss.localScale = Vector3.one; // (1,1,1) en lugar de realizar el flip del sr para no afectar el firepoint
                        moveRight = false;
                        EndMovement();
                    }
                }
                else
                {
                    boss.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);

                    if (boss.position.x < leftPoint.position.x)
                    {
                        boss.localScale = new Vector3(-1f, 1f, 1f); // en lugar de realizar el flip del sr para no afectar el firepoint
                        moveRight = true;
                        EndMovement();
                    }
                }

                mineCounter -=Time.deltaTime;
                
                if (mineCounter <= 0)
                {
                    mineCounter = timeBetweenMines;
                    Instantiate(mine,minePoint.position,minePoint.rotation);
                }

                break;
        }
    }

    public void TakeHit()
    {
        currentState = bossStateMachine.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");

        BossTankMine [] mines = FindObjectsOfType<BossTankMine>(); 
        
        if(mines.Length > 0) {
            
            foreach (BossTankMine mine in mines) { 
                mine.Explode();
            }
        }

        health--;

        if(health <= 0){
            isDefeated = true;
        }
    }

    private void EndMovement()
    {
        currentState = bossStateMachine.shooting;
        shotCounter = timeBetweenShots;
        anim.SetTrigger("StopMoving");
        hitBox.SetActive(true);
    }
}
