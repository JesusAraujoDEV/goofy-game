using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distancia;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direccion = player.transform.position - transform.position;
        direccion.Normalize();
        float angle =Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        if(distancia < 4){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
