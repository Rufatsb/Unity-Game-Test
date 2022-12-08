using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Concretes.Controllers;
using UnityTddBeginner.Movements;

namespace Movements
{
    public class player_flip
    {
        IPlayerController _playerController;

        private IEnumerator LoadPlayerMoveTestScene()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");

        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadPlayerMoveTestScene();

            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.InputReader = Substitute.For<IInputReader>();


        }

        [UnityTest]
        [TestCase(1f,ExpectedResult = null)]
        [TestCase(-1f, ExpectedResult = null)]
        public IEnumerator PlayerGetInputValueBodyScalexResultEqualInputValue(float horizontalInput)
        {
            //Arrange




            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(horizontalInput, _playerController.transform.GetChild(0).transform.localScale.x);


        }
        [UnityTest]
        [TestCase(1f, ExpectedResult = null)]
        [TestCase(-1f, ExpectedResult = null)]


        public IEnumerator PlayerGetInputValueAfterInputGet0BodyScalexResultEqualFirstInputValue(float horizontalInput)
        {
            //Arrange
          
            float firstInputValue = horizontalInput;



            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);
            horizontalInput = 0;
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);


            //Assert
            Assert.AreEqual(firstInputValue, _playerController.transform.GetChild(0).transform.localScale.x);

        }
    }
}
