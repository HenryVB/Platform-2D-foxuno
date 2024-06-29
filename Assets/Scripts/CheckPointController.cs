using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;
    private Checkpoint[] checkpoints;

    private Vector3 spawnPoint;

    public Vector3 SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        instance = this;
    }

    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>(); //search all checkpoint objects
        spawnPoint = Player.instance.transform.position; //init in player initial position
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactiveCheckPoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void setSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
