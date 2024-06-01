using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class animManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private ParticleSystem davidParticles;
    [SerializeField]
    private ParticleSystem manuParticles;
    [SerializeField]
    private PlayableDirector pipeParticles;
    [SerializeField]
    private GameObject pipeParticlesSystem;

    private bool canPause;
    private bool canPlay;
    private bool canResume;

    private int animation;

    public void SelectAnimation(int selectedAnim)
    {
        animation = selectedAnim;
        canPause = true;
        canPlay = true;
    }

    public void Play()
    {
        if (canPlay)
        {
            animator.SetTrigger(animation.ToString());
            Debug.Log(animation);
            canPause = true;
            canResume = false;

            if (animation == 1)
            {
                davidParticles.Play();
                manuParticles.Stop();
                manuParticles.Clear();
                
                pipeParticles.Stop();
                pipeParticlesSystem.SetActive(false);
            }
            else if (animation == 2)
            {
                pipeParticles.Stop();
                pipeParticlesSystem.SetActive(false);
                davidParticles.Clear();
                manuParticles.Play();
            }
            else if (animation == 3)
            {
                pipeParticlesSystem.gameObject.SetActive(true);
                manuParticles.Stop();
                manuParticles.Clear();
                davidParticles.Clear();
                pipeParticles.Play();
            }
        }
    }

    public void Pause()
    {
        if (canPause)
        {
            animator.speed = 0;
            canResume = true;
            canPause = false;

            if (animation == 1)
            {
                davidParticles.Pause();
            }
            else if (animation == 2)
            {
                manuParticles.Pause();
            }
            else if (animation == 3)
            {
                pipeParticles.Pause();
            }

        }
    }

    public void Resume()
    {
        if (canResume)
        {
            animator.speed = 1;
            canPause = true;
            canResume = false;

            if (animation == 1)
            {
                davidParticles.Play();
            }
            else if (animation == 2)
            {
                manuParticles.Play();
            }
            else if (animation == 3)
            {
                pipeParticles.Play();
            }
        }
    }
}
