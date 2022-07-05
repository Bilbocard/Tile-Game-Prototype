using System;
using System.Collections;
using UnityEngine;

public class PlayerAdventureController : MonoBehaviour
{
    private IInputHandler _inputHandler;
    private IMovement _movement;
    public static PlayerAdventureController Instance;
    private Action<Hex> _onMoveStartAction;
    

    private void Awake()
    {
        _inputHandler = GetComponent<IInputHandler>();
        _movement = GetComponent<IMovement>();
        _onMoveStartAction = _ => OnMoveStart();
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    private void PlayerInput(Vector2 input)
    {
        AdventureManager.Instance.RequestMove(input);
    }

    private void PlayerMove(Hex targetHex)
    {
        _movement?.Move(targetHex);
    }

    private void OnMoveStart()
    {
        GameManager.Instance.DisableMovement();
    }

    private void OnMoveEnd(Hex targetHex)
    {
        StartCoroutine(OnMoveEndCoroutine(targetHex));
    }

    private IEnumerator OnMoveEndCoroutine(Hex targetHex)
    {
        yield return new WaitForSeconds(0.3f);
        yield return AdventureManager.Instance.MoveToTile(targetHex);
        GameManager.Instance.EnableMovement();
    }

    private void OnEnable()
    {
        if (_inputHandler != null) _inputHandler.OnInput += PlayerInput;
        if (_movement != null) _movement.StartMove += _onMoveStartAction;
        if (_movement != null) _movement.EndMove += OnMoveEnd;
        AdventureManager.Move += PlayerMove;
    }
    
    private void OnDisable()
    {
        if (_inputHandler != null) _inputHandler.OnInput -= PlayerInput;
        if (_movement != null) _movement.StartMove -= _onMoveStartAction;
        if (_movement != null) _movement.EndMove -= OnMoveEnd;
        AdventureManager.Move -= PlayerMove;
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