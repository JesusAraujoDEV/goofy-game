using System;
using System.Collections;
using UnityEngine;

public class BombaControl : MonoBehaviour
{
    public GameObject bombaPreFab;
    public KeyCode inputKey = KeyCode.Space;
    public float tiempoExplosion = 4f;
    public int cantidadBombas = 1;
    private int bombasRestantes;

    private void OnEnable(){
        bombasRestantes = cantidadBombas;
    }

    private void Update(){
        if (bombasRestantes > 0 && Input.GetKeyDown(inputKey)) {
            StartCoroutine(PonerBomba());
        }
    }

    private IEnumerator PonerBomba(){
        Vector2 posicion = transform.position;
        posicion.x = MathF.Round(posicion.x);
        posicion.y = Mathf.Round(posicion.y);

        GameObject bomba = Instantiate(bombaPreFab, posicion, Quaternion.identity);
        bombasRestantes--;

        yield return new WaitForSeconds(tiempoExplosion);
        
        Destroy(bomba);

        bombasRestantes++;
    }

    private void OnTriggerExit2D(Collider2D otro){
        if(otro.gameObject.layer == LayerMask.NameToLayer("Bomba")){
            otro.isTrigger = false;
        }
    }
}
