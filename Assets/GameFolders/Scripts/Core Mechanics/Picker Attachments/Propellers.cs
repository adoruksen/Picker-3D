using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Picker3D.PickerAttachments
{
    public class Propellers : MonoBehaviour
    {
        [SerializeField] private GameObject leftProp;
        [SerializeField] private GameObject rightProp;

        private void OnEnable()
        {
            leftProp.transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
            rightProp.transform.DORotate(new Vector3(0, -360, 0),1, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }

        private void OnDisable()
        {
            leftProp.transform.rotation = Quaternion.identity;
            rightProp.transform.rotation = Quaternion.identity;
        }
    }
}

