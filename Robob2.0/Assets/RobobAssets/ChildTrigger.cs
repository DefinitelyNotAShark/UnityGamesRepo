using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour {

    private string tagName;
    GameObject thisObject;

    private void OnTriggerEnter(Collider other)
    {
        tagName = this.tag.ToString();
        thisObject = this.gameObject;

        if (other.CompareTag("robot"))
            gameObject.GetComponentInParent<CollectObject>().PullTrigger(other, this.tagName, thisObject);
    }
}
