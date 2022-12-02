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
        private IPlayerController GetPlayer ()
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gameObject = new GameObject();

            playerController.transform.Returns(gameObject.transform);

            playerController.InputReader = Substitute.For<IInputReader>();

            return playerController;
        }

        private IMover GetMover(IPlayerController playerController)
        {
            IMover mover = new PlayerMoveWithTranslate(playerController);

            return mover;

        }
         
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]

        public void Move10MetersRightorLeftNotEqualStartPosition(float horizontalInputValue)
        {
            //Arrange
            
         var playerController = GetPlayer ();
         var mover =  GetMover(playerController);

         Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInputValue);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            
      




            //Assert

            Assert.AreNotEqual(expected:startPosition,actual: playerController.transform.position);

        }

        [Test]
        public void Move10MetersRightEndPositionGreaterThanStartPosition()
        {
            //Arrange

            var playerController = GetPlayer();


            var mover = GetMover(playerController);


            Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            




            //Assert

            Assert.Greater(playerController.transform.position.x,startPosition.x);

        }

        

        [Test]
        public void Move10MetersLeftEndPositionGreaterThanStartPosition()
        {
            //Arrange

            var playerController = GetPlayer();


            var mover = GetMover(playerController);


            Vector3 startPosition = playerController.transform.position;



            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();      //input
                mover.FixedTick(); //act with input

            }

            




            //Assert

            Assert.Less (playerController.transform.position.x, startPosition.x);

        }
    }

   
}