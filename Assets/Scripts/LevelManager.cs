using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    [SerializeField]
    private int waitToRespawn;

    private int gemsCollected;
    private float timeInLevel;
    
    [SerializeField]
    private string nextLevel;

    public int GemsCollected { get => gemsCollected; set => gemsCollected = value; }
    public float TimeInLevel { get => timeInLevel; set => timeInLevel = value; }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        instance = this;
    }

    private void Start()
    {
        gemsCollected = 0;
        timeInLevel = 0f;    
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCR());
    }

    IEnumerator RespawnCR() {
        Debug.Log("Corrutina");
        Player.instance.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(waitToRespawn - (1f/UIController.instance.FadeSpeed));
        UIController.instance.FadeToBlack(); //transicion para mostrar de negro

        yield return new WaitForSeconds((1f / UIController.instance.FadeSpeed) + 0.2f);
        UIController.instance.FadeFromBlack(); //transicion para mostrar otra vez la pantalla

        Player.instance.transform.position = CheckPointController.instance.SpawnPoint;
        PlayerHealth.instance.initLifes();
        //Se coloca aqui porque al parecer la corrutina sale y no sigue el flujo hasta 5s
        UIController.instance.UpdateHealthDisplay();
        Player.instance.gameObject.SetActive(true);
    }

    public void EndLevel() {
        StartCoroutine(EndLevelCR());
    }

    IEnumerator EndLevelCR()
    {
        AudioManager.instance.PlayLevelVictory();

        Player.instance.StopInputMove = true; //stop player
        CameraController.instance.StopFollow = true; // stop camera to follow player+bg
        UIController.instance.TxtLevelComplete.SetActive(true); //Texto level complete
        
        yield return new WaitForSeconds(1.5f); //wait for fade to black
        
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.FadeSpeed) + 0.25f); //wait for next level

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"_unlocked",1); //Save info sobre el nivel superado

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if(gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected); //Save info sobre las gemas recolectadas
        }

        else
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected); //Save info sobre las gemas recolectadas

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel > PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", TimeInLevel); //Save info sobre el nivel superado

        }

        else
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", TimeInLevel); //Save info sobre el nivel superado



        SceneManager.LoadScene(nextLevel);
    }
}
