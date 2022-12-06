using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Movements;
using UnityTddBeginner.Concretes.ScriptableObjects;
using UnityTddBeginner.Inputs;

namespace UnityTddBeginner.Concretes.Controllers
{ 
public class PlayerController : MonoBehaviour,IPlayerController

{
        
         [SerializeField] 
        PlayerStats _playerStats;


        public   IInputReader InputReader { get; set; }

        public IPlayerStats Stats => _playerStats;




        IMover _mover;
        IFlip _flip;

        void Awake()
        {
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
            _flip = new PlayerFlipWithScale(this);
        }

        void Update()
        {
            _mover.Tick();
            _flip.Tick();
        }
      
        void FixedUpdate()
        {
            //_mover.FixedTick();
        }
 
    
}

}

