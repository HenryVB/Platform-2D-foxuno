using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    [SerializeField]
    private BossTank theBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && Player.instance.transform.position.y > transform.position.y)
        {
            theBoss.TakeHit();
            Player.instance.Bounce();
            gameObject.SetActive(false); // hitbox desactivado
        }
    }
}
