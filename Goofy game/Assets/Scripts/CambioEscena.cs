using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodeescena : MonoBehaviour
{
    public MovementController playerNoEntering;
    public MovementController playerEntering;
    public MenuPausa pausaMenu;
    public PlumasManager plumasManager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WhiteDuck") && this.gameObject.tag == "RutaWhite")
        {
            if (plumasManager.loTieneWhite)
            {
                pausaMenu.StatusWinnerPlumas(collision.gameObject.tag);
                // Realiza la acción correspondiente cuando el jugador tiene el bebé.
            }
            else
            {
                Debug.Log("No tiene el bebé.");
                // Realiza la acción correspondiente cuando el jugador no tiene el bebé.
            }

            // Luego puedes mostrar un mensaje, cambiar la escena, o realizar cualquier otra acción que desees.
        }
        else if (collision.CompareTag("BlackDuck") && this.gameObject.tag == "RutaBlack")
        {
            if (plumasManager.loTieneBlack)
            {
                pausaMenu.StatusWinnerPlumas(collision.gameObject.tag);
                // Realiza la acción correspondiente cuando el jugador tiene el bebé.
            }
            else
            {
                Debug.Log("No tiene el bebé.");
                // Realiza la acción correspondiente cuando el jugador no tiene el bebé.
            }

            // Luego puedes mostrar un mensaje, cambiar la escena, o realizar cualquier otra acción que desees.
        }
        else if(collision.CompareTag("WhiteDuck") && this.gameObject.tag == "Silla"){
            pausaMenu.Victoria();
        }
    }
}