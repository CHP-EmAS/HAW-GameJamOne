using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    Cable activeCable;
    Stats stats;
    bool interactable;
    [SerializeField] float bitePause = 0.25f;
    [SerializeField] Slider UI_Progressbar;
    [SerializeField] GameObject UI_InteractText;
    bool bite = true;

    public void SetActiveCable(Cable cable) => activeCable = cable;
    public void SetInteractable(bool b) => interactable = b;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        if (!interactable)
        {
            UI_Progressbar.gameObject.SetActive(false);
            UI_InteractText.SetActive(false);

            return;
        }

        UI_Progressbar.gameObject.SetActive(true);
        UI_InteractText.SetActive(true);

        UI_Progressbar.value = activeCable.GetBitePercentage();

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
