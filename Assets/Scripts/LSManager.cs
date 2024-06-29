using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    [SerializeField]
    private LSPlayer thePlayer;

    private MapPoint[] allPoints;


    // Start is called before the first frame update
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if(point.LevelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.CurrentPoint = point;
                }
            }
        }

        //AudioManager.instance.PlayLevelSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCR());
    }

    IEnumerator LoadLevelCR() { 
        LSUIManager.instance.FadeToBlack();

        yield return new WaitForSeconds((1f/LSUIManager.instance.FadeSpeed) + .25f);
        
        SceneManager.LoadScene(thePlayer.CurrentPoint.LevelToLoad);
    }
}
