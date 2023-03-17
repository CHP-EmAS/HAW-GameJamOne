using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_Rotator : MonoBehaviour
{
    [SerializeField] MovController movController;
    [SerializeField] MovCamera movCamera;
    [SerializeField] CanvasGroup canvasGameOver;

    [SerializeField] AudioSource alarm;

    public AnimationCurve[] animationCurves;
    public int[] durations;
    public int currentAnimation = 0;
    
    private float currentTime = 0f;

    public int kiState = 0; //0 animation, 1 followPlayer, 2 killPlayer, default dead
    
    public Transform player;
    public Stats playerStats;
    
    private bool playerVisible;
    
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

    public void incrementCurrentAnimation()
    {
        if (currentAnimation < animationCurves.Length - 1)
        {
            currentAnimation++;
        }
        else
        {
            kiState = 5; // dead
            
            movController.SetPaused(true);
            movCamera.SetPaused(true);
        }
    }
    
    public void PlayerVisibilityChanged(bool visible)
    {
        playerVisible = visible;

        if (kiState == 0 && visible && !playerStats.IsInvisible())
        {
            kiState = 1;
            StartCoroutine("WaitToKill");
        }
    }

    private IEnumerator WaitToKill()
    {
        alarm.Play();

        yield return new WaitForSeconds(1.5f);
        if (playerVisible)
        {
            kiState = 2;

            movController.SetPaused(true);

            player.GetComponent<Animator>().Play("Death");

            StartCoroutine(WaitForGameOver(1.5f));

            alarm.Stop();
        }
        else
        {
            alarm.Stop();
            kiState = 0;
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

    IEnumerator WaitForGameOver(float s)
    {
        yield return new WaitForSeconds(s);

        StartCoroutine(Fade(.5f, canvasGameOver));
    }

    IEnumerator Fade(float duration, CanvasGroup c)
    {
        float time = 0;
        float a = 0;
        float b = 1;

        while (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);

            c.alpha = Mathf.Lerp(a, b, t);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
