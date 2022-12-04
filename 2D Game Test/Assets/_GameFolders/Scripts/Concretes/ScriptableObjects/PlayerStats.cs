using UnityEngine;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.Concretes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "RB Gaming/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
       [Header("Move Information")] [SerializeField]
        float _moveSpeed = 5f;

        public float MoveSpeed => _moveSpeed;
    }

}
