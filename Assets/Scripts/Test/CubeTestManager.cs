using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTestManager : MonoBehaviour
{   
    [Header("Test Cube to show when pose interaction has been made.")]
    public GameObject testCube;

    public void DetectedBunny()
    {
        testCube.SetActive(true);
    }
    public void NoDetectedBunny()
    {
        testCube.SetActive(false);
        //StartCoroutine(DesativateAim());
    }
    IEnumerator DesativateAim()
    {
        yield return new WaitForSeconds(5);
        testCube.SetActive(false);
    }
}
