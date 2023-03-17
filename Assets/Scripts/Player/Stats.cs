using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] TMP_Text speedOut;
    [SerializeField] TMP_Text chewOut;

    private float m_MovementSpeed = 0.18f;
    private float m_ChewSpeed = 1;
    private bool m_Invisible = false;

    float speedInc = 0.009f;
    private SpriteRenderer spriteRenderer;

    int speedMulti = 0;
    int chewMulti = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    public void IncreaseSpeedBoost()
    {
        if(m_MovementSpeed > speedInc)
        {   
            m_MovementSpeed -= speedInc;
            speedMulti++;
            speedOut.text = speedMulti.ToString();
        }
    }
    
    public void IncreaseChewSpeed()
    {
        m_ChewSpeed += 1;
        chewMulti++;
        chewOut.text = chewMulti.ToString();
    }

    public void SetInvisible()
    {
        m_Invisible = true;
        
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0.5f;
        spriteRenderer.color = spriteColor;
        
        StartCoroutine("BeVisibleAgain");
    }

    public float GetChewSpeed() => m_ChewSpeed;
    public float GetMoveSpeed() => m_MovementSpeed;
    
    public bool IsInvisible()
    {
        return m_Invisible;
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
