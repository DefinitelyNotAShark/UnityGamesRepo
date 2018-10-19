using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    private ParticleSystem particles;
    private Renderer renderer;
    private bool particlesHaveBeenPlayed = false;

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<Renderer>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == this.gameObject.tag)
        {
            if (!particlesHaveBeenPlayed)
            {
                particles.Play();
                particlesHaveBeenPlayed = true;
                renderer.enabled = false;
                StartCoroutine(CheckIfParticlesHaveGone());
            }
        }
    }

    IEnumerator CheckIfParticlesHaveGone()
    {
        while (particles.IsAlive(true))
        {
            yield return new WaitForSeconds(.1f);
        }
        Destroy(this.gameObject);        
    }
}
