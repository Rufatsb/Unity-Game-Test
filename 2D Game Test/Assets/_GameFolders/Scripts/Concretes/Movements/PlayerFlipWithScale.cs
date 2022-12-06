
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Concretes.Controllers;

namespace UnityTddBeginner.Movements
{

    public class PlayerFlipWithScale : IFlip
    {

         readonly  Transform _transform;
         readonly IPlayerController _playerController;


        public PlayerFlipWithScale(IPlayerController playerController)
        {
            _transform = playerController.transform.GetChild(0).transform;
            _playerController = playerController; 
        }
       

        public void Tick()
        {
            _transform.localScale = new Vector3(_playerController.InputReader.Horizontal,1f,1f);
        }
    }

}
