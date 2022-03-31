using Core.Buttons;
using SlotsGame.Scripts.Bets;
using SlotsGame.Scripts.Lines;
using UnityEngine;

namespace SlotsGame.Scripts
{
    public class Controls : MonoBehaviour
    {
        [SerializeField] private NormalButton spinButton;
        //[SerializeField] private NormalButton doubleButton;
        //[SerializeField] private NormalButton challengesButton;
        [SerializeField] private NormalButton paytableButton;
        [SerializeField] private NormalButton shopButton;
        [SerializeField] private LinesTextStepper linesTextStepper;
        [SerializeField] private BetsTextStepper betsTextStepper;
        //[SerializeField] private MaxBetButton maxBetButton;

        public void Lock()
        {
            Debug.Log($"{this.name} {nameof(Controls)} {nameof(Lock)}");
            
            DisableButton(spinButton);
            //DisableButton(maxBetButton);
            //DisableButton(doubleButton);
            DisableButton(paytableButton);
            //DisableButton(challengesButton);
            DisableButton(shopButton);
            
            linesTextStepper.enabled = false;
            betsTextStepper.enabled = false;
        }
        
        public void Unlock()
        {
            Debug.Log($"{this.name} {nameof(Controls)} {nameof(Unlock)}");

            EnableButton(spinButton);
            //EnableButton(maxBetButton);
            //EnableButton(doubleButton);
            EnableButton(paytableButton);
            //EnableButton(challengesButton);
            EnableButton(shopButton);
            
            linesTextStepper.enabled = true;
            betsTextStepper.enabled = true;
        }

        private void DisableButton(NormalButton button)
        {
            ChangeButtonState(button, false);
        }
        
        private void EnableButton(NormalButton button)
        {
            ChangeButtonState(button, true);
        }

        private void ChangeButtonState(NormalButton button, bool state)
        {
            //button.enabled = state;
            button.ChangeInteractableState(state);
        }
    }
}