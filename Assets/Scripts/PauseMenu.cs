using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    [SerializeField]
    private string levelSelect, mainMenu;

    [SerializeField]
    private GameObject pauseScreen;
    private bool isPaused;

    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            TooglePause();
        }
    }

    public void TooglePause()
    {
       
        if (isPaused)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        isPaused = !isPaused;
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
