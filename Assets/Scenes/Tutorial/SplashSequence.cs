using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    public static int SceneNumber;
    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToSplashTwo());
        } else if (SceneNumber == 1)
        {
            StartCoroutine(ToSplashThree());
        } else if (SceneNumber == 2)
        {
            StartCoroutine(ToSplashFour());
        } else if (SceneNumber == 3)
        {
            StartCoroutine(ToGame());
        }
        
    }

    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(7);
        SceneNumber = 1;
        SceneManager.LoadScene(2);
    }
    
    IEnumerator ToSplashThree()
    {
        yield return new WaitForSeconds(5);
        SceneNumber = 2;
        SceneManager.LoadScene(3);
    }
    
    IEnumerator ToSplashFour()
    {
        yield return new WaitForSeconds(7);
        SceneNumber = 3;
        SceneManager.LoadScene(4);
    }
    
    IEnumerator ToGame()
    {
        yield return new WaitForSeconds(5);
        SceneNumber = 0;
        SceneManager.LoadScene(5);
    }
    
}
