using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enlace : MonoBehaviour
{
    private void Start()
    {
        int indexPlayer = PlayerPrefs.GetInt("PlayerIndex");
        int indexPlayer1 = PlayerPrefs.GetInt("PlayerIndex1");

        Instantiate(ChooseCharacter.Instance.characters[indexPlayer].playableCharacter, transform.position, Quaternion.identity);
        Instantiate(ChooseCharacter.Instance.characters[indexPlayer1].playableCharacter, transform.position, Quaternion.identity);
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

}
