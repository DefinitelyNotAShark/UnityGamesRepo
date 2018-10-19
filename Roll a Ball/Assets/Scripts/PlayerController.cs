using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	public Text loseText;
	public Text restartText;

	private Rigidbody rb;
	private int count;  

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		loseText.text = "";
		restartText.text = "";
	}

	void FixedUpdate ()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);

		{
			if (Input.GetKeyDown ("space") && GetComponent<Rigidbody> ().transform.position.y <= 0.6250001f) {
				Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);

				GetComponent<Rigidbody> ().AddForce (jump);
		
			}
		}

	}
			void OnTriggerEnter (Collider other)
			{

		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	
void Update ()
{
			{
				if (transform.position.y <= -10.0f)
				{
				loseText.text = ("Game Over");
				restartText.text = ("(Press r to Restart)");
				}
			}	

		}
		

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
	}