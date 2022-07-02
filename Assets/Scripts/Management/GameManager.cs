using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject tileBase;

    public static GameManager Instance;

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
