using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Detener tiempo del juego
    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    //Reanudar jugada
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    //reiniciar juego
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //cerrar juego 
    public void Quit()
    {
        Debug.Log("Closing game");
        Application.Quit();
    }
}
