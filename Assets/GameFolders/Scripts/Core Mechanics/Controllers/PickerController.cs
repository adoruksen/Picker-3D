using UnityEngine;
using Picker3D.Movements;


namespace Picker3D.Controllers
{
    public class PickerController : MonoBehaviour
    {
        [Header("Components")]
        private Camera _camera;

        #region References
        private InputController _inputController;
        private MoveForward _moveForward;
        private MoveRightLeft _moveRightLeft;
        #endregion

        private void Awake()
        {
            _inputController = new InputController();
            _moveForward = new MoveForward();
            _moveRightLeft = new MoveRightLeft();
            _camera = Camera.main;
        }

        void Update()
        {
            _moveForward.MoveForwardAction(transform);

            if (_inputController.MouseHold)
            {
                _moveRightLeft.MovementToSides(transform, _camera);
            }
        }
    }
}
