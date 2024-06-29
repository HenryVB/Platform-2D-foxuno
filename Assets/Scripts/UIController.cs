using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]
    private Sprite heartFull, heartEmpty,heartHalf;

    [SerializeField]
    private Image heart1, heart2, heart3;

    [SerializeField]
    private TextMeshProUGUI txtGem;

    [SerializeField]
    private Image fadeScreen;
    [SerializeField]
    private float fadeSpeed;
    private bool shouldFadeToBlack,shouldFadeFromBlack;
    
    [SerializeField]
    private GameObject txtLevelComplete;
    public float FadeSpeed { get => fadeSpeed; set => fadeSpeed = value; }
    public GameObject TxtLevelComplete { get => txtLevelComplete; set => txtLevelComplete = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGemCountDisplay();
        Debug.Log("Fade from black - Start");
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

    public void UpdateHealthDisplay()
    {
        Debug.Log("Vidas: "+PlayerHealth.instance.CurrentHealth);
        switch (PlayerHealth.instance.CurrentHealth)
        {
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3  .sprite = heartEmpty;
                break;

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;

            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;

            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }

    public void UpdateGemCountDisplay()
    {
        txtGem.text = LevelManager.instance.GemsCollected.ToString();
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
}
