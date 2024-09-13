using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager
{
    public static event Action<List<PlayerChar>> CharactersChoose;
    public static event Action<List<PlayerChar>> CharactersUnChoose;
    public static event Action<Vector2, List<PlayerChar>> RightMouseButtonDown;
    public static event Action<string> TowerDestroyed;

    public static void OnTowerDestroyed(string tagOfTower)
    {
        TowerDestroyed?.Invoke(tagOfTower);
    }
    public static void OnRightMouseButtonDown(Vector2 coordinatesToMove, List<PlayerChar> characters)
    {
        RightMouseButtonDown?.Invoke(coordinatesToMove, characters);
    }
    public static void OnCharactersChoose (List<PlayerChar> characters)
    {
        CharactersChoose?.Invoke (characters);
    }
    
    public static void OnCharactersUnChoose (List<PlayerChar> characters)
    {
        CharactersUnChoose?.Invoke (characters);
    }
}
