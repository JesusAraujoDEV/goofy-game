using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodeescena : MonoBehaviour
{
    public MovementController playerNoEntering;
    public MovementController playerEntering;
    public MenuPausa pausaMenu;
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && this.gameObject.tag == "Victory"){
            Debug.Log("ola");
            pausaMenu.Victoria();
        }
    }
}
