using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseWinner;
    [SerializeField] private GameObject quitMenu;
    
    [SerializeField] private GameObject panelMenu;
    public PlumasManager plumasManager;

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
        string scene = SceneManager.GetActiveScene().name;

        if (scene == "Plumas"){
            int cantidadPlumasWhite = plumasManager.PlumasTotalesWhiteDuck;
            int cantidadPlumasBlack = plumasManager.PlumasTotalesBlackDuck;
            if(cantidadPlumasBlack == 5 || cantidadPlumasWhite == 5){
                int mayor = plumasManager.PlumasTotalesWhiteDuck;
                int menor = plumasManager.PlumasTotalesBlackDuck;
                if (mayor < menor){
                    mayor = plumasManager.PlumasTotalesBlackDuck;
                    menor = plumasManager.PlumasTotalesWhiteDuck;
                }
            StatusWinner();    
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
        quitMenu.SetActive(true);
        panelMenu.SetActive(false);
    }

    //volver a menu de pausa
    public void ReturnMenuPause()
    {
        quitMenu.SetActive(false);
        panelMenu.SetActive(true);
    }
    public void QuitPlay()
    {
        //salir de la partida
            SceneManager.LoadScene("menu");
    
    }

    public void QuitGame()
    {
        //salir del juego
        Debug.Log("Closing game");
        Application.Quit();
    }

    public void StatusWinner(){
        Time.timeScale = 0f;
        pauseWinner.SetActive(true);
    }
}
