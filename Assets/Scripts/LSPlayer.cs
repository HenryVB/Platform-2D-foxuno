using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    [SerializeField]
    private MapPoint currentPoint;
    private float moveSpeed = 10f;
    private bool levelLoading;
    
    [SerializeField]
    private LSManager LSManager;
    public MapPoint CurrentPoint { get => currentPoint; set => currentPoint = value; }

    // Start is called before the first frame update
    void Start()
    {
        levelLoading = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentPoint.transform.position,moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f) {
            MapMovement();
        }


    }

    private void MapMovement()
    {
        if (Input.GetAxisRaw("Horizontal") > .5f)
        {
            if (currentPoint.Right != null)
                SetNextPoint(currentPoint.Right);
        }

        if (Input.GetAxisRaw("Horizontal") < -.5f)
        {
            if (currentPoint.Left != null)
                SetNextPoint(currentPoint.Left);
        }

        if (Input.GetAxisRaw("Vertical") > .5f)
        {
            if (currentPoint.Up != null)
                SetNextPoint(currentPoint.Up);
        }

        if (Input.GetAxisRaw("Vertical") < -.5f)
        {
            if (currentPoint.Down != null)
                SetNextPoint(currentPoint.Down);
        }

       

        if (currentPoint.IsLevel && currentPoint.LevelToLoad != "" && !currentPoint.IsLocked)
        {
            LSUIManager.instance.ShowInfo(currentPoint); // Show Level Name

            if (Input.GetButtonDown("Jump"))
            {
                levelLoading = true;
                LSManager.LoadLevel();
            }
        }
    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUIManager.instance.HideInfo(); // Hide Level Name
    }
}
