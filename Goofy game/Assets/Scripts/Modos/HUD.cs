using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{   
    public PlumasManager plumasManager;
    public TextMeshProUGUI puntosWhiteDuck;
    public TextMeshProUGUI puntosBlackDuck;
    private string tagDuck;
    public GameObject[] vidas;
    public GameObject[] vidasBlackDuck;
    public GameObject[] BabiesDuck;
    // Update is called once per frame

    public void ActualizarPlumasWhite(int plumasTotales){
        puntosWhiteDuck.text = plumasTotales.ToString();
    }

    public void ActualizarPlumasBlack(int plumasTotales){
        puntosBlackDuck.text = plumasTotales.ToString();
    }

    public void DesactivarVidas(int indice){
        try{
           vidas[indice].SetActive(false); 
        }
        catch(System.IndexOutOfRangeException){
            plumasManager.ReiniciarVidas();
            vidas[3].SetActive(false);
        }   
    }
    public void DesactivarVidasBlack(int indice){
        vidasBlackDuck[indice].SetActive(false);
    }


    public void ActivarVidas(int indice){
        vidas[indice].SetActive(true);
    }

    public void DesactivarBabies(int indice, string tag){
        if (tag == "WhiteDuck"){
            BabiesDuck[indice].SetActive(false);
            //Volver a instanciar el objeto en su posición inicial
        }
        else if(tag == "BlackDuck"){
            BabiesDuck[indice].SetActive(false);
            //Volver a instanciar el objeto en su posición inicial
        }
    }
    public void ActivarBabies(int indice, string tag){
        if (tag == "WhiteDuck"){
            BabiesDuck[indice].SetActive(true);
        }
        else if(tag == "BlackDuck"){
            BabiesDuck[indice].SetActive(true);
        }
    }
}
