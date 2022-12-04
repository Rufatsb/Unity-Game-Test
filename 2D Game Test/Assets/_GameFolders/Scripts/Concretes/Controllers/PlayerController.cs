using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Concretes.Movements;
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



        //movement

        IMover _mover;

        void Awake()
        {
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
        }

        void Update()
        {
            _mover.Tick();
        }
      
        void FixedUpdate()
        {
            _mover.FixedTick();
        }
 
    
}

}

