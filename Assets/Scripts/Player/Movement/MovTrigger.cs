using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovTrigger : MonoBehaviour
{
    MovController controller;
    [SerializeField] int index;

    private void Start()
    {
        controller = gameObject.transform.GetComponentInParent<MovController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.SetCollisionDetection(index, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        controller.SetCollisionDetection(index, false);
    }



}
