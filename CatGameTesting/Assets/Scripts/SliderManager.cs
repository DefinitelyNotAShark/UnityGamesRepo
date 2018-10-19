using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is how we find the slider for now. Put it on the slider plz
public class SliderManager : MonoBehaviour
{
    [SerializeField]
    private Color normalColor;

    [SerializeField]
    private Color doneColor;

    public void TurnDoneColor()
    {
        GetComponentInChildren<Image>().color = doneColor;
    }

    public void TurnNormalColor()
    {
        GetComponentInChildren<Image>().color = normalColor;
    }
}
