using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField]
    private GameObject deathEffectPreFab;
    [SerializeField]
    [Range(0f, 100f)]
    private float probabilityToDrop;
    [SerializeField]
    private GameObject itemToDrop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffectPreFab,other.transform.position,other.transform.rotation);
            Player.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect < probabilityToDrop)
            {
                Instantiate(itemToDrop, other.transform.position, other.transform.rotation);
            }

            //sound index to destroy enemy
            AudioManager.instance.PlaySFX(3);

        }
    }
}
