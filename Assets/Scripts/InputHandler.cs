using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        Vector3 inputPosition;
 
        inputPosition = Input.mousePosition;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(inputPosition));
        if (rayHit.collider) OnClick(rayHit.collider.gameObject);
    }

    private void OnClick(GameObject gameObject)
    {
        Debug.Log(gameObject);

        Petal petal = gameObject.GetComponent<Petal>();

        if (petal != null)
        {
            petal.OnClick();
        }
    }
}
