﻿using Core.Finances.Moneys;
using Lives;
using Users;
using Zenject;

namespace MemoryMatch.Scripts
{
    public class BuyLifeAndStartGame : ScreenHideAndScreenShow
    {
        [Inject] private LivesManager _livesManager;
        [Inject] private User _user;
        [Inject] private LevelsManager _levelsManager;

        private Coins _coins;

        protected override void Initialize()
        {
            base.Initialize();
            _coins = new Coins {Amount = 100};
        }

        protected override void OnClick()
        {
            if (_user.Wallets.HasOnBalance(_coins))
            {
                _user.Wallets.Subtract(_coins);
                _livesManager.TryAddLive();
                base.OnClick();
            }
        }
    }
}