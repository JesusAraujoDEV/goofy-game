using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayer : MonoBehaviour
{

    private void Choice()
    {
        int indexPlayer = PlayerPrefs.GetInt("PlayerIndex");
        Instantiate(ChooseCharacter.Instance.characters[indexPlayer].playableCharacter, transform.position, Quaternion.identity);
    }

}
