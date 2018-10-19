using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOverlordColor : MonoBehaviour {

    [SerializeField]
    public Color normalColor;

    [SerializeField]
    public Color correctColor;

    [SerializeField]
    public Color wrongColor;

    [HideInInspector]
    public MeshRenderer[] renderers;

    public ParticleSystem particleSystem;
    public ParticleSystem secondParticleSystem;

    [SerializeField]
    private AudioSource spark1;
    [SerializeField]
    private AudioSource spark2;
    [SerializeField]
    private AudioSource correct;
    [SerializeField]
    private AudioSource wrong;

	// Use this for initialization
	void Awake()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = normalColor;
        }
    }

    private void Start()
    {
        StartCoroutine(Sparks());
    }

    private IEnumerator Sparks()
    {
        for (; ; )
        {
            particleSystem.Play();
            spark1.Play();
            yield return new WaitForSeconds(.5f);
            secondParticleSystem.Play();
            spark2.Play();
            yield return new WaitForSeconds(.5f);
            particleSystem.Stop();
            secondParticleSystem.Stop();
            yield return new WaitForSeconds(8);
        }
    }

    public IEnumerator CorrectAnswer()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = correctColor;
        }
        correct.Play();
        yield return new WaitForSeconds(1);
        GoBackToNormal();

    }

    public IEnumerator WrongAnswer()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = wrongColor;
        }
        wrong.Play();
        yield return new WaitForSeconds(1);
        GoBackToNormal();
    }

    public void GoBackToNormal()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = normalColor;
        }
    }
}
