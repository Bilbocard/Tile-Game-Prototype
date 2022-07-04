using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    public static event Action<Vector2> OnMouseInput = delegate { };
    

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnMouseInput.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition));
    }

    /*public void InteractWith(Tile tile)
    {
        SETTINGS.PlayerCanMove = false;
        switch (tile.GetInteractableType())
        {
            case InteractableType.Location:
                StartCoroutine(InteractWithLocation(tile));
                break;
            case InteractableType.Enemy:
                StartCoroutine(InteractWithEnemy(tile));
                break;
            case InteractableType.Friendly:
                StartCoroutine(InteractWithFriendly(tile));
                break;
            default:
                Debug.Log("Interactable not implemented?");
                break;
        }
    }

    private IEnumerator InteractWithEnemy(Tile tile)
    {
        tile.Interact();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Move(tile.GetLocation()));
    }

    private IEnumerator InteractWithLocation(Tile tile)
    {
        yield return Move(tile.GetLocation());
        tile.Interact();
    }

    private IEnumerator InteractWithFriendly(Tile tile)
    {
        yield return Move(tile.GetLocation());
        tile.Interact();
    }*/
}