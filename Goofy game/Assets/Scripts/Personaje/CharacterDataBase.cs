using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBase : MonoBehaviour
{

    public static CharacterDataBase Instance;
    public List<Character> character;
    private void Awake()
    {
        if (CharacterDataBase.Instance == null){
            CharacterDataBase.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
