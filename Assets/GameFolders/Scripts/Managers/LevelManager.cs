using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static GameState gameState;
    [SerializeField] private SetLevel _levelAsset;

    private void Awake()
    {
        instance = this;
    }
    public void CreateLevel(Transform spawnPos)
    {
        if (GameManager.Level <= _levelAsset.levels.Length)
        {
            Instantiate(_levelAsset.levels[GameManager.Level - 1],spawnPos.position,Quaternion.identity);
        }
        else
        {
            Instantiate(_levelAsset.levels[Random.Range(0, _levelAsset.levels.Length)], spawnPos.position, Quaternion.identity);
        }
    }

}
