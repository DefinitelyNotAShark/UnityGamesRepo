using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

    public void PlayGame()
    {
        ScoreManager.Level = 1;
        ScoreManager.Score = 0;
        ScoreManager.Lives = 3;
        SceneManager.LoadScene(0);
    }

}
