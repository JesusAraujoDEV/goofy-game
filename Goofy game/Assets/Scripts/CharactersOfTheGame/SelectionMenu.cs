using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectionMenu : MonoBehaviour
{
    //Al presionar skin
    [SerializeField] private GameObject SaveButton;

    public void Skin()
    {
        SaveButton.SetActive(true);
    }
    //Regresar a main menu
    public void Comeback()
    {
        SaveButton.SetActive(false);
    }


    // Variables
    private int index;
    private int index1;
    //Referencia de la imagen 1 y 2
    [SerializeField] private Image imagePlayer1;
    [SerializeField] private Image imagePlayer2;

    private ChooseCharacter chooseCharacter;
    private void Start()
    {
        chooseCharacter = ChooseCharacter.Instance;
        index = PlayerPrefs.GetInt("PlayerIndex");
        index1 = PlayerPrefs.GetInt("PlayerIndex1");
        if (index > chooseCharacter.characters.Count -1)
        {
            index = 0;
        }

        if (index1 > chooseCharacter.characters.Count -1)
        {
            index1 = 0;
        }
        ChangeScreen();
    }
    private void ChangeScreen()
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
        PlayerPrefs.SetInt("PlayerIndex1", index1);

        imagePlayer1.sprite = chooseCharacter.characters[index].imagePlayer1;
        imagePlayer2.sprite = chooseCharacter.characters[index1].imagePlayer2;
    }
    //PLAYER 1
    public void NextCharacter()
    {
        //Boton derecha
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

    
    public void FormerCharacter()
    {
        //Boton izquierda
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

    //PLAYER 2
    public void NextCharacter1()
    {
        //Boton derecha
        if (index1 == chooseCharacter.characters.Count - 1)
        {
            index1 = 0;
        }
        else
        {
            index1 += 1;
        }
        ChangeScreen();
    }

    
    public void FormerCharacter1()
    {
        //Boton izquierda
        if (index1 == 0)
        {
            index1 = chooseCharacter.characters.Count - 1;
        }
        else
        {
            index1 -= 1;
        }
        ChangeScreen();
    }
    
}
