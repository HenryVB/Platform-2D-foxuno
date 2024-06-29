using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int currentPoint;
    [SerializeField]
    private Transform platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position,speed*Time.deltaTime);

        if (Vector3.Distance(platform.position, points[currentPoint].position) < 0.5f) {
            currentPoint++;

            if(currentPoint >= points.Length)
            {
                currentPoint = 0; // reinit recorrido
            }
        }
    }
}
