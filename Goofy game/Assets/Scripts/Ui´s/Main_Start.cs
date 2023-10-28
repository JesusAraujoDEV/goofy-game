using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    
    public void PlayGame()
    //Boton que pasa de menu a play
    {
        SceneManager.LoadScene("play_mode");
    }
    
    //Boton que devuelve al menu de inicio
    public void ReturnMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    //Boton para salir del juego
    {
        Debug.Log("Closing game");
        Application.Quit();
    }    
    
}