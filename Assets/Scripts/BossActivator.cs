using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject theBossBattle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            theBossBattle.SetActive(true);
            gameObject.SetActive(false); //desactivo el activador
            AudioManager.instance.PlayBossMusic();
        }
    }
}
