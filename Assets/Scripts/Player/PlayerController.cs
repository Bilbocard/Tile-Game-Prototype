using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Hex _currentHex;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _currentHex = Utils.CoordinateToWorldHex(transform.position);
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) ActionManager.Instance.RequestMove(this, Utils.MouseToWorldHex());
    }

    public void MoveTo(Hex targetHex)
    {
        SETTINGS.PlayerCanMove = false;
        StartCoroutine(Move(targetHex));
    }

    private IEnumerator Move(Hex targetHex)
    {
        _currentHex = targetHex;
        yield return _playerMovement.MoveTo(targetHex);
        yield return new WaitForSeconds(0.3f);
        yield return AdventureManager.Instance.MoveToTile(targetHex);
        SETTINGS.PlayerCanMove = true;
        yield return null;
    }

    public Hex GetCurrentHex()
    {
        return _currentHex;
    }

    public void InteractWith(Tile tile)
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
    }
}