using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float offset;
    [SerializeField] float offsetSmoothing;
    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(player.transform.position.x + offset, player.transform.position.y, -10);
        }
        else 
        {
            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + offset, -10);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
