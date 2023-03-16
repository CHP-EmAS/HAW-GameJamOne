using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_Rotator : MonoBehaviour
{
    public AnimationCurve[] animationCurves;
    public int[] durations;
    public int currentAnimation = 0;
    
    private float currentTime = 0f;

    public int kiState = 1; //0 animation, 1 followPlayer, 2 killPlayer, default dead
    public Transform player;
    
    void Start()
    {
        if (animationCurves.Length == 0)
        {
            Debug.LogError("Please assign at least one AnimationCurve to the array.");
        }
        else if (durations.Length < animationCurves.Length)
        {
            Debug.LogError("Please assign at least so many Durations as AnimationCurves.");
        }
    }

    void Update()
    {
        switch (kiState)
        {
            case 0:
                Search();
                break;
            case 1:
            case 2:
                FollowPlayer();
                break;
        }
        
        
    }

    private void Search()
    {
        if (animationCurves.Length > 0 && durations.Length >= animationCurves.Length)
        {
            float time = currentTime / durations[currentAnimation];

            float curveValue = animationCurves[currentAnimation].Evaluate(time);
            transform.rotation = Quaternion.Euler(0f, 0f, curveValue * 360);
            
            currentTime += Time.deltaTime;

            if (currentTime > durations[currentAnimation])
            {
                currentTime = 0f;
            }
        }
    }
    
    private void FollowPlayer()
    {
        Vector2 direction = ((Vector2) player.position - (Vector2) transform.position).normalized;
        transform.up = direction;
    }
}
