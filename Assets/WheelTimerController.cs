using System;
using Core;
using Core.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WheelTimerController : AdvancedMonoBehaviour
{
    [Inject(Id = ModuleType.Wheel)] private MemoryTimer timer;
    [SerializeField] private Image backTimer;
    [SerializeField] private Image blackBack;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        if (!timer.IsExpired)
        {
            SetNoClickable();
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
            
        timer.Over += SetClickable;
        timer.Started += SetNoClickable;
        timer.Counting += UpdateText;
    }

    private void SetNoClickable()
    {
        blackBack.gameObject.SetActive(true);
        backTimer.gameObject.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
    }

    private void UpdateText(TimeSpan obj)
    {
        textMeshProUGUI.text = 
            $"{obj.Hours:00}:" +
            $"{obj.Minutes:00}:" +
            $"{obj.Seconds:00}";
    }

    private void SetClickable()
    {
        blackBack.gameObject.SetActive(false);
        backTimer.gameObject.SetActive(false);
        textMeshProUGUI.gameObject.SetActive(false);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
            
        timer.Over -= SetClickable;
        timer.Started -= SetNoClickable;
        timer.Counting -= UpdateText;
    }
}
