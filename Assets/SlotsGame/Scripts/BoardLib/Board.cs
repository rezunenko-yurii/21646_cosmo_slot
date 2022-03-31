using System;
using Core;
using SlotsGame.Scripts.ReelsLib;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.BoardLib
{
    public class Board : AdvancedMonoBehaviour
    {
        public event Action Over;
        
        [Inject] private Reels _reels;

        [SerializeField] private RectTransform container;
        [SerializeField] private BoardAnimController controller;

        public void Init()
        {
            _reels.Init(container);
        }
        
        private void OnAnimOver()
        {
            Over?.Invoke();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            //controller.Subscribe();
            controller.OnSpinOver += OnAnimOver;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            //controller.Unsubscribe();
            controller.OnSpinOver -= OnAnimOver;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            //controller.Stop();
        }

        public void Play()
        {
            HideCombinations();
            controller.Play();
        }

        public void ShowCombinations()
        {
            _reels.ShowCombinations();
        }

        public void HideCombinations()
        {
            _reels.HideCombinations();
        }

        public void Appear()
        {
            _reels.Appear();
        }

        public void Prepare()
        {
            _reels.Prepare();
        }

        public void Stop()
        {
            controller.Stop();
        }
    }
}