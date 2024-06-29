using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    [SerializeField]
    private MapPoint up,down,left,right;
    [SerializeField]
    private bool isLevel;
    [SerializeField]
    private string levelToLoad,levelToCheck,levelName;
    [SerializeField]
    private bool isLocked;
    [SerializeField]
    private int gemsCollected, totalGems;
    [SerializeField]
    private float bestTime, targetTime;

    [SerializeField]
    private GameObject gemBadge, timeBadge;

    public MapPoint Up { get => up; set => up = value; }
    public MapPoint Down { get => down; set => down = value; }
    public MapPoint Left { get => left; set => left = value; }
    public MapPoint Right { get => right; set => right = value; }
    public bool IsLevel { get => isLevel; set => isLevel = value; }
    public string LevelToLoad { get => levelToLoad; set => levelToLoad = value; }
    public bool IsLocked { get => isLocked; set => isLocked = value; }
    public string LevelName { get => levelName; set => levelName = value; }
    public int GemsCollected { get => gemsCollected; set => gemsCollected = value; }
    public int TotalGems { get => totalGems; set => totalGems = value; }
    public float BestTime { get => bestTime; set => bestTime = value; }
    public float TargetTime { get => targetTime; set => targetTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        if(isLevel && levelToLoad != null)
        {
            if(PlayerPrefs.HasKey(levelToLoad+ "_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            if(gemsCollected >= totalGems && totalGems != 0)
                gemBadge.SetActive(true);

            if(bestTime <= targetTime && bestTime != 0)
                timeBadge.SetActive(true);

            IsLocked = true;

            if(levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        IsLocked = false;
                    }
                }
            }

            if(LevelToLoad == levelToCheck) //first level
            {
                IsLocked=false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
