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
        if (!AdventureManager.Instance._tileDictionary.ContainsKey(tile)) return;
        if (Utils.DistanceBetweenHexes(tile, player.GetCurrentHex()) != 1) return;
        StartCoroutine(player.Move(tile));
    }
}