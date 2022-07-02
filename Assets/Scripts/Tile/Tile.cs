using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private TileInformation _tileInformation;
    private Hex _axial;
    [SerializeField] private TileDrawer tileDrawer;

    public void Init(Hex axial, TileInformation tileInformation)
    {
        _tileInformation = tileInformation;
        _axial = axial;
        DrawTile();
    }

    public void MoveToTile()
    {
        if (_tileInformation.creature != null)
        {
            _tileInformation.creature.Interact();
        }

        if (_tileInformation.location != null)
        {
            _tileInformation.location.Interact();
        }
    }
    private void DrawTile()
    {
        tileDrawer.DrawTile(_tileInformation);
    }

    public void HighlightTile(int distance)
    {
        tileDrawer.HighlightSprite(distance);
    }

    public void UnhighlightTile()
    {
        tileDrawer.UnhighlightSprite();
    }
}
