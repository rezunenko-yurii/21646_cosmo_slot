using Core;
using SlotsGame.Scripts.Lines;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LinesImages : AdvancedMonoBehaviour
{
    [SerializeField] private Image[] lines;
    
    [Inject] private LinesManager _linesManager;
    
    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        OnLinesCountChanged();
    }

    protected override void AddListeners()
    {
        _linesManager.CountChanged += OnLinesCountChanged;
    }

    protected override void RemoveListeners()
    {
        _linesManager.CountChanged -= OnLinesCountChanged;
    }

    private void OnLinesCountChanged(int count = 0)
    {
        HideAllLines();
        ShowLines();
    }

    private void ShowLines()
    {
        for (int i = 0; i <= _linesManager.Count; i++)
        {
            lines[i].gameObject.SetActive(true);
        }
    }

    private void HideAllLines()
    {
        foreach (var image in lines)
        {
            image.gameObject.SetActive(false);
        }
    }
}
