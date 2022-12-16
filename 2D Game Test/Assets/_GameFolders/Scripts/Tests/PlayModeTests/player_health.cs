using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Concretes.Controllers;

namespace Combats
{


    public class player_health
    {

        IPlayerController _player;
        IEnemyController _enemy;


        private IEnumerator LoadPlayerMoveTestScene()
        {
            yield return SceneManager.LoadSceneAsync("CombatTest");

        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadPlayerMoveTestScene();

            _player = GameObject.FindObjectOfType<PlayerController>();
            _enemy = GameObject.FindObjectOfType<EnemyController>();

            //_player.InputReader = Substitute.For<IInputReader>();


        }
        [UnityTest]
        public IEnumerator playerTakeOneDamage()
        {
            //Arrange
          

            //Act
            int maxHealth = _player.Health.CurrentHealth;
            Vector3 playerPosition = _player.transform.position;

            _enemy.transform.position = playerPosition;

            //Assert
            
            yield return new WaitForSeconds(3f);

            Assert.AreEqual(maxHealth - 1,_player.Health.CurrentHealth);
        }
    }

}