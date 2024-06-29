using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite cpOn, cpOff;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCheckpoint()
    {
        sr.sprite = cpOff;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointController.instance.DeactiveCheckPoints(); //desactive all checkpoint
            sr.sprite = cpOn; //active current collide checkpoint
            CheckPointController.instance.setSpawnPoint(transform.position); //checkpoint position
        }
            

    }
}
