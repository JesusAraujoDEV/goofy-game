using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSkin : MonoBehaviour
{
    [SerializeField] private GameObject skinButton;
    [SerializeField] private GameObject turnButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject quitButton;

    public void Skin()
    {
        //panel que aparece al presionar skin
        skinButton.SetActive(false);
        turnButton.SetActive(true); 
        playButton.SetActive(false);
        quitButton.SetActive(false);
    }
    
    public void Return()
    {
        skinButton.SetActive(true);
        turnButton.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true); 
    }
}
