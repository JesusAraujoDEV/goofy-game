using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDucksControl : MonoBehaviour
{
    public PlumasManager plumasManager;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "WhiteDuck" && this.gameObject.tag == "BabyWhiteDuck"){
            PlumasManager.Instance.ObtenerBaby(collision.gameObject.tag);
            this.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "BlackDuck" && this.gameObject.tag == "BabyBlackDuck"){
            PlumasManager.Instance.ObtenerBaby(collision.gameObject.tag);
            this.gameObject.SetActive(false);
        }
    }
}   
