using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToNavigation : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;

	public void ClickPlay()
    {
        click.Play();
        SceneManager.LoadScene(1);
    }

    public void ClickBack()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }
}
