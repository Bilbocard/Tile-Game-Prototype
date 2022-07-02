using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] private bool isPlayer;

    public bool IsPlayer()
    {
        return isPlayer;
    }
}