using UnityEngine;
using TMPro;
using Picker3D.Controllers;


namespace Picker3D.CollisionCase
{
    public class FloorCollision : MonoBehaviour
    {
        private TMP_Text requiredBallText;
        private int balls = 0;
        private string[] requiredBallBase => transform.GetChild(0).GetComponent<TMP_Text>().text.Split("/");
        private void Awake()
        {
            requiredBallText = transform.GetChild(0).GetComponent<TMP_Text>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            balls++;
            collision.transform.GetComponent<Collider>().enabled = false;

            requiredBallText.text = $"{balls}/{requiredBallBase[1]}";
            if (PickerCollisionController.instance.BallListCount >= int.Parse(requiredBallBase[1]))
            {
                Debug.Log("günaydýn gittim ben");
            }
            else
            {
                Debug.Log("failed");
            }
        }
    }
}
