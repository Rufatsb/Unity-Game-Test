using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Concretes.Movements;

namespace UnityTddBeginner.Concretes.Controllers
{ 
public class PlayerController : MonoBehaviour,IPlayerController

{
     public   IInputReader InputReader { get; set; }



        //movement
        IMover _mover;

        void Awake()
        {
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

