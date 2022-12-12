using NSubstitute;
using NUnit.Framework;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Combats;

namespace Combats
{
    public class health
    {
         IAttacker _attacker;

        [SetUp]
        public void Setup()
        {
             _attacker = Substitute.For<IAttacker>();

        }
        private IHealth GetHealth(int maxHealth)
        {
            IHealth health = new Health(maxHealth);
            return health;


        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]

        public void TakeDamageNotEqualMaxHealth(int damageValue)
        {
            //Arrange
            int maxHealth = 1;
            IHealth health = GetHealth(maxHealth);
            //Act
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(_attacker);

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
            IHealth health = GetHealth(maxHealth);
            //Act
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(_attacker);

            //Assert

            Assert.GreaterOrEqual(health.CurrentHealth,0);


        }

        [Test]
        public void TakeOneDamageOnTookDamageEventTriggeredOneTime()
        {
            //Arrange

            int maxHealth = 5;
            IHealth health = GetHealth(maxHealth);
            //Act

            _attacker.Damage.Returns(1);
            string message = string.Empty;
            health.OnTookDamage += () => message = "On Took Damage Event Triggered";
            health.TakeDamage(_attacker);

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

            int maxHealth = 100;
            IHealth health = GetHealth(maxHealth);
            int damageLoop = value;
            //Act

            _attacker.Damage.Returns(1);

            int damageCounter = value;
            health.OnTookDamage += () => damageCounter++;

            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(_attacker);
            }

            //Assert

            Assert.AreEqual(damageCounter, damageCounter);



        }
        [Test]
       
        public void TakedFatalDamageOnDeadTriggered()
        {
            //Arrange
            int maxHealth = 100;
            IHealth health = GetHealth(maxHealth);

            //Act

            _attacker.Damage.Returns(maxHealth+1);
            string message = string.Empty;
            health.OnDead += () => message = "On Dead Event Triggered";
            health.TakeDamage(_attacker);


            //Assert
            Assert.AreNotEqual(string.Empty, message);




        }
        [Test]

        public void TakedNormalDamageOnDeadNotTriggered()
        {
            //Arrange
            int maxHealth = 100;
            IHealth health = GetHealth(maxHealth);

            //Act

            _attacker.Damage.Returns(maxHealth / 2);
            string expectedResult = string.Empty;
            string message = expectedResult;

            health.OnDead += () => message = "On Dead Event Triggered";
            health.TakeDamage(_attacker);


            //Assert
            Assert.AreEqual(expectedResult, message);




        }

        [Test]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]


        public void TakedFatalDamageManyTimeOnTookDamageTriggeredOneTime(int value)
        {
            //Arrange
            int maxHealth = 100;
            IHealth health = GetHealth(maxHealth);
            int damageLoop = value;

            //Act

            _attacker.Damage.Returns(maxHealth + 1);
            int damageCounter = 0;
            health.OnTookDamage += () => damageCounter++;

            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(_attacker);
                
            }



            //Assert
            Assert.AreEqual(1, damageCounter);




        }

    }

}