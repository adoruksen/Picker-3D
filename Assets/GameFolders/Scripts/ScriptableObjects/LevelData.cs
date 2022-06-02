using UnityEngine;

[CreateAssetMenu(fileName ="LevelData",menuName ="Level Data SO/Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int[] requiredBallCount;
    public int[] RequiredBallCount => requiredBallCount;


}
