using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int level;
    public static int Level
    {
        get => !PlayerPrefs.HasKey("level") ? 1 : PlayerPrefs.GetInt("level");
        set
        {
            level = value;
            PlayerPrefs.SetInt("level", level);
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
    }
}
