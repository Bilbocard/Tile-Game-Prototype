using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public static AdventureManager Instance;
    [SerializeField] private PredeterminedTile baseTile;
    private Hex _currentTile = new Hex {q = 0, r = 0};
    public Dictionary<Hex, Tile> _tileDictionary = new Dictionary<Hex, Tile>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    public IEnumerator StartLevel(Hex startLocation)
    {
        SETTINGS.PlayerCanMove = false;
        PlaceNewTile(startLocation, baseTile.tileInformation);
        _currentTile = startLocation;
        yield return new WaitForSeconds(0.2f);
        yield return GenerateLocalTiles(startLocation);
        SETTINGS.PlayerCanMove = true;
        yield return null;
    }

    private IEnumerator GenerateLocalTiles(Hex currentLocation)
    {
        bool tileGenerated = false;
        for (int i = 0; i < 6; i++)
        {
            Hex newLocation = Utils.AxialNeighbour(currentLocation, i);
            if (_tileDictionary.ContainsKey(newLocation)) continue;
            TileInformation builtTile = TileBuilder.Instance.BuildATile();
            PlaceNewTile(newLocation, builtTile);
            tileGenerated = true;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(tileGenerated ? 0.75f : 0f);
        yield return null;
    }

    private void PlaceNewTile(Hex location, TileInformation tileInformation)
    {
        Tile tile = Instantiate(GameManager.Instance.tileBase, Utils.AxialToVector2(location), Quaternion.identity).GetComponent<Tile>();
        tile.Init(location, tileInformation);
        _tileDictionary.Add(location, tile);
    }

    public IEnumerator MoveToTile(Hex newLocation)
    {
        _tileDictionary[newLocation].MoveToTile();
        _currentTile = newLocation;
        yield return GenerateLocalTiles(newLocation);
        yield return null;
    }

    public Hex GetCurrentTile()
    {
        return _currentTile;
    }
}
