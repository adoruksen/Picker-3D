using System.Collections;
using UnityEngine;

namespace Picker3D.Movements
{
    public class MoveForward 
    {
        private float _velocity = 10f;

        public void MoveForwardAction(Transform transform)
        {
            if (LevelManager.gameState == GameState.Normal)
            {
                var pos = transform.position;
                pos.z += _velocity * Time.deltaTime;
                transform.position = pos;
            }
        }
    }
}

