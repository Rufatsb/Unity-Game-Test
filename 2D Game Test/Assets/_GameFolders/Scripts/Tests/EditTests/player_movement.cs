using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Concretes.Movements;

namespace Movements

{
    public class player_movement
    {
        [Test]
        public void Move10MetersRightNotEqualStartPosition()
        {
            //Arrange

         IPlayerController playerController = Substitute.For<IPlayerController>();

         GameObject gameObject = new GameObject();
         
         playerController.transform.Returns(gameObject.transform);

            playerController.InputReader = Substitute.For<IInputReader>();

         IMover mover = new PlayerMoveWithTranslate(playerController, playerController.transform);

         Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            Debug.Log("Player start position => " + startPosition);
            Debug.Log("Player end position => " + playerController.transform.position);




            //Assert

            Assert.AreNotEqual(expected:startPosition,actual: playerController.transform.position);

        }

        [Test]
        public void Move10MetersRightEndPositionGreaterThanStartPosition()
        {
            //Arrange

            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gameObject = new GameObject();

            playerController.transform.Returns(gameObject.transform);

            playerController.InputReader = Substitute.For<IInputReader>();

            IMover mover = new PlayerMoveWithTranslate(playerController, playerController.transform);

            Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            Debug.Log("Player start position => " + startPosition);
            Debug.Log("Player end position => " + playerController.transform.position);




            //Assert

            Assert.Greater(playerController.transform.position.x,startPosition.x);

        }

        [Test]
        public void Move10MetersLeftNotEqualStartPosition()
        {
            //Arrange

            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gameObject = new GameObject();

            playerController.transform.Returns(gameObject.transform);

            playerController.InputReader = Substitute.For<IInputReader>();

            IMover mover = new PlayerMoveWithTranslate(playerController, playerController.transform);

            Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            Debug.Log("Player start position => " + startPosition);
            Debug.Log("Player end position => " + playerController.transform.position);




            //Assert

            Assert.AreNotEqual(expected: startPosition, actual: playerController.transform.position);

        }

        [Test]
        public void Move10MetersLeftEndPositionGreaterThanStartPosition()
        {
            //Arrange

            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gameObject = new GameObject();

            playerController.transform.Returns(gameObject.transform);

            playerController.InputReader = Substitute.For<IInputReader>();

            IMover mover = new PlayerMoveWithTranslate(playerController, playerController.transform);

            Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            Debug.Log("Player start position => " + startPosition);
            Debug.Log("Player end position => " + playerController.transform.position);




            //Assert

            Assert.Less (playerController.transform.position.x, startPosition.x);

        }
    }

   
}