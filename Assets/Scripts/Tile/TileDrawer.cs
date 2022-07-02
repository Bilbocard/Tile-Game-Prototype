using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TileDrawer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer tileBase;
    [SerializeField] private SpriteRenderer path;
    [SerializeField] private SpriteRenderer river;
    [SerializeField] private SpriteRenderer road;
    [SerializeField] private SpriteRenderer location;
    [SerializeField] private SpriteRenderer marker;
    [SerializeField] private SpriteRenderer flair;
    [SerializeField] private SpriteRenderer creature;
    [SerializeField] private SpriteRenderer highlight;

    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private Sprite highlightTooFarSprite;
    [SerializeField] private SortingGroup sortingGroup;

    public void DrawTile(TileInformation tileInformation)
    {
        tileBase.sprite = tileInformation.tileBase != null ? tileInformation.tileBase.GetSprite() : null;
        path.sprite = null;
        river.sprite = null;
        road.sprite = null;
        location.sprite = tileInformation.location != null ? tileInformation.location.GetSprite() : null;
        marker.sprite = null;
        flair.sprite = null;
        creature.sprite = tileInformation.creature != null ? tileInformation.creature.GetSprite() : null;
    }

    public void HighlightSprite(int distance)
    {
        sortingGroup.sortingOrder = 1;
        if (distance <= 1)
        {
            highlight.sprite = highlightSprite;
            return;
        }

        highlight.sprite = highlightTooFarSprite;
    }

    public void UnhighlightSprite()
    {
        highlight.sprite = null;
        sortingGroup.sortingOrder = 0;
    }
}
