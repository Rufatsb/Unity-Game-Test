using System;
using UnityEngine;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements

{
    public  class Health:IHealth
    {
        int _currentHealth = 0;

        public event Action OnTookDamage;
        public event Action OnDead;

        public int CurrentHealth => _currentHealth;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage(IAttacker attacker)
        {
            _currentHealth -= attacker.Damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);
            OnTookDamage?.Invoke();
            OnDead?.Invoke();

        }
    }
}
