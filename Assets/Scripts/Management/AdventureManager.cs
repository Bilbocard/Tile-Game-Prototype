using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public static AdventureManager Instance;
    [SerializeField] private PredeterminedTile baseTile;
    private Hex _currentTile = new() {q = 0, r = 0};
    public Dictionary<Hex, Tile> _tileDictionary = new();
    private bool _playerCanMove;
    public static event Action<Hex> Move = delegate {  };

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
        GameManager.Instance.DisableMovement();
        PlaceNewTile(startLocation, baseTile.tileInformation);
        _currentTile = startLocation;
        yield return new WaitForSeconds(0.2f);
        yield return GenerateLocalTiles(startLocation);
        GameManager.Instance.EnableMovement();
        yield return null;
    }
    
    public void RequestMove(Vector2 input)
    {
        if (!_playerCanMove) return;
        Hex inputHex = Utils.CoordinateToWorldHex(input);
        if (!_tileDictionary.TryGetValue(inputHex, out var outTile)) return;
        if (Utils.DistanceBetweenHexes(inputHex, GetCurrentTile()) != 1) return;
        Move.Invoke(inputHex);
    }

    private IEnumerator GenerateLocalTiles(Hex currentLocation)
    {
        var tileGenerated = false;
        for (var i = 0; i < 6; i++)
        {
            var newLocation = Utils.AxialNeighbour(currentLocation, i);
            if (_tileDictionary.ContainsKey(newLocation)) continue;
            var builtTile = TileBuilder.Instance.BuildATile();
            PlaceNewTile(newLocation, builtTile);
            tileGenerated = true;
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(tileGenerated ? 0.75f : 0f);
        yield return null;
    }

    private void PlaceNewTile(Hex location, TileInformation tileInformation)
    {
        var tile = Instantiate(GameManager.Instance.tileBase, Utils.AxialToVector2(location), Quaternion.identity)
            .GetComponent<Tile>();
        tile.Init(location, tileInformation);
        _tileDictionary.Add(location, tile);
    }

    public IEnumerator MoveToTile(Hex newLocation)
    {
        _currentTile = newLocation;
        yield return GenerateLocalTiles(newLocation);
        yield return null;
    }

    public Tile GetTile(Hex tileHex)
    {
        if (!_tileDictionary.ContainsKey(tileHex)) return null;
        return _tileDictionary[tileHex];
    }

    public Hex GetCurrentTile()
    {
        return _currentTile;
    }
    
    private void EnableMovement()
    {
        _playerCanMove = true;
    }

    private void DisableMovement()
    {
        _playerCanMove = false;
    }

    private void OnEnable()
    {
        GameManager.OnMovementEnabled += EnableMovement;
        GameManager.OnMovementDisabled += DisableMovement;
    }
    
    private void OnDisable()
    {
        GameManager.OnMovementEnabled -= EnableMovement;
        GameManager.OnMovementDisabled -= DisableMovement;
    }
}