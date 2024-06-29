using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private Animator animator;
    private float bounceForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.instance.Rb.velocity = new Vector3(Player.instance.Rb.velocity.x,bounceForce);
            animator.SetTrigger("Bounce");
        }
    }
}
