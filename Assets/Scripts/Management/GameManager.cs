using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject tileBase;
    public static event Action OnMovementEnabled = delegate {  };
    public static event Action OnMovementDisabled = delegate {  };

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

    public void EnableMovement()
    {
        OnMovementEnabled.Invoke();
    }
    
    public void DisableMovement()
    {
        OnMovementDisabled.Invoke();
    }
}