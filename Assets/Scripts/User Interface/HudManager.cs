using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("UI SETTINGS")]
    [SerializeField] private float fixedYPosition;
    public Vector3 relativePosition;
    [SerializeField] private float rotationOffset;
    [SerializeField] private GameObject _canvasMain;
    

    [SerializeField]
    private NavigationController _navs;
    private PoseDetectionActor detective;

    private void Start()
    {
        detective = GetComponent<PoseDetectionActor>();
        PositionCanvas();
    }
    public void ButtonSetIndex(int _index)
    {
        _navs.NavigateToSpecificPoint(_index);
    }
    public void PositionCanvas()
    {
        Vector3 newPosition = detective.camera.transform.position + detective.camera.transform.TransformDirection(new Vector3(relativePosition.x, 0, relativePosition.z));
        newPosition.y = fixedYPosition; // Sobrescreve a posição Y

        //Atualiza a posição do CurvedUnityCanvas diretamente
        _canvasMain.transform.position = newPosition;

        //Ajusta a rotação para olhar para a câmera, opcionalmente mantendo o eixo Y fixo na rotação também
        Vector3 lookDirection = new Vector3(detective.camera.transform.position.x, _canvasMain.transform.position.y, detective.camera.transform.position.z) - _canvasMain.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(-lookDirection);
        //_canvasMain.transform.rotation = Quaternion.LookRotation(-lookDirection);

        Quaternion xRotation = Quaternion.Euler(rotationOffset, 0, 0);
        _canvasMain.transform.rotation = lookRotation * xRotation;
    }
}
