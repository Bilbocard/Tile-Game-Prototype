using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Hexplorer/New Tile Base", fileName = "New Tile Base")]
public class TileBase : ScriptableObject
{
    [SerializeField] private string tileName;
    [SerializeField] private BiomeType biomeType;
    [SerializeField] private Sprite[] sprite;

    public Sprite GetSprite()
    {
        int index = Random.Range(0, sprite.Length);
        return sprite[index];
    }
}
