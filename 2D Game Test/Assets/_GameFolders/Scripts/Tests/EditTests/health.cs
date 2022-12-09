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

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]

        public void TakeDamageCurrentHealthNotLessThanZero(int damageValue)
        {
            //Arrange
            int maxHealth = 1;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();
            //Act
            attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker);

            //Assert

            Assert.GreaterOrEqual(health.CurrentHealth,0);


        }

        [Test]
        public void TakeOneDamageOnTookDamageEventTriggeredOneTime()
        {
            //Arrange
          
            IHealth health = new Health(5);
            IAttacker attacker = Substitute.For<IAttacker>();
            //Act

            attacker.Damage.Returns(1);
            string message = string.Empty;
            health.OnTookDamage += () => message = "On Took Damage Event Triggered";
            health.TakeDamage(attacker);

            //Assert

            Assert.AreNotEqual(string.Empty, message);
         


        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void TakeManyDamageOnTookDamageEventTriggeredManyTime(int value)
        {
            //Arrange

            IHealth health = new Health(100);
            IAttacker attacker = Substitute.For<IAttacker>();
            int damageLoop = value;
            //Act

            attacker.Damage.Returns(1);

            int damageCounter = value;
            health.OnTookDamage += () => damageCounter++;

            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(attacker);
            }

            //Assert

            Assert.AreEqual(damageCounter, damageCounter);



        }
        [Test]
        //[TestCase(1)]
        //[TestCase(2)]
        //[TestCase(5)]
        //[TestCase(10)]
        public void TakedFatalDamageOnDeadTriggered()
        {
            //Arrange
            int maxHealth = 100;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            //Act

            attacker.Damage.Returns(maxHealth+1);
            string message = string.Empty;
            health.OnDead += () => message = "On Dead Event Triggered";
            health.TakeDamage(attacker);


            //Assert
            Assert.AreNotEqual(string.Empty, message);




        }

    }

}