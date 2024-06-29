using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private bool isGem;
    [SerializeField]
    private bool isHeal;
    private bool isCollected;
    [SerializeField]
    private GameObject pickupEffectPreFab;

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
        if (other.CompareTag("Player") && !isCollected) {
            if (isGem)
            {
                LevelManager.instance.GemsCollected++;
                UIController.instance.UpdateGemCountDisplay();
                Instantiate(pickupEffectPreFab,transform.position,transform.rotation);
                AudioManager.instance.PlaySFX(6);
                isCollected = true;
                Destroy(gameObject);
            }
            if (isHeal)
            {
                PlayerHealth.instance.AddHealth();
                isCollected = true;
                AudioManager.instance.PlaySFX(7);
                Destroy(gameObject);
            }
        }

        
    }
}
