using UnityEngine;
using Picker3D.CollisionCase;
using Picker3D.UI;
using System.Collections.Generic;

namespace Picker3D.Controllers
{
    [RequireComponent(typeof(Collider))]
    public class PickerCollisionController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] GameObject props;
        [SerializeField] List<Transform> balls;

        #region References
        private BallsCollision _ballCollision;
        private CheckpointCollision _checkPointCollision;
        private PropOpenerCollision _propOpenerCollision;
        #endregion

        private void Awake()
        {
            SetterFunction();
        }

        /// <summary>
        /// Sets the references and variables
        /// </summary>
        private void SetterFunction()
        {
            _propOpenerCollision = new PropOpenerCollision();
            _ballCollision = new BallsCollision();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Interactable>(out var interactable))
            {
                if (interactable.type == InteractableType.CheckPoint)
                {
                    _checkPointCollision = other.GetComponent<CheckpointCollision>();
                    _propOpenerCollision.PropCloser(props);
                    //_ballCollision.PushBallsOnPool(balls);
                    StartCoroutine(_checkPointCollision.CheckpointSequenceCo(transform));
                    RemoveFromListAndDeactivate();
                }
                if (interactable.type == InteractableType.PropOpener)
                {
                    other.gameObject.SetActive(false);
                    _propOpenerCollision.PropOpener(props);
                }
                if (interactable.type == InteractableType.Ball)
                {
                    balls.Add(other.transform);
                    //_ballCollision.AddToList(other.transform);
                }
                if (interactable.type == InteractableType.SpawnStarter)
                {
                    LevelManager.gameState=GameState.Finish;
                    GameManager.Level++;
                    DuringGamePanelController.instance.LevelTextSetter();
                    LevelSetter levelSetter = other.transform.parent.GetComponent<LevelSetter>();
                    LevelManager.instance.CreateLevel(levelSetter._spawnPoint);
                    levelSetter.PlayerPositionSetter(transform.parent);
                }
            }
        }

        public void RemoveFromListAndDeactivate()
        {
            foreach (var item in balls)
            {
                item.gameObject.SetActive(false);
            }
            balls.Clear();
        }
    }
}

