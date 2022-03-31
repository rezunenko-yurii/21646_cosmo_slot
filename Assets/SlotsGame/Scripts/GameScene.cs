using System.Collections;
using Core;
using Core.Audio;
using Finances.Moneys;
using SlotsGame.Scripts.AutoSpins;
using SlotsGame.Scripts.BoardLib;
using SlotsGame.Scripts.Combinations;
using SlotsGame.Scripts.Effects;
using SlotsGame.Scripts.Lines;
using UnityEngine;
using Users;
using Zenject;

namespace SlotsGame.Scripts
{
    public class GameScene : AdvancedMonoBehaviour
    {
        [Inject] private Board board;
        [SerializeField] private Controls _controls;
        [SerializeField] private AudioClip _music;
        [SerializeField] private Spinner _spinner;
    
        [Inject] private EffectsManager _effectsManager;
        [Inject] private CombinationHolder _combinationHolder;
        [Inject] private LinesManager _linesManager;
        [Inject] private AutoSpin _autoSpin;
        [Inject] private CombinationRewards _combinationRewards;

        [SerializeField] private AudioClip _spinSound;
        [Inject] private SoundsController _soundsController;

        [Inject] private SignalBus _signalBus;
        [Inject] private User user;

        private Coroutine _coroutine;
        private AudioSource _audioSource;
    
        protected override void Initialize()
        {
            base.Initialize();
        
            _combinationHolder.Init();
            board.Init();
            board.Appear();
        }

        protected override void Main()
        {
            base.Main();
        
            //_slotMoneyHelper.GetFreeSpinsReward(15);

            /*var i = PlayerPrefs.GetInt("WelcomeFreeSpins", 0);
        if (i == 0)
        {
            PlayerPrefs.SetInt("WelcomeFreeSpins", 1);
            _effectsManager.AddToQuery(EffectsTypes.FreeSpins);
            _autoSpin.TransitionTo(AutoSpinType.ForcedAmount, 15);
        
            _signalBus.Fire(new Game.Signal.EffectsStarted());
            _effectsManager.Play();
        }*/
            /*float freespins = user.Wallets.Wallet(typeof(Spins)).Balance();
        if (freespins > 0)
        {
            _effectsManager.AddToQuery(EffectsTypes.FreeSpins);
            _autoSpin.TransitionTo(AutoSpinType.ForcedAmount, (int) freespins);
        
            _signalBus.Fire(new Game.Signal.EffectsStarted());
            _effectsManager.Play();
        }*/
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
        
            float freespins = user.Wallets.Wallet(typeof(Spins)).Balance();
            if (freespins > 0)
            {
                _effectsManager.AddToQuery(EffectsTypes.FreeSpins);
                _autoSpin.TransitionTo(AutoSpinType.ForcedAmount, (int) freespins);
        
                _signalBus.Fire(new Game.Signal.EffectsStarted());
                _effectsManager.Play();
            }
            else
            {
                _controls.Unlock();
            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();
        
            _spinner.Clicked += OnSpin;
            board.Over += OnSpinEnded;
            _effectsManager.Completed += OnEffectsCompleted;
        }
    
        protected override void RemoveListeners()
        {
            base.RemoveListeners();
        
            _spinner.Clicked -= OnSpin;
            board.Over -= OnSpinEnded;
            _effectsManager.Completed -= OnEffectsCompleted;
        }
    
        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
        
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                board.Stop();
            }
            
            TryStopSound();
        }

        private void OnSpin()
        {
            Debug.Log($"{nameof(GameScene)} {nameof(OnSpin)}");
            _signalBus.Fire(new Game.Signal.SpinStarted());
        
            _controls.Lock();
            _combinationHolder.Clear();
            _linesManager.Clear();
        
            _combinationHolder.Shuffle();
            board.Prepare();
            board.Play();
            
            _audioSource = _soundsController.PlayLooped(_spinSound);
        }
    
        private void OnSpinEnded()
        {
            Debug.Log($"{nameof(GameScene)} {nameof(OnSpinEnded)}");
            _signalBus.Fire(new Game.Signal.SpinEnded());
        
            _combinationHolder.Find();
            board.ShowCombinations();
        
            //TODO return rewards
            /*_slotMoneyHelper.GetScoresReward();
        _slotMoneyHelper.GetSpinReward();*/
        
            _combinationRewards.GetSpinReward();
        
            _signalBus.Fire(new Game.Signal.EffectsStarted());
            _effectsManager.Play();
        }

        private IEnumerator Pause(int seconds)
        {
            Debug.Log($"{nameof(GameScene)} {nameof(Pause)}");
            TryStopSound();
            yield return new WaitForSeconds(seconds);
        
            Debug.Log($"{nameof(GameScene)} {nameof(Pause)} Over");
        
            _controls.Unlock();
            _signalBus.Fire(new Game.Signal.EffectsEnded());
        
            if (!_autoSpin.Type.Equals(AutoSpinType.Off))
            {
                _spinner.Spin();
            }
            else
            {
                _signalBus.Fire(new Game.Signal.RoundEnded());
            }
        }

        private void TryStopSound()
        {
            if (!ReferenceEquals(_audioSource, null))
            {
                _soundsController.StopLooped(_audioSource);
            }
        }

        private void OnEffectsCompleted()
        {
            Debug.Log($"{nameof(GameScene)} {nameof(OnEffectsCompleted)}");
            _coroutine = StartCoroutine(Pause(1));
        }
    }
}
