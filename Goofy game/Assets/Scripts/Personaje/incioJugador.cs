using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incioJugador : MonoBehaviour
{

    private void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("PlayerIndex");
        Instantiate(CharacterDataBase.Instance.character[indexJugador].playableCharacter, transform.position, Quaternion.identity);
    }


}
