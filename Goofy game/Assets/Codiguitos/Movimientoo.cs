
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
    
    private void Awake(){
        cuerpesito   = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(Input.GetKey(inputUp)){
            asignarDireccion(Vector2.up);
        } else if (Input.GetKey(inputDown)){
            asignarDireccion(Vector2.down);
        } else if (Input.GetKey(inputLeft)){
            asignarDireccion(Vector2.left);
        } else if (Input.GetKey(inputRight)){
            asignarDireccion(Vector2.right);
        } else{
            asignarDireccion(Vector2.zero);
        }
    }

    private void FixedUpdate(){
        Vector2 posicion = cuerpesito.position;
        Vector2 traslacion = direction * speed * Time.fixedDeltaTime;

        cuerpesito.MovePosition(posicion + traslacion);
    }
    
    private void asignarDireccion(Vector2 nuevaDireccion){
        direction = nuevaDireccion;
    }
}
