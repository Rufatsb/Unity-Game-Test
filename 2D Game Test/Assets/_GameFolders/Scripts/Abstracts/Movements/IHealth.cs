
namespace UnityTddBeginner.Abstracts.Movements

{
    public interface IHealth
    {
        int CurrentHealth { get; }
        void TakeDamage(IAttacker attacker);
    }
}
