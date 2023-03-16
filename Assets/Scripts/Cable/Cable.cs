using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private float bitePercentage = 0;
    public bool isDestroyed = false;
    public bool bitingInProgress = false;

    //public ParticleSystem sparkParticleSystem;
    public FOV_Rotator fovRotator;

    public Prop attachedProp;
    
    private void Update()
    {
        if (bitingInProgress)
        {
            //sparkParticleSystem.gameObject.SetActive(true);
        }
        else
        {
            //sparkParticleSystem.gameObject.SetActive(false);
        }
    }

    public void Bite(float bitePercent)
    {
        bitePercentage += bitePercent;

        if (bitePercentage >= 100f && !isDestroyed)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        isDestroyed = true;
        fovRotator.incrementCurrentAnimation();

        attachedProp.LetsGrennItUp();
        
        GameObject.Destroy(gameObject);
    }
}
