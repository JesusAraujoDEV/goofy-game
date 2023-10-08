using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMovimiento : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
