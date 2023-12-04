using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [SerializeField] Transform firstPersonCamera, thirdPersonCamera;

    CameraController cameraController;
    

    RaycastHit hit;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        
        cameraController = GetComponent<CameraController>();
        cameraController.GetTarget(thirdPersonCamera);
    }

    public void AttackMoment()
    {
        cameraController.GetTarget(firstPersonCamera);
        cameraController.GetFpsBool(true);
    }

    public void MoveMoment()
    {
        cameraController.GetTarget(thirdPersonCamera);
        cameraController.GetFpsBool(false);
    }


    public RaycastHit SetHit(Transform cameraTransform)
    {

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            

            GetHit();
            return hit;
        }

        return hit;
        
    }

    public RaycastHit GetHit()
    {
        return hit;
    }

}
