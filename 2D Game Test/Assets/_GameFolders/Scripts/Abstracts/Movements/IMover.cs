using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTddBeginner.Abstracts.Controllers;
using UnityTddBeginner.Abstracts.Movements;


namespace UnityTddBeginner.Abstracts.Movements
{
    public interface IMover
    {
        void Tick();

        void FixedTick();
    }
}