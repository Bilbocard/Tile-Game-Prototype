using UnityEngine;

public class HighlightChecker : MonoBehaviour
{
    public static HighlightChecker Instance;
    private Hex _currentHighlight = new Hex{q = 10000, r = 10000};
    private bool _paused = false;
    private Hex _currentPosition;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    private void Update()
    {
        if (!SETTINGS.PlayerCanMove && !_paused)
        {
            UnhighlightTile(_currentHighlight);
            _paused = true;
        }

        if (SETTINGS.PlayerCanMove && _paused)
        {
            _paused = false;
            _currentPosition = Utils.MouseToWorldHex();
            HighlightTile(_currentPosition, AdventureManager.Instance.GetCurrentTile());
        }
        if (_paused) return;
        _currentPosition = Utils.MouseToWorldHex();
        if (Utils.CompareHexes(_currentPosition, _currentHighlight)) return;
        UnhighlightTile(_currentHighlight);
        HighlightTile(_currentPosition, AdventureManager.Instance.GetCurrentTile());
        _currentHighlight = _currentPosition;
    }

    private void UnhighlightTile(Hex tile)
    {
        if (AdventureManager.Instance._tileDictionary.TryGetValue(tile, out Tile oldTile))
        {
            oldTile.UnhighlightTile();
        }
    }
    
    private void HighlightTile(Hex tile, Hex oldTile)
    {
        if (AdventureManager.Instance._tileDictionary.TryGetValue(tile, out Tile newTile))
        {
            newTile.HighlightTile(Utils.DistanceBetweenHexes(tile, oldTile));
        }
    }
}
