using Assets.Scripts.Derived;
using Assets.Scripts.Infrastructer;
using Assets.Scripts.Models;
using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class RedBallScript : MonoBehaviour
{
    private readonly IGamePlayManager _gamePlayManager;
    public RedBallScript()
    {
        _gamePlayManager = new GamePlayManager(StaticWords.RED);
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

