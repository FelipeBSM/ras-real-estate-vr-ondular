using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : Editor
{
    private void OnSceneGUI()
    {
        BezierCurve curve = (BezierCurve)target;

        // Permitir manipulação dos pontos de controle
        for (int i = 0; i < curve.controlPoints.Count; i++)
        {
            EditorGUI.BeginChangeCheck();
            Vector3 newPoint = Handles.PositionHandle(curve.controlPoints[i], Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(curve, "Move Control Point");
                curve.controlPoints[i] = newPoint;
            }
        }
    }
}
