using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CatmullRomSpline : MonoBehaviour
{
    public List<Vector3> controlPoints = new List<Vector3>();

    private void OnDrawGizmos()
    {
        if (controlPoints.Count < 2) return;

        Vector3 previousPoint = controlPoints[0];
        for (int i = 0; i < controlPoints.Count - 1; i++)
        {
            Vector3 p0 = i == 0 ? controlPoints[i] : controlPoints[i - 1];
            Vector3 p1 = controlPoints[i];
            Vector3 p2 = controlPoints[i + 1];
            Vector3 p3 = i == controlPoints.Count - 2 ? controlPoints[i + 1] : controlPoints[i + 2];

            for (float t = 0; t <= 1; t += 0.05f)
            {
                Vector3 point = 0.5f * ((2 * p1) +
                                        (-p0 + p2) * t +
                                        (2 * p0 - 5 * p1 + 4 * p2 - p3) * t * t +
                                        (-p0 + 3 * p1 - 3 * p2 + p3) * t * t * t);
                Gizmos.DrawSphere(point, 0.1f);
                Gizmos.DrawLine(previousPoint, point);
                previousPoint = point;
            }
        }

        // Desenhar esferas nos pontos de controle
        Gizmos.color = Color.red;
        foreach (var point in controlPoints)
        {
            Gizmos.DrawSphere(point, 0.2f);
        }
    }
}
