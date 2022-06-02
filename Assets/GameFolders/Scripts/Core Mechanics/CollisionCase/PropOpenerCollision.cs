using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Picker3D.CollisionCase
{
    public class PropOpenerCollision
    {
        public void PropOpener(GameObject propObjects)
        {
            propObjects.SetActive(true);
        }

        public void PropCloser(GameObject propObjects)
        {
            propObjects.SetActive(false);
        }
    }
}
