using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonClick;

    private Color clickColor = new Color32(100, 100, 100, 255);

    private Image image;

    private void Awake()
    {
        image = this.gameObject.GetComponentInChildren<Image>();
        image.gameObject.SetActive(false);
    }

    public void ShowGear()
    {
        buttonClick.Play();
        image.gameObject.SetActive(true);
    }

    public void HideGear()
    {
        image.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Loading");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    { 
        SceneManager.LoadScene("Credits");
    }

    public void OnClick()
    {
        buttonClick.Play();
        this.gameObject.GetComponent<Text>().color = clickColor;
    }
}
