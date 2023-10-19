using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    //Boton que pasa de start a menu
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    //Noton para salir del juego
    {
        Application.Quit();
    }
}