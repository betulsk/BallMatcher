using Assets.Scripts.Infrastructer;
using Assets.Scripts.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Derived
{
    public class GamePlayManager : IGamePlayManager
    {
        private GameObject ActiveObject { get; set; }
        private List<GameObject> ballList = new List<GameObject>();
        private readonly string _color = string.Empty;

        public GamePlayManager(string ballColor)
        {
            _color = ballColor;
        }
        public void FindBallListByColor()
        {
            Time.timeScale = 1;
            ballList = GameObject.FindGameObjectsWithTag(StaticWords.BALL).Where(x => x.name.ToLower().Contains(_color)).ToList();
        }
        public void SelectBall()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.transform.gameObject.name.ToLower().Contains(_color))
                        {
                            ActiveObject = hit.transform.gameObject;
                            List<GameObject> ballModels = ballList.Where(x => x.name != ActiveObject.name).ToList();
                            PullingBalls(ballModels);
                        }
                    }
                }
            }
        }

        public void PullingBalls(List<GameObject> balls)
        {
            foreach (var item in balls)
            {
                Vector3 direction = (ActiveObject.transform.position - item.transform.position).normalized;
                item.GetComponent<Rigidbody>().AddForce(direction * 100);
            }
        }

        public void RemoveTriggeredBall(Collider collider)
        {
            if (!collider.name.ToLower().Contains(_color))
            {
                Time.timeScale = 0;
                UIManager.Instance.Fail();
            }
            else if (ActiveObject != null && collider.name != ActiveObject.name)
            {
                collider.gameObject.SetActive(false);
                WinControl();
            }
        }

        private void WinControl()
        {
            var totalDistinctColoredBall = GameObject.FindGameObjectsWithTag(StaticWords.BALL).Where(x => x.gameObject.active).GroupBy(x => x.layer);
            int distinctBallColorCount = 0;

            foreach (var item in totalDistinctColoredBall)
            {
                if (item.Count() == 1)
                    distinctBallColorCount++;
            }

            if (distinctBallColorCount == totalDistinctColoredBall.Count())
            {
                UIManager.Instance.Win(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}
