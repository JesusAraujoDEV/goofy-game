
using UnityEngine;

public class Movimientoo : MonoBehaviour
{
    public Rigidbody2D cuerpesito {get; private set;}
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimacionMovimiento spriteRendererArriba;
    public AnimacionMovimiento spriteRendererAbajo;
    public AnimacionMovimiento spriteRendererIzquierda;
    public AnimacionMovimiento spriteRendererDerecha;
    private AnimacionMovimiento spriteRendererActivo;

    
    private void Awake(){
        cuerpesito   = GetComponent<Rigidbody2D>();
        spriteRendererActivo = spriteRendererAbajo;
    }

    private void Update(){
        if(Input.GetKey(inputUp)){
            asignarDireccion(Vector2.up, spriteRendererArriba);
        } else if (Input.GetKey(inputDown)){
            asignarDireccion(Vector2.down, spriteRendererAbajo);
        } else if (Input.GetKey(inputLeft)){
            asignarDireccion(Vector2.left, spriteRendererIzquierda);
        } else if (Input.GetKey(inputRight)){
            asignarDireccion(Vector2.right, spriteRendererDerecha);
        } else{
            asignarDireccion(Vector2.zero, spriteRendererActivo);
        }
    }

    private void FixedUpdate(){
        Vector2 posicion = cuerpesito.position;
        Vector2 traslacion = direction * speed * Time.fixedDeltaTime;

        cuerpesito.MovePosition(posicion + traslacion);
    }
    
    private void asignarDireccion(Vector2 nuevaDireccion, AnimacionMovimiento spriteRenderer){
        direction = nuevaDireccion;

        spriteRendererArriba.enabled = spriteRenderer == spriteRendererArriba;
        spriteRendererAbajo.enabled = spriteRenderer == spriteRendererAbajo;
        spriteRendererDerecha.enabled = spriteRenderer == spriteRendererDerecha;
        spriteRendererIzquierda.enabled = spriteRenderer == spriteRendererIzquierda;

        spriteRendererActivo = spriteRenderer;
        spriteRenderer.idle = direction == Vector2.zero;

    }
}
