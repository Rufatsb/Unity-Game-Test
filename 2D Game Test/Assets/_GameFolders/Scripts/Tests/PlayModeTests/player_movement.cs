using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Concretes.Controllers;

namespace Movements
{
    public class player_movement
    {
        IPlayerController _playerController;

        private IEnumerator LoadPlayerMoveTestScene()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");

        }

        [UnitySetUp]
        IEnumerator  Setup()
        {
            yield return LoadPlayerMoveTestScene();

            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.InputReader = Substitute.For<IInputReader>();


        }



        [UnityTest]
        [TestCase(1f,ExpectedResult = null)]
        [TestCase(-1f, ExpectedResult = null)]
        public IEnumerator PlayerMoveLeftOrRightNotEqualStartPosition(float inputValue)
        {
            //Arrange//
            Vector3 startPosition = _playerController.transform.position;

            //Act//

            _playerController.InputReader.Horizontal.Returns(inputValue);
            yield return new WaitForSeconds(3F);



            //Assert//

            Assert.AreNotEqual(startPosition, _playerController.transform.position);
        }

        [UnityTest]
      
        public IEnumerator PlayerMoveRightEndPositionGreaterThanStartPosition()
        {
            //Arrange//
            Vector3 startPosition = _playerController.transform.position;

            //Act//

            _playerController.InputReader.Horizontal.Returns(1f);
            yield return new WaitForSeconds(3F);



            //Assert//

            Assert.Greater(_playerController.transform.position.x, startPosition.x);
        }

        [UnityTest]

        public IEnumerator PlayerMoveLefttEndPositionGreaterThanStartPosition()
        {
            //Arrange//
            Vector3 startPosition = _playerController.transform.position;

            //Act//

            _playerController.InputReader.Horizontal.Returns(-1f);
            yield return new WaitForSeconds(3F);



            //Assert//

            Assert.Less(_playerController.transform.position.x, startPosition.x);
        }
    }

}