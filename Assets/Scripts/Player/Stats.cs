using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float m_MovementSpeed = 0.18f;
    private float m_ChewSpeed = 1;
    private bool m_Invisible = false;

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
        StartCoroutine("BeVisibleAgain");
    }
    
    private IEnumerator BeVisibleAgain()
    {
        yield return new WaitForSeconds(5);
        m_Invisible = false;
    }
}
