using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Inputs;

namespace UnityTddBeginner.Concretes.Controllers
{ 
public class PlayerController : MonoBehaviour,IPlayerController

{
     public   IInputReader InputReader { get; set; }


        void Start()
    {
        //movement
        //atack
        //health
        //flip
        //jump or double jump
        //collect
        //animation
    }

    void Update()
    {

    }
}

}

