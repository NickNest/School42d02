using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Transform _selectionBox;

    private List<PlayerChar> _playerChars;
    private Vector3 _startMousePosition;
    private void Awake()
    {
        _selectionBox.gameObject.SetActive(false);
        _playerChars = new List<PlayerChar>();
    }
    void Update()
    {
        OnLeftMouseButtonDown();
        OnLeftMouseButton();
        OnLeftMouseButtonUp();
        if (Input.GetMouseButtonDown(1))
        {
            ActionsManager.OnRightMouseButtonDown(GetCurrentPosOfMouse(), _playerChars);
        }
    }

    private void OnLeftMouseButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ActionsManager.OnCharactersUnChoose(_playerChars);
            _playerChars.Clear();
            _selectionBox.gameObject.SetActive(false);
            Collider2D[] choosenObjects = Physics2D.OverlapAreaAll(_startMousePosition, GetCurrentPosOfMouse());
            foreach (var item in choosenObjects)
            {
                PlayerChar playerChar = item.GetComponent<PlayerChar>();
                if (playerChar != null)
                {
                    _playerChars.Add(playerChar);
                }
            }
            ActionsManager.OnCharactersChoose(_playerChars);
        }
    }

    private void OnLeftMouseButton()
    {
        if (Input.GetMouseButton(0))
        {
            var currentMousePos = GetCurrentPosOfMouse();
            var lowerLeftPoint = new Vector3(
                Mathf.Min(_startMousePosition.x, currentMousePos.x),
                Mathf.Min(_startMousePosition.y, currentMousePos.y)
                );
            var upperLeftPoint = new Vector3(
                Mathf.Max(_startMousePosition.x, currentMousePos.x),
                Mathf.Max(_startMousePosition.y, currentMousePos.y)
                );
            _selectionBox.position = lowerLeftPoint;
            _selectionBox.localScale = upperLeftPoint - lowerLeftPoint;

        }
    }

    private void OnLeftMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Мышь нажата: " + diference);
            _selectionBox.gameObject.SetActive(true);
            _startMousePosition = GetCurrentPosOfMouse();
        }
    }

    private static Vector3 GetCurrentPosOfMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
