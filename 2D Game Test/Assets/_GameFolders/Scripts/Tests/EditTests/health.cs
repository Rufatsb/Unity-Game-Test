using NSubstitute;
using NUnit.Framework;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Movements;

namespace Combats
{
    public class health
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]

        public void TakeDamageNotEqualMaxHealth(int damageValue)
        {
            //Arrange
            int maxHealth = 1;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();
            //Act
            attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker);

            //Assert

            Assert.AreNotEqual(maxHealth, health.CurrentHealth);

          
        }


    }

}