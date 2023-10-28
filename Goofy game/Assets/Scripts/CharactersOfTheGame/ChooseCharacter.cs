using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    //lista de personajes
    public static ChooseCharacter Instance;
    public List<Characters> characters;
    private void Awake()
    {
        if (ChooseCharacter.Instance == null)
        {
            ChooseCharacter.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
