using Assets.Scripts.Infrastructer;
using Assets.Scripts.Models;
using Assets.Scripts.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Derived
{
    public class YellowBallScript : MonoBehaviour
    {
        private readonly IGamePlayManager _gamePlayManager;
        public YellowBallScript()
        {
            _gamePlayManager = new GamePlayManager(StaticWords.YELLOW);
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
