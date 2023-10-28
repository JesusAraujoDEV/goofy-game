using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectionMenu : MonoBehaviour
{
    // Variables
    private int index;
    //Referencia de la imagen
    [SerializeField] private Image imagePlayer;
    
    private ChooseCharacter chooseCharacter;
    private void Start()
    {
        chooseCharacter = ChooseCharacter.Instance;
        index = PlayerPrefs.GetInt("PlayerIndex");

        if (index > chooseCharacter.characters.Count -1)
        {
            index = 0;
        }
        ChangeScreen();
    }
    private void ChangeScreen()
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
        imagePlayer.sprite = chooseCharacter.characters[index].imagePlayer;
        
    }
    //cambio de personaje, buton derecho
    public void NextCharacter()
    {
        //si esta en el ultimo lo devuelve al primero
        if (index == chooseCharacter.characters.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        ChangeScreen();
    }

    //Cambio de personaje, boton izquierdo
    public void FormerCharacter()
    {
        if (index==0)
        {
            index = chooseCharacter.characters.Count - 1;
        }
        else
        {
            index -= 1;
        }
        ChangeScreen();
    }
    public void StarGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
}
