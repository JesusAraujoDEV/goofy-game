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
    // Update is called once per frame
    void Update()
    {
        tagDuck = plumasManager.TagPlayer;
        if (tagDuck == "WhiteDuck"){
            puntosWhiteDuck.text = plumasManager.PlumasTotalesWhiteDuck.ToString();
        }
        else if(tagDuck == "BlackDuck"){
            puntosBlackDuck.text = plumasManager.PlumasTotalesBlackDuck.ToString();
        }
    }

    public void ActualizarPlumasWhite(int plumasTotales){
        puntosWhiteDuck.text = plumasTotales.ToString();
    }

    public void ActualizarPlumasBlack(int plumasTotales){
        puntosBlackDuck.text = plumasTotales.ToString();
    }

    public void DesactivarVidas(int indice){
        vidas[indice].SetActive(false);
    }

    public void ActivarVidas(int indice){
        vidas[indice].SetActive(true);
    }
}
