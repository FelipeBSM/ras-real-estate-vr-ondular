using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseDetectionActor : MonoBehaviour
{
    [Header("Object To Show / Hide")]
    public GameObject arrowPointer;

    private ArrowHandRay arrowHand;
    private ArrowHandRayBezier arrowHandBezier;

    public bool BezierEnable = true;
    public bool useArrow = true;

    public GameObject player,goRight,camera,fingerTip;
    private FingerLocomotion f_loco;

    public float positionIncreaseAmmount = .8f;

    [Header("Finger Locomotion Settings")]
    public int ammountOfRays = 3;
    public float distanceBetweenRays = .5f;
    public float rayDistance = 1.5f;
    public Vector3 rayOffset = new Vector3(0, 2f, 0);
    public LayerMask ignoreLayer;
    public GameObject playerHandL,playerHandR;
    public Material negativeFeedbackMaterial;
    public AudioSource deniedSource;

    //public float timeToWaitAction;
    private void Awake()
    {
        if(useArrow == true)
        {
            Destroy(goRight.gameObject);
            if (BezierEnable == false)
            {
                arrowPointer.GetComponent<ArrowHandRay>().enabled = true;
                arrowHand = arrowPointer.GetComponent<ArrowHandRay>();
            }
            else
            {
                arrowPointer.GetComponent<ArrowHandRayBezier>().enabled = true;
                arrowHandBezier = arrowPointer.GetComponent<ArrowHandRayBezier>();
            }
        }
        else
        {
            /*GameObject _g = new GameObject();
            _g.name = "FingerActor";
            _g.transform.parent = player.transform;*/


            f_loco = fingerTip.AddComponent<FingerLocomotion>();

            SkinnedMeshRenderer rendR = playerHandR.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer rendL = playerHandL.GetComponent<SkinnedMeshRenderer>();

            f_loco.SetPlayer(player,camera,rayOffset,rayDistance,ammountOfRays,distanceBetweenRays,ignoreLayer,rendR,rendL,negativeFeedbackMaterial,deniedSource,fingerTip,positionIncreaseAmmount);
        }
       
       
        
    }
    public void DetectedAim()
    {
        if(useArrow == true)
        {
            arrowPointer.SetActive(true);
            if (BezierEnable == true)
                arrowHandBezier.SwitchAiming();
            else
                arrowHand.SwitchAiming();
        }
       
    }
    public void NoDetectedAim()
    {
        if (BezierEnable == true)
        {
            arrowHandBezier.SwitchAiming();
            arrowHandBezier.teleportLocationFeedback.SetActive(false);
        }
        else
        {
            arrowHand.SwitchAiming();
            arrowHand.teleportLocationFeedback.SetActive(false);
        }
            
        arrowPointer.SetActive(false);
        //espera por alguns instantes pelo toque, se não houver cancela o aim e reseta tudo.
        //se vier cancela o aim, reseta e vai para o local.
    }

    public void DetectedGoSign()
    {
        if(arrowHandBezier.aimHitGround == true && arrowHandBezier.isAiming == true)
            arrowHandBezier.MoveToLocation();
    }
    public void NoDetectedGoSign()
    {
        arrowHandBezier.DesableMovement();
    }

    public void DetectedSoloGo()
    {
        f_loco.ChangePlayerPosition();
    }
    public void UndetectedSoloGo()
    {
        f_loco.ResetMovement();
    }

   

}
