using UnityEngine;

[CreateAssetMenu(fileName = "LevelAsset", menuName = "ScriptableObjects/Level/LevelAsset", order = 2)]
public class SetLevel : ScriptableObject
{
    public GameObject[] levels;
}
