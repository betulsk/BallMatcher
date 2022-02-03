using Assets.Scripts.Infrastructer;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Derived
{
    public class OrangeBallScript : MonoBehaviour
    {
        private readonly IGamePlayManager _gamePlayManager;
        public OrangeBallScript()
        {
            _gamePlayManager = new GamePlayManager(StaticWords.ORANGE);
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
