using UnityEngine;

namespace Core.Buttons
{
    public class BrowserOpenerButton : NormalButton
    {
        [SerializeField] private string url;

        protected override void OnClick()
        {
            base.OnClick();
        
            Application.OpenURL(url);
        }
    }
}
