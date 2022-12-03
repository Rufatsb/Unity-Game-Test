using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Concretes.Controllers;

namespace Movements
{
    public class player_movement : MonoBehaviour
    {
        [UnityTest]
        [TestCase(1f,ExpectedResult =(IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]


        public IEnumerator PlayerMoveLeftOrRightNotEqualStartPosition(float inputValue)
        {
            //Arrange//

            GameObject playerObject = new GameObject(name:"Player");

            PlayerController playerController = playerObject.AddComponent<PlayerController>();

            playerController.InputReader = Substitute.For<IInputReader>();

            Vector3 startPosition = playerController.transform.position;

            //Act//

            playerController.InputReader.Horizontal.Returns(inputValue);

            yield return new WaitForSeconds(3F);



            //Assert//
            Assert.AreNotEqual(startPosition, playerObject.gameObject.transform.position);
        }
    }

}