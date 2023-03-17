using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float offset;
    [SerializeField] float offsetSmoothing;
    [SerializeField] Animator animator;
    [SerializeField] CanvasGroup canvasVictory;
    bool paused = false;
    bool lerp = false;
    Vector3 playerPosition;

    public void SetPaused(bool b) => paused = b;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LerpPosition(new Vector3(0, 0, -10), 1.5f));
    }
    
    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            StartCoroutine(LerpPosition(new Vector3(0, 0, -10), 1.5f));
        }

        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(player.transform.position.x + offset, player.transform.position.y, -10);
        }
        else 
        {
            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + offset, -10);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.fixedDeltaTime);
    }
    
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        animator.Play("Death");
        StartCoroutine(Wait(1f));
    }

    IEnumerator Wait(float s)
    {
        yield return new WaitForSeconds(s);
        StartCoroutine(Fade(.5f, canvasVictory));
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
