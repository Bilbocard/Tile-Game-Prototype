using System;
using UnityEngine;

public class HighlightChecker : MonoBehaviour
{
    private static HighlightChecker _instance;
    private GameObject _currentHighlight;
    private bool _paused;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }

        Destroy(this);
    }

    private void Update()
    {
        if (_paused) return;
        var mousePos = Utils.MouseToWorldHex();
        Tile tile = AdventureManager.Instance.GetTile(mousePos);
        if (tile != null && tile.gameObject == _currentHighlight) return;
        if (_currentHighlight != null)
        {
            _currentHighlight.GetComponent<IHighlightable>()?.Unhighlight();
        }
        if (tile == null)
        {
            _currentHighlight = null;
            return;
        }
        _currentHighlight = tile.gameObject;
        var inRange = Utils.DistanceBetweenHexes(AdventureManager.Instance.GetCurrentTile(), mousePos) <= 1;
        _currentHighlight.GetComponent<IHighlightable>()?.Highlight(inRange);
    }

    private void Pause()
    {
        if (_currentHighlight != null)
        {
            _currentHighlight.GetComponent<IHighlightable>()?.Unhighlight();
            _currentHighlight = null;
        }
        _paused = true;
    }

    private void Unpause()
    {
        _paused = false;
    }

    private void OnEnable()
    {
        GameManager.OnMovementEnabled += Unpause;
        GameManager.OnMovementDisabled += Pause;
    }

    private void OnDisable()
    {
        GameManager.OnMovementEnabled -= Unpause;
        GameManager.OnMovementDisabled -= Pause;
    }
}