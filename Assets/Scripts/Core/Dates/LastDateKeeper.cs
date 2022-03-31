using System;
using Dates;
using UnityEngine;

namespace Core.Dates
{
    public class LastDateKeeper : DateKeeper
    {
        public int DaysPassed()
        {
            return (int) (DateTime.Now - Date).TotalDays;
        }
        
        public void Update()
        {
            var now = DateTimeOffset.Now.Add(new TimeSpan(0,0,1));
            Debug.Log($"{nameof(LastDateKeeper)} {nameof(Update)} newLastDate={now}");
            
            Date = now;
        }

        public LastDateKeeper(Enum id) : base(id) { }
        public LastDateKeeper(string id) : base(id) { }
        protected override string DateCounterPref { get; } = "LastDateKeeper";
    }
}