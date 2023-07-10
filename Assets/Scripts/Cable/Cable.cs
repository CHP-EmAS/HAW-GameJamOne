using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Cable : MonoBehaviour
{
    private float bitePercentage = 0;
    public bool isDestroyed = false;
    public bool bitingInProgress = false;
    [SerializeField] GameObject kiCable;

    //public ParticleSystem sparkParticleSystem;
	//hallo ich war hier am 10.07.2023
    public FOV_Rotator fovRotator;

    public Prop attachedProp;

    public float GetBitePercentage() => bitePercentage;

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
        kiCable.SetActive(false);
        
        GameObject.Destroy(gameObject);
    }
}
