using UnityEngine;

public class TestScript : MonoBehaviour
{
    /*[SerializeField] private TileBase tileBase;
    [SerializeField] private Creature[] creature;
    [SerializeField] private Location[] location;

    private float _timer = 2f;
    private Dictionary<Hex, Tile> _tileDictionary = new Dictionary<Hex, Tile>();
    private int _radius = 0;
    private int _curLine = 0;
    private int _curDir = 0;
    
    private Hex _currentLoc = new Hex
    {
        q = 0,
        r = 0,
    };

    

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            SpawnTile();
            _timer = 0.0f;
        }
    }

    public void SpawnTile()
    {
        int i = Random.Range(0, 20);
        Creature chosenCreature = null;
        if (i == 0)
        {
            chosenCreature = creature[Random.Range(0, creature.Length)];
        }

        Location chosenLocation = null;
        if (i == 1)
        {
            chosenLocation = location[Random.Range(0, location.Length)];
        }
        Tile tile = new Tile(_currentLoc, tileBase, chosenLocation, chosenCreature);
        _tileDictionary.Add(_currentLoc, tile);
        _currentLoc = Utils.AxialNeighbour(_currentLoc, _curDir % 6);
        _curLine++;
        if (_curLine >= _radius)
        {
            if (_radius == 0)
            {
                _radius++;
                _curDir = 1;
            }
            _curLine = 0;
            _curDir++;
        }
        if (_tileDictionary.ContainsKey(_currentLoc))
        {
            _currentLoc = Utils.AxialNeighbour(_currentLoc, 0);
            _curDir = 2;
            _curLine = 0;
            _radius++;
        }
    }*/
}