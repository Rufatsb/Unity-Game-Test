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

        [Header("Combat Info")][SerializeField]
        int _maxHealth = 10;

        public int MaxHealth => _maxHealth;
    }

}
