using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [SerializeField]
    private Transform target; //Player

    [SerializeField]
    private Transform farBackground, midBackground;

    private Vector2 lastPosXY;
    
    [SerializeField]
    private float minHeight, maxHeight; //min and max height of camera on Y

    [SerializeField]
    private bool stopFollow;

    public bool StopFollow { get => stopFollow; set => stopFollow = value; }


    private void Awake()
    {
        if(instance == null)
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //init with camera x position
        lastPosXY = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopFollow)
        {
            //Move camera to Player x position then to player y position and z same of camera
            float verticalCameraAligment = Mathf.Clamp(target.position.y, minHeight, maxHeight);
            transform.position = new Vector3(target.position.x, verticalCameraAligment, transform.position.z);

            //Camera actual position - last camera position
            Vector2 amountMoveXY = new Vector2(transform.position.x - lastPosXY.x, transform.position.y - lastPosXY.y);
            float delayMidBGMove = 0.5f;

            //Update Background and midBG position to move with camera
            farBackground.position += new Vector3(amountMoveXY.x, amountMoveXY.y, 0);
            midBackground.position += new Vector3(amountMoveXY.x, amountMoveXY.y, 0) * delayMidBGMove;

            lastPosXY = transform.position;
        }

    }

}
