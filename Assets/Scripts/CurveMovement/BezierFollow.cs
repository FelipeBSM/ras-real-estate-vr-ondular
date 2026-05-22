using System.Collections;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    public BezierCurve bezierCurve; // Referência ao script BezierCurve
    public float speedMod = 0.5f; // Modificador de velocidade
    private float tParam;
    private bool coroutineAllowed;
    private float initialY; // Armazenar o valor inicial de Y

    void Start()
    {
        tParam = 0f;
        coroutineAllowed = true;
        initialY = transform.position.y; // Armazenar o valor inicial de Y na posição do objeto
    }

    void Update()
    {
        if (coroutineAllowed && bezierCurve.controlPoints.Count >= 4)
        {
            StartCoroutine(GoByTheRoute());
        }
    }

    private IEnumerator GoByTheRoute()
    {
        coroutineAllowed = false;
        int numSegments = (bezierCurve.controlPoints.Count - 1) / 3;

        for (int j = 0; j < numSegments; j++)
        {
            while (tParam < 1)
            {
                tParam += Time.deltaTime * speedMod;

                Vector3 p0 = bezierCurve.controlPoints[j * 3];
                Vector3 p1 = bezierCurve.controlPoints[j * 3 + 1];
                Vector3 p2 = bezierCurve.controlPoints[j * 3 + 2];
                Vector3 p3 = bezierCurve.controlPoints[j * 3 + 3];

                Vector3 position = Mathf.Pow(1 - tParam, 3) * p0 + 
                                   3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                                   3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + 
                                   Mathf.Pow(tParam, 3) * p3;

                position.y = initialY; // Manter o valor inicial de Y

                transform.position = position;

                yield return new WaitForEndOfFrame();
            }

            tParam = 0;
        }

        coroutineAllowed = true;
    }
}
