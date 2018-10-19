using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBasket : MonoBehaviour {

    private float input;
    private int basketIndex = 0;
    private GameObject thisBasket;
    private Transform thisTransform;


    bool coolDownHappened = true;

    [SerializeField]//put the list of baskets in here.
    List<GameObject> basketPrefabs = new List<GameObject>();

    public enum BasketState  { apple, orange, banana }
    public BasketState BState;

    private void Start()
    {
        thisBasket = basketPrefabs[basketIndex];
        thisTransform = thisBasket.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (coolDownHappened == true)
            CheckInput();

        SetState();
    }

    private void SetState()
    {
        if (basketIndex == 0)
            BState = BasketState.apple;
        if (basketIndex == 1)
            BState = BasketState.orange;
        if (basketIndex == 2)
            BState = BasketState.banana;
    }

    private void CheckInput()
    {
        input = (Input.GetAxis("switchBasket"));
        if(input != 0)
        {
            ChangeBasketIndex();
            ScrollThroughBasket();
        }
    }

    void ChangeBasketIndex()
    {
        basketIndex += (int)input;
        if(basketIndex > 2)
        {
            basketIndex = 0;
        }
        if(basketIndex < 0)
        {
            basketIndex = 2;
        }
    }

    void ScrollThroughBasket()
    {
        thisTransform.position = thisBasket.transform.position;
        thisBasket.SetActive(false);
        basketPrefabs[basketIndex].gameObject.SetActive(true);
        thisBasket = basketPrefabs[basketIndex];
        thisBasket.transform.position = thisTransform.position;

        StartCoroutine(coolDownTimer());
    }

    IEnumerator coolDownTimer()
    {
        coolDownHappened = false;
        yield return new WaitForSeconds(.3f);
        coolDownHappened = true;
    }
}
