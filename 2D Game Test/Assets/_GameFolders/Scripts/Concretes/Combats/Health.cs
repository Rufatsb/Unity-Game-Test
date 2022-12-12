using System;
using UnityEngine;
using UnityTddBeginner.Abstracts.Combats;

namespace UnityTddBeginner.Combats

{
    public  class Health:IHealth
    {
        int _currentHealth = 0;
        bool _isDead => _currentHealth <= 0;

        public event Action OnTookDamage;
        public event Action OnDead;

        public int CurrentHealth => _currentHealth;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage(IAttacker attacker)
        {
            if (_isDead) return;

            _currentHealth -= attacker.Damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);

            
         
           OnTookDamage?.Invoke();

            

            if (_isDead)
                OnDead?.Invoke();


        }
    }
}
