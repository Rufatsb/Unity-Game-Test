using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Movements

{
    public  class Health:IHealth
    {
        int _currentHealth = 0;

        public int CurrentHealth => _currentHealth;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage(IAttacker attacker)
        {
            _currentHealth -= attacker.Damage;
        }
    }
}
