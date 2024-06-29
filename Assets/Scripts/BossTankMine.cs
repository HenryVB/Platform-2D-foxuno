using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMine : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    
    [SerializeField]
    private int damage;

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
        if(other.tag == "Player")
        {
            Explode();
            PlayerHealth.instance.DealDamage(damage);
        }        
    }

    public void Explode() {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
