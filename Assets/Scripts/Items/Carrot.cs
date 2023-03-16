using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public CarrotType type;
    public Stats playerStats;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Einsammeln des GameObjects
            gameObject.SetActive(false);

            switch (type)
            {
                case CarrotType.SpeedBoost:
                    playerStats.IncreaseSpeedBoost();
                    break;
                case CarrotType.ChewBoost:
                    playerStats.IncreaseChewSpeed();
                    break;
                case CarrotType.Invisibility:
                    playerStats.SetInvisible();
                    break;
            }
        }
    }
}

public enum CarrotType
{
    SpeedBoost,
    ChewBoost,
    Invisibility
}