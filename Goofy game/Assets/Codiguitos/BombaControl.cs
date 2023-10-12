using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BombaControl : MonoBehaviour
{
    [Header("Datos Bomba")]
    public GameObject bombaPreFab;
    public KeyCode inputKey = KeyCode.Space;
    public float tiempo_puesto_Explosion = 4f;
    public int cantidadBombas = 1;
    private int bombasRestantes;

    [Header("Datos Explosiones")]
    public Explosion explosionPreFab;
    public float duracion_explosion = 1f;
    public int largo_explosion = 1;

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

        yield return new WaitForSeconds(tiempo_puesto_Explosion);
        
        posicion = bomba.transform.position;
        posicion.x = MathF.Round(posicion.x);
        posicion.y = Mathf.Round(posicion.y);

        Explosion explosion = Instantiate(explosionPreFab, posicion, Quaternion.identity);
        explosion.setActiveRenderer(explosion.start);
        explosion.DestroyAfterSeconds(duracion_explosion);
        
        Explotar(posicion, Vector2.up, largo_explosion);
        Explotar(posicion, Vector2.down, largo_explosion);
        Explotar(posicion, Vector2.left, largo_explosion);
        Explotar(posicion, Vector2.right, largo_explosion);

        Destroy(bomba);

        bombasRestantes++;
    }

    private void Explotar(Vector2 posicion, Vector2 direccion, int largo){
        if(largo <= 0){
            return;
        }

        posicion += direccion;

        Explosion explosion = Instantiate(explosionPreFab, posicion, Quaternion.identity);
        explosion.setActiveRenderer(largo > 1 ? explosion.medio: explosion.final);
        explosion.setDireccion(direccion);
        explosion.DestroyAfterSeconds(duracion_explosion); 

        Explotar(posicion, direccion, largo - 1);
    }

    private void OnTriggerExit2D(Collider2D otro){
        if(otro.gameObject.layer == LayerMask.NameToLayer("Bomba")){
            otro.isTrigger = false;
        }
    }
}