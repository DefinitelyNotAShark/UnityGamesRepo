using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowThePlayer : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float cameraDistance;

    [SerializeField]
    private Text debugText;

    private Vector3 targetVector;

	// Update is called once per frame
	void Update ()
    {
        targetVector = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - cameraDistance);//set camera to follow player
        transform.position = targetVector;
        debugText.text ="Vector = " + targetVector.ToString();
    }
}
