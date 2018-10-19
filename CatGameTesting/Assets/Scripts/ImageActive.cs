using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This goes on the image script and is how i'm gonna turn on and off image visibility
public class ImageActive : MonoBehaviour
{
    private Color nowColor;
    private Color invisible;

	void Start ()
    {
        nowColor = this.gameObject.GetComponent<Image>().color;
        invisible = new Color(0, 0, 0, 0);
        this.gameObject.GetComponent<Image>().color = invisible;
    }

    public void TurnImageOn()
    {
        this.gameObject.GetComponent<Image>().color = nowColor;
    }

    public void TurnImageOff()
    {
        this.gameObject.GetComponent<Image>().color = invisible;
    }
}
