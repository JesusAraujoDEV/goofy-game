using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float VelocidadSeguimiento = 2f;
    public Transform objetivo;
    // Update is called once per frame
    void Update()
    {
        Vector3 nuevaPosic = new Vector3(objetivo.position.x, objetivo.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position,nuevaPosic,VelocidadSeguimiento*Time.deltaTime);
    }
}
