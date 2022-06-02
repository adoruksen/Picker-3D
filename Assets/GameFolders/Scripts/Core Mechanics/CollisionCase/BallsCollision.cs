using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

namespace Picker3D.CollisionCase
{
    public class BallsCollision
    {
        public void PushBallsOnPool(List<Transform> balls)
        {
            foreach (var item in balls)
            {
                item.DOJump(item.transform.forward, 1, 1, .5f);
            }
            Debug.Log("fýrlatti");
        }

        //public void AddToList(List<Transform> ballsList)
        //{
        //    for (int i = 0; i < ballsList.Count; i++)
        //    {
        //        balls.Add(ballsList[i]);
        //    }
        //    Debug.Log(balls.Count + "ballsCount");
        //}

        public void RemoveFromListAndDeactivate(List<Transform> balls)
        {
            foreach (var item in balls)
            {
                item.gameObject.SetActive(false);
            }
            balls.Clear();
        }
    }
}

