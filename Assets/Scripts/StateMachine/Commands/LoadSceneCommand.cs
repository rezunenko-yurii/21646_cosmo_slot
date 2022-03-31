using StateMachine.Commands;
using StateMachine.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelButtonModule.States
{
    public class LoadSceneCommand : BaseCommand
    {
        [SerializeField] protected string levelName;
        
        public override void Handle()
        {
            SceneManager.LoadScene(levelName);
        }
    }
}