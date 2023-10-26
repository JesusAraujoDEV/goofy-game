using UnityEngine.SceneManagement;
using UnityEngine;


public class Mainmenu : MonoBehaviour
{
    
    public void PlayGame()
    //Boton que pasa de menu a play
    {
        SceneManager.LoadScene("play_mode");
    }
    //Boton que va de menu a skin
    public void SkinGame()
    {
        SceneManager.LoadScene("skin");
    }
    //Boton de Play a modo en sinlge player 
    public void SinglePlayer()
    {
        SceneManager.LoadScene("single_mode");
    }
    //Boton de Play a modo en sinlge player 
    public void MultiPlayer()
    {
        SceneManager.LoadScene("multi_mode");
    }

    public void QuitGame()
    //Boton para salir del juego
    {
        Application.Quit();
    }    
    
}