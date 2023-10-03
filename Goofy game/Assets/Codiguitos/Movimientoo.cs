
using UnityEngine;

public class Movimientoo : MonoBehaviour
{
    public Rigidbody2D cuerpesito {get; private set;}
    
    private void Awake(){
        cuerpesito = GetComponent<Rigidbody2D>();
    }
}
