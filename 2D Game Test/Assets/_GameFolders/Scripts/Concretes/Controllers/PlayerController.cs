using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;
using UnityTddBeginner.Abstracts.Movements;
using UnityTddBeginner.Abstracts.ScriptableObjects;
using UnityTddBeginner.Movements;
using UnityTddBeginner.Concretes.ScriptableObjects;
using UnityTddBeginner.Inputs;
using UnityTddBeginner.Abstracts.Combats;
using UnityTddBeginner.Combats;

namespace UnityTddBeginner.Concretes.Controllers
{ 
public class PlayerController : MonoBehaviour,IPlayerController

{
        
         [SerializeField] 
        PlayerStats _playerStats;
        IMover _mover;
        IFlip _flip;

        public   IInputReader InputReader { get; set; }

        public IPlayerStats Stats => _playerStats;

        public IHealth Health { get; set; }




      

        void Awake()
        {
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
            _flip = new PlayerFlipWithScale(this);
            Health = new Health(_playerStats.MaxHealth);
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
      
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(nameof(Collision2D));
        }

    }
   

}

