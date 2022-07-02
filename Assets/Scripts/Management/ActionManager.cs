using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void RequestMove(PlayerController player, Hex tile)
    {
        if (!SETTINGS.PlayerCanMove) return;
        if (!AdventureManager.Instance._tileDictionary.TryGetValue(tile, out var outTile)) return;
        if (Utils.DistanceBetweenHexes(tile, player.GetCurrentHex()) != 1) return;
        if (outTile.CanInteract())
        {
            player.InteractWith(outTile);
            return;
        }

        player.MoveTo(tile);
    }
}