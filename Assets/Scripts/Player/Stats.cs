using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float m_MovementSpeed = 0.18f;
    private float m_ChewSpeed = 1;
    private bool m_Invisible = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void IncreaseSpeedBoost()
    {
        m_MovementSpeed += 0.2f;
    }
    
    public void IncreaseChewSpeed()
    {
        m_ChewSpeed += 1;
    }

    public void SetInvisible()
    {
        m_Invisible = true;
        
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0.5f;
        spriteRenderer.color = spriteColor;
        
        StartCoroutine("BeVisibleAgain");
    }
    
    private IEnumerator BeVisibleAgain()
    {
        yield return new WaitForSeconds(5);
        
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 1f;
        spriteRenderer.color = spriteColor;
        
        m_Invisible = false;
    }
}
