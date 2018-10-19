using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	
    public void OnStartClicked()
    {
        SceneManager.LoadScene("GameScene");
        PointManager.patienceValue = 100;
        GameData.points = 0;
    }

    public void OnHowToClicked()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void OnCreditsClicked()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnQuitClicked()
    {//works if in editor and on release
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void OnBackClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}
