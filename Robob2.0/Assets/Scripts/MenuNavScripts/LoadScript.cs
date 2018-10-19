using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{

    [SerializeField]
    private string sceneToLoad;//type the name of the scene to load


    AsyncOperation asyncOperation;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartSceneLoading());
    }

    IEnumerator StartSceneLoading()
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncOperation.isDone)//when it's not done,
        {
            yield return null;
        }
        yield break;
    }

}

