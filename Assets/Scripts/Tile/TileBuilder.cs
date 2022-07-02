using UnityEngine;

public class TileBuilder : MonoBehaviour
{
    public static TileBuilder Instance;
    [SerializeField] private TileBase tileBase;
    [SerializeField] private Creature[] creature;
    [SerializeField] private Location[] location;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public TileInformation BuildATile()
    {
        var newTile = new TileInformation();
        AddBase(ref newTile);
        return newTile;
    }

    private void AddBase(ref TileInformation tileInformation)
    {
        tileInformation.tileBase = tileBase;
        AddCreature(ref tileInformation);
    }

    private void AddCreature(ref TileInformation tileInformation)
    {
        var rand = Random.Range(0, 20);
        if (rand == 0)
        {
            tileInformation.creature = creature[Random.Range(0, creature.Length)];
            return;
        }

        AddLocation(ref tileInformation);
    }

    private void AddLocation(ref TileInformation tileInformation)
    {
        var rand = Random.Range(0, 20);
        if (rand == 0)
        {
            tileInformation.location = location[Random.Range(0, location.Length)];
        }
    }
}