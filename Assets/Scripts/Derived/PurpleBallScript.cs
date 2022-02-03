using Assets.Scripts.Infrastructer;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Derived
{
    public class PurpleBallScript : MonoBehaviour
    {
        private readonly IGamePlayManager _gamePlayManager;
        public PurpleBallScript()
        {
            _gamePlayManager = new GamePlayManager(StaticWords.PURPLE);
        }
        private void Start()
        {
            _gamePlayManager.FindBallListByColor();
        }
        private void Update()
        {
            _gamePlayManager.SelectBall();
        }
        private void OnTriggerEnter(Collider collider)
        {
            _gamePlayManager.RemoveTriggeredBall(collider);
        }
    }
}
