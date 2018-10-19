using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

    }
	
	// Update is called once per frame
	void Update () {
        if (count >= 12)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Scene1");
            }
        }
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(moveHorizontal, 0.0f ,moveVertical);

        rb.AddForce(Movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 120)
        {
            winText.text = "You Win!!!\n(press SPACEBAR to restart)";
        }
    }
}
