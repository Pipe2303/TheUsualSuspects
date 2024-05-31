using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRevenge : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> particles;
    [SerializeField]
    private Material postProcess;
    [SerializeField]
    private float maxValue;
    [SerializeField]
    private float speedUp;
    [SerializeField]
    private float speedDown;
    [SerializeField]
    private float wait;

    private bool canAnim;

    private Animator knightAnim;

    private void Start()
    {
        canAnim = true;
    }

    private void Awake()
    {
        knightAnim = GetComponent<Animator>();
        //knightAnim.enabled = true;
    }

    public void StartParticles()
    {
        foreach (var particle in particles)
        {
            particle.Play();
        }
    }

    private void Update()
    {
        if (knightAnim.speed == 0)
        {
            canAnim = false;
        }
        else
        {
            canAnim = true;
        }
    }

    public void PostProcess()
    {
        StartCoroutine(PostRoutine());
    }

    private IEnumerator PostRoutine()
    {
        float newIntensity = 0;

        while (postProcess.GetFloat("_Intensity") < maxValue)
        {
            newIntensity = postProcess.GetFloat("_Intensity") + speedUp * Time.deltaTime;
            postProcess.SetFloat("_Intensity", newIntensity);
            yield return null;
        }

        while (wait > 0)
        {
            wait -= Time.deltaTime;
            yield return null;
        }

        while (postProcess.GetFloat("_Intensity") > 0)
        {
            newIntensity = postProcess.GetFloat("_Intensity") - speedUp * Time.deltaTime;
            postProcess.SetFloat("_Intensity", newIntensity);
            yield return null;
        }
    }

}
