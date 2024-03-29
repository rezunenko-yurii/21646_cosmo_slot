﻿using System;
using UnityEngine;
using Zenject;

namespace Core.Timers
{
    public class Timer : IFixedTickable
    {
        public event Action Started;
        public event Action Over;
        public event Action<TimeSpan> Counting;
    
        protected DateTimeOffset nextDate;
        protected TimeSpan _expireTimeSpan;

        public void SetTimer(DateTimeOffset nextDate)
        {
            this.nextDate = nextDate;
            _expireTimeSpan = nextDate - DateTimeOffset.Now;
        
            Restart();
        }
        
        public double SecondsLeft => _expireTimeSpan.TotalSeconds;
        public double HoursLeft => _expireTimeSpan.TotalHours;
        public double MinutesLeft => _expireTimeSpan.TotalMinutes;
        public TimeSpan ExpireTimeSpan => _expireTimeSpan;
        public bool IsExpired => _expireTimeSpan.TotalMilliseconds <= 0;
        private bool _CanCount;

        public bool IsInited { get; protected set; }

        public virtual void Init()
        {
            IsInited = true;
        }
    
        protected virtual void OnStarted()
        {
            _CanCount = true;
            Started?.Invoke();
        }
        protected virtual void OnOver()
        {
            _CanCount = false;
            Over?.Invoke();
        }

        protected virtual void OnCounting()
        {
            _expireTimeSpan = nextDate - DateTimeOffset.Now;
            Counting?.Invoke(_expireTimeSpan);
        }
    
        private void StartCounter()
        {
            if (!IsExpired)
            {
                Debug.Log($"Countdown timer started {_expireTimeSpan.TotalSeconds}");
            
                OnStarted();
            }
        }

        protected void Restart()
        {
            StartCounter();
        }
    

        public void FixedTick()
        {
            OnTick();
        }

        protected virtual void OnTick()
        {
            if (_CanCount)
            {
                if (IsExpired)
                {
                    OnOver();
                }
                else
                {
                    OnCounting();
                }
            }
        }

        protected void Stop()
        {
            if (_CanCount && !IsExpired)
            {
                _CanCount = false;
            }
        }
    }
}