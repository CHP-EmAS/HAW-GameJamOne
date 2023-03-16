using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public GameObject destroyed;
    public GameObject greened;
    
    void Start()
    {
        destroyed.SetActive(true);
        greened.SetActive(false);
    }
    
    public void LetsGrennItUp()
    {
        destroyed.SetActive(false);
        greened.SetActive(true);
    }
}
