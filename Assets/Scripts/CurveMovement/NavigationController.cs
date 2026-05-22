using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public CatmullRomSpline spline;
    public float speedMod = 0.5f;
    public List<int> stopPoints = new List<int>(); // Índices dos pontos de parada
    private int currentStopIndex = 0;
    private float tParam;
    private bool coroutineAllowed;
    private float initialY;
    private int currentSegment; // Segmento atual da spline

    void Start()
    {
        tParam = 0f;
        coroutineAllowed = true;
        initialY = transform.position.y;
        if (stopPoints.Count > 0)
        {
            StartCoroutine(NavigateToNextStop());
        }
    }

    private IEnumerator NavigateToNextStop()
    {
        coroutineAllowed = false;
        int targetIndex = stopPoints[currentStopIndex];

        for (int i = currentSegment; i < targetIndex; i++)
        {
            currentSegment = i; // Atualiza o segmento atual
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

        currentStopIndex = (currentStopIndex + 1) % stopPoints.Count;
        coroutineAllowed = true;
        // Não recomeçar automaticamente, esperar por interação do usuário
    }

    public void NavigateToSpecificPoint(int pointIndex)
    {
        if (pointIndex >= 0 && pointIndex < spline.controlPoints.Count)
        {
            StopAllCoroutines();
            currentSegment = pointIndex > 0 ? pointIndex - 1 : 0;
            tParam = 0;
            currentStopIndex = stopPoints.IndexOf(pointIndex);
            StartCoroutine(NavigateToNextStop());
        }
    }

    public void SetNextStop(int stopIndex)
    {
        if (stopIndex >= 0 && stopIndex < stopPoints.Count)
        {
            currentStopIndex = stopIndex;
            if (coroutineAllowed)
            {
                StartCoroutine(NavigateToNextStop());
            }
        }
    }
}
