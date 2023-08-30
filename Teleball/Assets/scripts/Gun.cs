using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject suriken;

    void Start()
    {
        StartCoroutine ("fire");
    }

    void Update()
    {
        
    }

    IEnumerator fire()
    {
        while (true) {
            Instantiate(suriken, transform.position, Quaternion.identity);
            yield return new WaitForSeconds (3f);
        }
    }

}
