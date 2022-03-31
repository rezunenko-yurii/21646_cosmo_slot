using System;
using Core.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Buttons
{
    [RequireComponent(typeof(Button))]
    public class NormalButton : AdvancedMonoBehaviour
    {
        public event Action Clicked;
        
        [SerializeField] private SoundName soundName;
        [SerializeField] protected TextMeshProUGUI textfield;
        [SerializeField] protected bool canChangeText = true;
        [Inject] private SoundsController _soundsController;
        
        protected Button Button { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Button = GetComponent<Button>();
        }
        
        protected virtual void OnClick()
        {
            //Debug.Log($"{this.name} {nameof(NormalButton)} {nameof(OnClick)}");
            _soundsController.Play(soundName);
            Clicked?.Invoke();
        }

        public void SetNoClickable()
        {
            ChangeInteractableState(false);
        }
        
        public void SetClickable()
        {
            ChangeInteractableState(true);
        }
        
        public virtual void ChangeInteractableState(bool isClickable)
        {
            Button.interactable = isClickable;
        }

        public bool IsInteractable => Button.interactable;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            CheckAvailability();
        }

        protected override void AddListeners()
        {
            Debug.Log($"{this.name} {nameof(NormalButton)} {nameof(AddListeners)}");
            Button.onClick.AddListener(OnClick);
            Button.enabled = true;
        }
        
        protected override void RemoveListeners()
        {
            Debug.Log($"{this.name} {nameof(NormalButton)} {nameof(RemoveListeners)}");
            Button.onClick.RemoveListener(OnClick);
            Button.enabled = false;
        }

        public void SetText(string text)
        {
            textfield.text = text;
        }

        protected virtual void CheckAvailability() { }
    }
}