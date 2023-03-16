using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MovController : MonoBehaviour
{
    bool gotInput = false;
    [SerializeField] float waitSec = 1;
    [SerializeField] float moveIncrement = 1;

    //0 = +x, 1 = -x, 2 = +y, 3 = -y
    bool[] collisionDetection = new bool[4];
    Vector2 velocity = Vector2.zero;
    float movementX;
    float movementY;

    public void SetCollisionDetection(int i, bool b) => collisionDetection[i] = b;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gotInput) return; 

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            gotInput = true;
            movementX = Input.GetAxisRaw("Horizontal");

            StartCoroutine(WaitForSeconds(waitSec));
            StartCoroutine(LerpPosition(new Vector2(transform.position.x + movementX*moveIncrement, transform.position.y), waitSec));

        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            gotInput = true;
            movementY = Input.GetAxisRaw("Vertical");

            StartCoroutine(WaitForSeconds(waitSec));
            StartCoroutine(LerpPosition(new Vector2(transform.position.x, transform.position.y + movementY*moveIncrement), waitSec));
        }


    }

    IEnumerator WaitForSeconds(float s)
    {
        yield return new WaitForSeconds (s);
        gotInput = false;
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
