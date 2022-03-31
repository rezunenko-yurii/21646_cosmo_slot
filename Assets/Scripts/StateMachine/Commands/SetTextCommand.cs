using StateMachine.Commands;
using TMPro;
using UnityEngine;

namespace StateMachine.States
{
    public class SetTextCommand : BaseCommand
    {
        [SerializeField] private TextMeshProUGUI textfield;
    
        [SerializeField] private string text;
        [SerializeField] private Color color;
        
        public override void Handle()
        {
            if (string.IsNullOrEmpty(text))
            {
                textfield.enabled = false;
            }
            else
            {
                textfield.enabled = true;
                textfield.text = text;
                textfield.color = color;
            }
        }
    }
}