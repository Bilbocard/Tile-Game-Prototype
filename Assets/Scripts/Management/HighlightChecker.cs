using UnityEngine;

public class HighlightChecker : MonoBehaviour
{
    public static HighlightChecker Instance;
    private GameObject _currentHighlight;
    private bool _paused;

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
            _currentHighlight?.GetComponent<IHighlightable>()?.Unhighlight();
            _currentHighlight = null;
            _paused = true;
            return;
        }

        if (SETTINGS.PlayerCanMove && _paused) _paused = false;
        if (_paused) return;
        var mousePos = Utils.MouseToWorldHex();
        AdventureManager.Instance._tileDictionary.TryGetValue(mousePos, out var tile);
        if (tile != null && tile.gameObject == _currentHighlight) return;
        _currentHighlight?.GetComponent<IHighlightable>()?.Unhighlight();
        if (tile == null)
        {
            _currentHighlight = null;
            return;
        }

        _currentHighlight = tile.gameObject;
        var inRange = Utils.DistanceBetweenHexes(AdventureManager.Instance.GetCurrentTile(), mousePos) <= 1;
        _currentHighlight?.GetComponent<IHighlightable>()?.Highlight(inRange);
    }
}