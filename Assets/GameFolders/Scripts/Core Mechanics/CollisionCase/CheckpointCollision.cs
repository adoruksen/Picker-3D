using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Picker3D.CollisionCase
{
    public class CheckpointCollision:MonoBehaviour
    {
        [Header("Components")]
        [Header("Barrier")]
        [SerializeField] private Transform _leftBarrier;
        [SerializeField] private Transform _rightBarrier;
        [Header("Rising Platform")]
        [SerializeField] private Transform _risingPlatform;
        [Header("References")]
        private PropOpenerCollision _propOpenerCollision;
        private BallsCollision _ballCollision;



        private WaitForSeconds _shortWaitTime = new WaitForSeconds(1f);

        private void Awake()
        {
            _propOpenerCollision = new PropOpenerCollision();
            _ballCollision = new BallsCollision();
        }

        public IEnumerator CheckpointSequenceCo(Transform transform)
        {
            //_propOpenerCollision.PropCloser(transform.gameObject);
            LevelManager.gameState = GameState.CheckPoint;
            //_ballCollision.PushBallsOnPool();
            yield return _shortWaitTime;
            PlatformRiser();
            yield return _shortWaitTime;
            BarrierOpener();
            LevelManager.gameState = GameState.Normal;
        }

        private void BarrierOpener()
        {
            _leftBarrier.DORotate(new Vector3(0, 0, 60), 1f);
            _rightBarrier.DORotate(new Vector3(0, 0, -60), 1f);
        }

        private void PlatformRiser()
        {
            _risingPlatform.DOLocalMoveY(0, 1f);
        }
    }
}

