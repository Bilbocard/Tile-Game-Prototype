using System;
using UnityEngine;

public class MouseInput : MonoBehaviour, IInputHandler
{
    public event Action<Vector2> OnInput = delegate {  };
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnInput.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}