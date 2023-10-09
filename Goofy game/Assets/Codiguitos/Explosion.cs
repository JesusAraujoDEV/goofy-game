using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimacionMovimiento start;
    public AnimacionMovimiento medio;
    public AnimacionMovimiento final;


    public void setActiveRenderer(AnimacionMovimiento renderer){
        start.enabled = renderer == start;
        medio.enabled = renderer == medio;
        final.enabled = renderer == final;
    }

    public void setDireccion(Vector2 direccion){
        float angulo = Mathf.Atan2(direccion.y , direccion.x);
        transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
    }

    public void DestroyAfterSeconds(float seconds){
        Destroy(gameObject, seconds);
    }
}
