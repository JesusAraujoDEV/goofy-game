using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterManager : MonoBehaviour
{
    private int index;
    //Referencia de la imagen 1 
    [SerializeField] private Image characterSprite;
    private CharacterDataBase characterDataBase;
    
    private void Start()
    {
        characterDataBase = CharacterDataBase.Instance;
        index = PlayerPrefs.GetInt("PlayerIndex");

        if (index > characterDataBase.character.Count -1)
        {
            index = 0;
        }
        ChangeScreen();
    }
    private void ChangeScreen()
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
        characterSprite.sprite = characterDataBase.character[index].characterSprite;

    }
    //cambio de personaje, buton derecho
    public void NextCharacter()
    {
        //si esta en el ultimo lo devuelve al primero
        if (index == characterDataBase.character.Count - 1)
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
            index = characterDataBase.character.Count - 1;
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
