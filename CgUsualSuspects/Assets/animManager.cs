using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private ParticleSystem davidParticles;
    [SerializeField]
    private ParticleSystem manuParticles;
    [SerializeField]
    private ParticleSystem pipeParticles;

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
