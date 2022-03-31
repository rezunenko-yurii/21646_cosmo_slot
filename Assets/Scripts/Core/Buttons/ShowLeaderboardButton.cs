using Core.Buttons;
using GameCenter.Signals;
using Zenject;

public class ShowLeaderboardButton : NormalButton
{
    [Inject] private SignalBus _signalBus;
    protected override void OnClick()
    {
        base.OnClick();
        _signalBus.Fire<ShowLeaderboard>();
    }
}
