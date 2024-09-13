using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    [SerializeField] GameObject _selectedCircle;

    private void Awake()
    {
        _selectedCircle.SetActive(false);
    }

    virtual public void Move(Vector3 coordinatesToMove)
    {
        Debug.Log($"� {gameObject.name} � � ��� �� ���������� {coordinatesToMove}");
    }

    public void SetSelectedVisible(bool visible)
    {
        _selectedCircle.SetActive(visible);
    }
}
