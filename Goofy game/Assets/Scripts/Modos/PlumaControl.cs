using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumaControl : MonoBehaviour
{
    public int valor = 1;
    public PlumasManager plumasManager;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("WhiteDuck") || collision.CompareTag("BlackDuck")){
            plumasManager.SumarPlumas(valor, collision.gameObject.tag);

            FindObjectOfType<AudioManager>().PlaySound("Tomar una pluma");

            Destroy(this.gameObject);
        }
    }
}
