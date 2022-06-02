using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Picker3D.Movements
{
    public class MoveRightLeft
    {
        private float _swipeMultiplier = 5f;
        
        public void MovementToSides(Transform transform, Camera camera)
        {
            if (LevelManager.gameState==GameState.Normal)
            {
                var position = Input.mousePosition;
                var distanceToScreen = camera.WorldToScreenPoint(transform.position).z;
                var mousePos = camera.ScreenToWorldPoint(new Vector3(position.x, position.y, distanceToScreen));
                mousePos.x = Mathf.Clamp(mousePos.x, -2.4f, 2.4f);
                var direction = _swipeMultiplier;
                direction = mousePos.x > transform.position.x ? direction : -direction;
                if (Mathf.Abs(mousePos.x - transform.position.x) > .1f)
                    transform.Translate(Time.deltaTime * direction, 0, 0);
            }
        }
    }
}

