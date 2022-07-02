using UnityEngine;

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
}