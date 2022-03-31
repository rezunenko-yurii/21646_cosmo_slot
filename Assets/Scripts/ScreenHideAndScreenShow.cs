using Core;
using UnityEngine;

public class ScreenHideAndScreenShow : ScreenHide
{
    [SerializeField] private string screenToShowId;
    protected override void OnHidden(IUIObject obj)
    {
        base.OnHidden(obj);
        ScreensManager.Show(screenToShowId);
    }

    protected override void TryHide()
    {
        string lastId = ScreensManager.GetLastId();
        if (lastId.Equals(screenToShowId))
        {
            Debug.Log($"{nameof(ScreenHideAndScreenShow)} {nameof(TryHide)} can`t open new screen // it`s already open");
        }
        else
        {
            base.TryHide();
        }
    }
}