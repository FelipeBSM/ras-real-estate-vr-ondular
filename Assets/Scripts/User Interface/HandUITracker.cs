using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class HandUITracker : MonoBehaviour
{

    public Hand hand;
    
    public float hoverDistance = 0.05f; // Distância para detectar o hover

    [SerializeField]
    private HudManager ui_Manager;

    void Start()
    {
        if (ui_Manager == null)
        {
            Debug.LogError("UI_MANAGER is undefined!");
        }
    }

    void Update()
    {
        if (hand == null || ui_Manager == null) return;

        Pose indexTipPose;
        if (hand.GetJointPose(HandJointId.HandIndexTip, out indexTipPose))
        {
            Vector3 indexTipPosition = indexTipPose.position;
        }
    }
}

