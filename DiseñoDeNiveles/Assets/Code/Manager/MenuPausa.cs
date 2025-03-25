using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public bool isPaused;
    private Controller player;
    private CodigoPuerta codigoPuerta;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Controller>();
        codigoPuerta = GameObject.FindWithTag("PuertaCode").GetComponent<CodigoPuerta>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && codigoPuerta.panelactive == false)
        {

                PauseGame();
        }
    }
    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            //Reanudamos el tiempo de juego
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            player.jumpForce = 0f;
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        player.jumpForce = 300f;
    }
    public void ShowOMMenu()
    {
        optionMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGameFromOM()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        PauseGame();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
