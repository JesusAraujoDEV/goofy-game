using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMode : MonoBehaviour
{
    [SerializeField] private GameObject SinglePlayerButton;
    [SerializeField] private GameObject MultiPlayerButton;
    // Despues de presionar el boton single player
    public void SinglePlayer()
    {
        SinglePlayerButton.SetActive(true);
        MultiPlayerButton.SetActive(false);
    }

    // Despues de presionar el boton multiplayer
    public void MultiPlayer()
    {
        SinglePlayerButton.SetActive(false);
        MultiPlayerButton.SetActive(true);
    }
    // regresar a el menu de play mode
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
