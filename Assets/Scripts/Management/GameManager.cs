using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject tileBase;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void StartGame()
    {
        StartCoroutine(AdventureManager.Instance.StartLevel(new Hex {q = 0, r = 0}));
    }
}