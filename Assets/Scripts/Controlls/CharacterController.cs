using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float distanceBetweenFighters = 1f;

    private Vector2[] directions = new Vector2[] {
        Vector2.right,
        Vector2.up,
        Vector2.left,
        Vector2.down
    };

    private List<PlayerChar> _currentPlayerChars;


    void Start()
    {
        ActionsManager.CharactersChoose += OnCharacterChoose;
        ActionsManager.CharactersUnChoose += OnCharacterUnChoose;
        ActionsManager.RightMouseButtonDown += OnRightMouseButtonDown;
        _currentPlayerChars = new List<PlayerChar>();
    }


    public void StrokeCharacters(bool visible)
    {
        foreach (PlayerChar playerChar in _currentPlayerChars)
        {
            if (playerChar != null)
            {
                playerChar.SetSelectedVisible(visible);
            }

        }
    }

    private void OnRightMouseButtonDown(Vector2 coordinatesToMove, List<PlayerChar> playerChars)
    {
        var choosenObject = Physics2D.OverlapCircle(coordinatesToMove, 0.1f)?.GetComponent<IDamagable>();

        if (choosenObject != null)
        {
            Debug.Log($"интерфейс: {choosenObject}");
        }
        else
        {
            MoveCharsToCurrentCoordinates(coordinatesToMove);
        }
    }

    private void MoveCharsToCurrentCoordinates(Vector2 coordinatesToMove)
    {
        _currentPlayerChars.Reverse();
        var countOfPlayerChars = _currentPlayerChars.Count;
        Vector2 place = coordinatesToMove;
        int directionIndex = 0;
        var step = 1;

        for (int i = 0; i < countOfPlayerChars;)
        {
            for (int j = 0; j < step && i < countOfPlayerChars; j++)
            {
                _currentPlayerChars[i++].Move(place);

                place += directions[directionIndex] * distanceBetweenFighters;
            }
            directionIndex = (directionIndex + 1) % 4;

            if (directionIndex % 2 == 0)
            {
                step++;
            }
        }
    }

    private void OnCharacterUnChoose(List<PlayerChar> playerChars)
    {
        _currentPlayerChars = playerChars;
        StrokeCharacters(false);
    }

    public void OnCharacterChoose(List<PlayerChar> playerChars)
    {
        _currentPlayerChars = playerChars;
        StrokeCharacters(true);
    }
}
