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
        [UnityTest]
        [TestCase(1f,ExpectedResult = null)]
        [TestCase(-1f, ExpectedResult = null)]
        public IEnumerator InputValue1PlayerScaleXResultEqual1(float horizontalInput)
        {
            //Arrange

            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            IPlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.InputReader = Substitute.For<IInputReader>();


            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(horizontalInput, playerController.transform.GetChild(0).transform.localScale.x);


        }
    }
}
