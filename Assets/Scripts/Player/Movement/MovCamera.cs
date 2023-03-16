using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float offset;
    [SerializeField] float offsetSmoothing;
    bool paused = false;
    bool lerp = false;
    Vector3 playerPosition;

    public void SetPaused(bool b) => paused = b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            StartCoroutine(LerpPosition(new Vector3(0, 0, -10), 2f));
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

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);

            transform.position = Vector2.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
