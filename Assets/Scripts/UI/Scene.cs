using Core.GameScreens;
using Zenject;

namespace UI
{
    public class Scene : UIObject
    {
        [Inject] private ScreensManager screensManager;
        [Inject] private Scenes scenes;
        
        protected SceneModel sceneModel { get; private set; }
        
        protected override void Initialize()
        {
            base.Initialize();
            sceneModel = scenes.GetObject(Id);
        }

        protected override void Main()
        {
            base.Main();
            screensManager.Show(sceneModel.StartScreenId);
        }
    }
}