using System.Collections;
using UnityEngine;

public class SplineFollow : MonoBehaviour
{
    public CatmullRomSpline spline;
    public float speedMod = 0.5f;
    private float tParam;
    private bool coroutineAllowed;
    private float initialY;

    void Start()
    {
        tParam = 0f;
        coroutineAllowed = true;
        initialY = transform.position.y;
    }

    void Update()
    {
        if (coroutineAllowed && spline.controlPoints.Count >= 2)
        {
            StartCoroutine(GoByTheRoute());
        }
    }

    private IEnumerator GoByTheRoute()
    {
        coroutineAllowed = false;
        for (int i = 0; i < spline.controlPoints.Count - 1; i++)
        {
            Vector3 p0 = i == 0 ? spline.controlPoints[i] : spline.controlPoints[i - 1];
            Vector3 p1 = spline.controlPoints[i];
            Vector3 p2 = spline.controlPoints[i + 1];
            Vector3 p3 = i == spline.controlPoints.Count - 2 ? spline.controlPoints[i + 1] : spline.controlPoints[i + 2];

            while (tParam < 1)
            {
                tParam += Time.deltaTime * speedMod;

                Vector3 position = 0.5f * ((2 * p1) +
                                           (-p0 + p2) * tParam +
                                           (2 * p0 - 5 * p1 + 4 * p2 - p3) * tParam * tParam +
                                           (-p0 + 3 * p1 - 3 * p2 + p3) * tParam * tParam * tParam);

                position.y = initialY;

                transform.position = position;

                yield return new WaitForEndOfFrame();
            }

            tParam = 0;
        }

        coroutineAllowed = true;
    }
}
