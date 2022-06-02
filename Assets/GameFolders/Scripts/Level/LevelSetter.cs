using UnityEngine;
using TMPro;
using DG.Tweening;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _requiredBallText;
    public Transform _spawnPoint;
    [SerializeField] private LevelData _levelData;

    private void OnEnable()
    {
        RequiredBallTextSetter();
    }
    private void RequiredBallTextSetter()
    {
        for (int i = 0; i < _requiredBallText.Length; i++)
        {
            _requiredBallText[i].text = $"0/{_levelData.RequiredBallCount[i]}";
        }
    }

    /// <summary>
    /// spawnStarter'a geldiðinde Spawnpointe kadar Tween hareketi
    /// </summary>
    /// <param name="picker"></param>
    public void PlayerPositionSetter(Transform picker)
    {
        picker.transform.DOMove(_spawnPoint.position, 2.5f).OnComplete(()=>LevelManager.gameState=GameState.Normal);
    }

    
}
