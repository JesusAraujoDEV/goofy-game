using UnityEngine.SceneManagement;
using UnityEngine;


public class Main_Start : MonoBehaviour
{
    
    public void StartGame()
    //Boton que pasa de start a menu
    {
        SceneManager.LoadScene("menu");
    }
    public void SkinGame()
    {
        SceneManager.LoadScene("skin");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("play_mode");
    }
    public void QuitGame()
    //Noton para salir del juego
    {
        Application.Quit();
    }    
    
}