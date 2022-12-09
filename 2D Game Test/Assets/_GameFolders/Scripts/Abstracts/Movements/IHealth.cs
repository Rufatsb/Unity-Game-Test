
namespace UnityTddBeginner.Abstracts.Movements

{
    public interface IHealth
    {
        int CurrentHealth { get; }
        void TakeDamage(IAttacker attacker);

        event System.Action OnTookDamage;
        event System.Action OnDead;
    }
}
