using UnityEngine;
using TMPro;


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
            Debug.Log(balls);
            requiredBallText.text = $"{balls}/{requiredBallBase[1]}";
        }
    }
}
