using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Movements;

namespace Movements
{
    public class player_flip
    {
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]


        public void InputValue1PlayerScaleXResultEqual1(float horizontalInput)
        {
            //Arrange

            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject parent = new();
            GameObject body = new ();
            body.transform.SetParent(parent.transform);
            playerController.transform.Returns(parent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);


            IFlip flip = new PlayerFlipWithScale(playerController);

            //Act

            for (int i = 0; i < 10; i++)
            {
                flip.Tick();

            }

            //Assert

            Assert.AreEqual(horizontalInput, body.transform.localScale.x);

        }
    }

}