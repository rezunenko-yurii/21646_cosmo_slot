using System;
using Core.DataSavers;
using UnityEngine;

namespace Dates
{
    public abstract class DateKeeper
    {
        protected abstract string DateCounterPref { get; }
        
        public Action Updated;
        private DateTimeOffsetSaver _saver;

        public DateTimeOffset Date
        {
            get => _saver.Value;
            protected set
            {
                _saver.SetValue(value);
                
                Updated?.Invoke();
            }
        }

        public void SaveCurrentTime()
        {
            Date = DateTimeOffset.Now;
        }
        
        protected DateKeeper(Enum id) : this(id.ToString()) { }
        
        protected DateKeeper(string id)
        {
            Debug.Log($"{nameof(DateKeeper)} Constructor // id={id}");
            
            _saver = new DateTimeOffsetSaver() { Id = $"{DateCounterPref} {id}"};
            _saver.Load();
        }
    }
}