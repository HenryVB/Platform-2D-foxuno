using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSUIManager : MonoBehaviour
{
    public static LSUIManager instance;

    [SerializeField]
    private Image fadeScreen;
    [SerializeField]
    private float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    [SerializeField]
    private GameObject levelInfoPanel;
    
    [SerializeField]
    private TextMeshProUGUI textLevelName, txtGemsFound, txtGemsTarget,txtBestTime,txtTimeTarget;

    public float FadeSpeed { get => fadeSpeed; set => fadeSpeed = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("AWAKE LUISMANAGER");
        Debug.Log("INSTANCE VALUE: "+instance);
        if (instance == null)
        {
            Debug.Log("Instanciando LUISMANAGER");
            instance = this;
        }
            
    }
    void Start()
    {
        FadeFromBlack(); //transicion de inicio
    }

    // Update is called once per frame
    void Update()
    {
        ToogleFade();
    }

    private void ToogleFade()
    {
        if (shouldFadeToBlack)
        {

            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {

            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void ShowInfo(MapPoint levelInfo) { 
        
        textLevelName.text = levelInfo.LevelName;
        txtGemsFound.text = "FOUND: " + levelInfo.GemsCollected;
        txtGemsTarget.text = "IN LEVEL: " + levelInfo.TotalGems;

        txtTimeTarget.text = "TARGET: " + levelInfo.TargetTime + "s";

        if(levelInfo.BestTime == 0)
        {
            txtBestTime.text = "BEST ---";
        }
        else
        {
            txtBestTime.text = "BEST: "+ levelInfo.BestTime.ToString("F2") + "s";
        }


        levelInfoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);
    }
}
