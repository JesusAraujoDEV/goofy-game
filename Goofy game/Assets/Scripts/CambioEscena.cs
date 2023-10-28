using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodeescena : MonoBehaviour
{
    public MovementController playerNoEntering;
    public MovementController playerEntering;
    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("BlackDuck")){
            Debug.Log("lol");
        }
    }
}
