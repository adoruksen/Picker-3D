using UnityEngine;

namespace Picker3D.Controllers
{
    public class InputController
    {
        public bool MouseHold => Input.GetMouseButton(0);
        public bool MouseUp => Input.GetMouseButtonUp(0);
    }
}

