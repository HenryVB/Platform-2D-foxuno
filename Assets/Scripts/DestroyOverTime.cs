using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        timeDestroy = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeDestroy);
    }
}
