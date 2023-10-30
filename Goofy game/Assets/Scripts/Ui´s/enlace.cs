using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enlace : MonoBehaviour
{
    
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
