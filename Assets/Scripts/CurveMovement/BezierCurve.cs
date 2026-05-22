using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BezierCurve : MonoBehaviour
{
    public List<Vector3> controlPoints = new List<Vector3>();

    private void OnDrawGizmos()
    {
        if (controlPoints.Count < 4) return;

        for (int j = 0; j < controlPoints.Count - 3; j += 3)
        {
            Vector3 previousPoint = controlPoints[j];
            for (float t = 0; t <= 1; t += 0.05f)
            {
                Vector3 point = Mathf.Pow(1 - t, 3) * controlPoints[j] +
                                3 * Mathf.Pow(1 - t, 2) * t * controlPoints[j + 1] +
                                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[j + 2] +
                                Mathf.Pow(t, 3) * controlPoints[j + 3];
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
