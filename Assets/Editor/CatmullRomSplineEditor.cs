using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CatmullRomSpline))]
public class CatmullRomSplineEditor : Editor
{
    private void OnSceneGUI()
    {
        CatmullRomSpline spline = (CatmullRomSpline)target;

        // Permitir manipulação dos pontos de controle
        for (int i = 0; i < spline.controlPoints.Count; i++)
        {
            EditorGUI.BeginChangeCheck();
            Vector3 newPoint = Handles.PositionHandle(spline.controlPoints[i], Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(spline, "Move Control Point");
                spline.controlPoints[i] = newPoint;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CatmullRomSpline spline = (CatmullRomSpline)target;

        if (GUILayout.Button("Add Control Point"))
        {
            spline.controlPoints.Add(spline.transform.position);
        }

        if (GUILayout.Button("Clear Control Points"))
        {
            spline.controlPoints.Clear();
        }
    }
}
