using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAudioScript : MonoBehaviour
{
    [SerializeField] AudioSource[] _chooseCharAudioSource;


    void Start()
    {
        ActionsManager.CharactersChoose += OnCharacterChoose;
    }

    public void OnCharacterChoose(List<PlayerChar> playerChars)
    {
        if (playerChars.Count != 0)
        {
            _chooseCharAudioSource[Random.Range(0, _chooseCharAudioSource.Length)].Play(); 
        }
    }
}
