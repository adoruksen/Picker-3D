using UnityEngine;
using Picker3D.CollisionCase;
using Picker3D.UI;
using System.Collections.Generic;

namespace Picker3D.Controllers
{
    [RequireComponent(typeof(Collider))]
    public class PickerCollisionController : MonoBehaviour
    {
        public static PickerCollisionController instance;
        [Header("Components")]
        [SerializeField] GameObject props;
        public List<Transform> ballsMy;

        #region References
        private BallsCollision _ballCollision;
        private CheckpointCollision _checkPointCollision;
        private PropOpenerCollision _propOpenerCollision;
        #endregion

        private void Awake()
        {
            instance = this;
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

        public int BallListCount => ballsMy.Count;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Interactable>(out var interactable))
            {
                if (interactable.type == InteractableType.CheckPoint)
                {
                    _checkPointCollision = other.GetComponent<CheckpointCollision>();
                    _propOpenerCollision.PropCloser(props);
                    StartCoroutine(_checkPointCollision.CheckpointSequenceCo());
                }
                if (interactable.type == InteractableType.PropOpener)
                {
                    other.gameObject.SetActive(false);
                    _propOpenerCollision.PropOpener(props);
                }
                if (interactable.type == InteractableType.Ball)
                {
                    Debug.Log("girdi");
                    //_ballCollision.balls.Add(other.transform);
                    ballsMy.Add(other.transform);
                    Debug.Log(ballsMy.Count);
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
    }
}

