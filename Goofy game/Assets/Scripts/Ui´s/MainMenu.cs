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


     //Botones en single Player mode
   public void Farm()
    {
        SceneManager.LoadScene("Granja");
    }
    public void Beach()
    {
        SceneManager.LoadScene("Playa");
    }
    public void IceLand()
    {
        SceneManager.LoadScene("Nieve");
    }


    //Botones de multi player mode
    public void Versus()
    {
        SceneManager.LoadScene("Versus");
    }
    public void Plumas()
    {
        SceneManager.LoadScene("Plumas");
    }

    public void BabyDucks()
    {
        SceneManager.LoadScene("BabyDucks");
    }
    public void Quit()
    //Boton para salir del juego
    {
        Debug.Log("Closing game");
        Application.Quit();
    }    
    
}