using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovTrigger : MonoBehaviour
{
    MovController controller;
    PlayerInteraction playerInteraction;
    [SerializeField] int index;

    private void Start()
    {
        controller = gameObject.transform.GetComponentInParent<MovController>();
        playerInteraction = gameObject.GetComponentInParent<PlayerInteraction>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp") return;

        if(collision.gameObject.tag == "Interactable")
        {
            playerInteraction.SetActiveCable(collision.gameObject.GetComponent<Cable>());
            playerInteraction.SetInteractable(true);
        }

        controller.SetCollisionDetection(index, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp") return;

        if (collision.gameObject.tag == "Interactable")
        {
            playerInteraction.SetActiveCable(null);
            playerInteraction.SetInteractable(false);
        }

        controller.SetCollisionDetection(index, false);
    }



}
