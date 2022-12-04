using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;

namespace UnityTddBeginner.Concretes.Movements
{

public class PlayerMoveWithTranslate : IMover
{
        float _horizontalInput = 0f;
       
        readonly IPlayerController _playerController;
        readonly Transform _transform;

       

        public PlayerMoveWithTranslate(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.transform;
        }


        public void Tick()
        {
            _horizontalInput = _playerController.InputReader.Horizontal;
        }

        public void FixedTick()
        {
            _transform.Translate(translation:(Vector3)(Vector2.right * _horizontalInput * _playerController.Stats.MoveSpeed * Time.deltaTime ));
        }




    }

}

