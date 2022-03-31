using System;
using Core.Dates;
using Dates;
using UnityEngine;

namespace DailyReward
{
    public class EveryDayCounter
    {
        public Action Updated;
        private const string EveryDayCounterPref = "EveryDayCounter";

        private readonly string _id;
        private readonly string _daysId;

        private LastDateKeeper _lastDateKeeper;

        public int MaxDays { get;}
        public int MaxDaysGap { get;}
        
        private int _days;
        public int CurrentDay
        {
            get
            {
                if (_days != 0)
                {
                    var daysPassed = _lastDateKeeper.DaysPassed();
                    if (daysPassed > MaxDaysGap)
                    {
                        Reset();
                    }
                }
                
                return _days;
            }
            private set
            {
                _days = value;
                PlayerPrefs.SetInt(_daysId, _days);
                Updated?.Invoke();
            }
        }

        private int GetNextDay()
        {
            int nextDay = _days + 1;
            if (nextDay >= MaxDays)
            {
                return 0;
            }
            else
            {
                return nextDay;
            }
        }
        
        public EveryDayCounter(Enum id, int maxDays, int maxDaysGap) : this(id.ToString(), maxDays, maxDaysGap) { }
        
        public EveryDayCounter(string id, int maxDays, int maxDaysGap)
        {
            Debug.Log($"{nameof(EveryDayCounter)} Constructor // id={id} maxDays={maxDays}");
            _id = id;
            MaxDays = maxDays;
            MaxDaysGap = maxDaysGap;
        
            _daysId = $"{EveryDayCounterPref} {_id}";

            Load();
        }

        public void SetDateKeeper(LastDateKeeper dateKeeper)
        {
            _lastDateKeeper = dateKeeper;
        }
    
        private void Load()
        {
            _days = PlayerPrefs.GetInt(_daysId, 0);
        }

        private void Reset()
        {
            CurrentDay = 0;
        }

        public void Update()
        {
            _lastDateKeeper.Update();
            CurrentDay = GetNextDay();
        }
    }
}