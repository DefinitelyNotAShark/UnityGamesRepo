using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int Lives;
    public static int Level;
    public static int Score;

    public Text LivesText, LevelText, ScoreText;

    Texture2D paddle;
    Vector2 scoreLoc, livesLoc, levelLoc;

    private static void SetupNewGame()
    {
        Lives = 3;
        Level = 3;
        Score = 0;
    }

    void Awake()
    {
        SetupNewGame();
    }

    // Use this for initialization
    void Start()
    {
        LivesText.text = "Lives: " + Lives.ToString();
        LevelText.text = "Level: " + Level.ToString();
        ScoreText.text = "Score: " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + Lives.ToString();
        LevelText.text = "Level: " + Level.ToString();
        ScoreText.text = "Score: " + Score.ToString();
    }
}

