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
    [SerializeField] Animator animator;

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

        //SetAnimationVar();
        Movement();

    }
    
    void Movement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        if (collisionDetection[0] && movementX == 1)
        {
            movementX = 0;
            return;
        }
        if (collisionDetection[1] && movementX == -1)
        {
            movementX = 0;
            return;
        }

        if (collisionDetection[2] && movementY == 1)
        {
            movementY = 0;
            return;
        }
        if (collisionDetection[3] && movementY == -1)
        {
            movementY = 0;
            return;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            gotInput = true;
            animator.SetFloat("X", movementX);

            if (movementX == 1) animator.Play("Right");
            else if (movementX == -1) animator.Play("Left");

            StartCoroutine(WaitForSeconds(waitSec));
            StartCoroutine(LerpPosition(new Vector2(transform.position.x + movementX * moveIncrement, transform.position.y), waitSec));
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            gotInput = true;
            animator.SetFloat("Y", movementY);

            if (movementY == 1) animator.Play("Up");
            else if (movementY == -1) animator.Play("Down");

            StartCoroutine(WaitForSeconds(waitSec));
            StartCoroutine(LerpPosition(new Vector2(transform.position.x, transform.position.y + movementY * moveIncrement), waitSec));
        }

        else animator.Play("Idle");
    }

    void SetAnimationVar()
    {
        if (movementX == 1) animator.Play("Right");
        else if (movementX == -1) animator.Play("Left");
        else if (movementY == 1) animator.Play("Up");
        else if (movementY == -1) animator.Play("Down");
        //else animator.Play("Idle");
    }

    IEnumerator WaitForSeconds(float s)
    {
        yield return new WaitForSeconds (s);
        gotInput = false;
        movementX = 0;
        movementY = 0;
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
