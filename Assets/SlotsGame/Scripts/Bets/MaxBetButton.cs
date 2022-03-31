using Core.Buttons;
using UnityEngine;

namespace SlotsGame.Scripts.Bets
{
    public class MaxBetButton : NormalButton
    {
        [SerializeField] private BetsTextStepper betsTextStepper;
        
        protected override void OnClick()
        {
            base.OnClick();
            betsTextStepper.SetLast();
        }
    }
}