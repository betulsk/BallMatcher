using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructer
{
    public interface IGamePlayManager
    {
        void FindBallListByColor();
        void SelectBall();
        void PullingBalls(List<GameObject> balls);
        void RemoveTriggeredBall(Collider collider);
    }
}
