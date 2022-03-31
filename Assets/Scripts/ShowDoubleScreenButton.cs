using Core.Buttons;
using SlotsGame.Scripts;
using SlotsGame.Scripts.Combinations;
using Zenject;

public class ShowDoubleScreenButton : ShowScreenButton
{
    private CombinationHolder _combinationHolder;
    private bool isPlayed = false;

    protected override void Start()
    {
        base.Start();
            
        //ChangeInteractableState(false);
    }

    [Inject]
    private void Init(CombinationHolder combinationHolder)
    {
        _combinationHolder = combinationHolder;
    }

    protected override void OnClick()
    {
        base.OnClick();
        return;
        if (CanPlay())
        {
            isPlayed = true;
            base.OnClick();
                
            ChangeInteractableState(false);
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        signalBus.Subscribe<Game.Signal.EffectsEnded>(Reset);
    }
        
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        signalBus.Unsubscribe<Game.Signal.EffectsEnded>(Reset);
    }

    private void Reset()
    {
        isPlayed = false;
            
        if (CanPlay())
        {
            ChangeInteractableState(true);
        }
    }

    private bool CanPlay()
    {
        var winCombinations = _combinationHolder.GetWinCombinations();
        if (winCombinations.Count > 0 && !isPlayed)
        {
            return true;
        }

        return false;
    }
}