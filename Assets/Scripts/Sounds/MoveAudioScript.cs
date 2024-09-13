using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAudioScript : MonoBehaviour
{
    [SerializeField] AudioSource[] _chooseCharAudioSource;


    void Start()
    {
        ActionsManager.RightMouseButtonDown += OnRightMouseButtonDown;
    }

    public void OnRightMouseButtonDown(Vector2 cord, List<PlayerChar> playerChars)
    {
        if (playerChars.Count != 0)
        {
            _chooseCharAudioSource[Random.Range(0, _chooseCharAudioSource.Length)].Play();
        }
    }
}
