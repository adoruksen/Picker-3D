using System.Collections;
using UnityEngine;
using DG.Tweening;
using Picker3D.Controllers;

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

        public bool canPass;



        private WaitForSeconds _shortWaitTime = new(1f);
        private WaitForSeconds _longWaitTime = new(3f);


        private void Awake()
        {
            _propOpenerCollision = new PropOpenerCollision();
            _ballCollision = new BallsCollision();
        }

        private void Update()
        {
            Debug.Log(LevelManager.gameState);
        }
        public IEnumerator CheckpointSequenceCo()
        {
            LevelManager.gameState = GameState.CheckPoint;
            _ballCollision.PushBallsOnPool(PickerCollisionController.instance.ballsMy);
            yield return _longWaitTime;
            PlatformRiser();
            yield return _shortWaitTime;
            BarrierOpener();
            LevelManager.gameState = GameState.Normal;
            _ballCollision.RemoveFromListAndDeactivate(PickerCollisionController.instance.ballsMy);
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

