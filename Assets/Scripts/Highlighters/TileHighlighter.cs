using UnityEngine;
using UnityEngine.Rendering;

public class TileHighlighter : MonoBehaviour, IHighlightable
{
    [SerializeField] private SpriteRenderer spriteToChange;
    [SerializeField] private SortingGroup sortingGroup;
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private Sprite rangeHighlightSprite;

    public void Highlight(bool inRange = true)
    {
        sortingGroup.sortingOrder = 1;
        if (inRange)
        {
            spriteToChange.sprite = highlightSprite;
            return;
        }

        spriteToChange.sprite = rangeHighlightSprite;
    }

    public void Unhighlight()
    {
        sortingGroup.sortingOrder = 0;
        spriteToChange.sprite = null;
    }
}