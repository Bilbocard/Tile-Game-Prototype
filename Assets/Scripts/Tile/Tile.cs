using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private TileDrawer tileDrawer;
    private Hex _axial;
    private TileInformation _tileInformation;

    public void Init(Hex axial, TileInformation tileInformation)
    {
        _tileInformation = tileInformation;
        _axial = axial;
        DrawTile();
    }

    public void Interact()
    {
        if (_tileInformation.creature != null)
        {
            _tileInformation.creature.Interact();
            return;
        }

        if (_tileInformation.location != null) _tileInformation.location.Interact();
    }

    public bool CanInteract()
    {
        if (_tileInformation.creature != null) return true;

        if (_tileInformation.location != null) return true;

        return false;
    }

    private void DrawTile()
    {
        tileDrawer.DrawTile(_tileInformation);
    }

    public Hex GetLocation()
    {
        return _axial;
    }

    public InteractableType GetInteractableType()
    {
        if (_tileInformation.creature != null) return _tileInformation.creature.InteractableType();

        if (_tileInformation.location != null) return _tileInformation.location.InteractableType();

        return InteractableType.None;
    }
}