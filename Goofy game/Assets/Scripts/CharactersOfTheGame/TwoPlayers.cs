using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayers : MonoBehaviour
{
    private void Multiplayer()
    {
        int indexPlayer = PlayerPrefs.GetInt("PlayerIndex");
        int indexPlayer1 = PlayerPrefs.GetInt("PlayerIndex1");

        Instantiate(ChooseCharacter.Instance.characters[indexPlayer].playableCharacter, transform.position, Quaternion.identity);
        Instantiate(ChooseCharacter.Instance.characters[indexPlayer1].playableCharacter, transform.position, Quaternion.identity);
    }
}
