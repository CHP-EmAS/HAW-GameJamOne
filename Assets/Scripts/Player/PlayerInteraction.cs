using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Cable activeCable;
    Stats stats;
    bool interactable;
    [SerializeField] float bitePause = 0.25f;
    bool bite = true;

    public void SetActiveCable(Cable cable) => activeCable = cable;
    public void SetInteractable(bool b) => interactable = b;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        if (!interactable) return;

        

        if (Input.GetKey(KeyCode.E))
        {
            if (bite)
            {
                activeCable.Bite(stats.GetChewSpeed());
                bite = false;
                StartCoroutine(Wait(bitePause));
            }
        }
    }

    IEnumerator Wait(float s)
    {
        yield return new WaitForSeconds(s);
        bite = true;

    }
}
