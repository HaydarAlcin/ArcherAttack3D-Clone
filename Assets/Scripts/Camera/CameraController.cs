using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    Camera _camera;
    Transform _targetPos;
    [SerializeField] float _maxDistance;
    //[SerializeField] float _xMaxPosition;
    [SerializeField] private float fpsTrackingLimit;
    [SerializeField] private float tpsTrackingLimit;
    [SerializeField] private float tpsRotationSpeed = 0.2f;
    private float minXRotation = -45f;
    private float maxXRotation = 45f;
    private float minYRotation = -150f;
    private float maxYRotation = 150f;

    [SerializeField] Transform _archer,lookTarget;

    private bool fpsCam;
    private bool justOneMore;

    private void Start()
    {
        _camera = Camera.main;
        justOneMore = true;
    }

    private void LateUpdate()
    {
        if (fpsCam==true)
        { 
            
            FpsCamera();
            
            //Debug.Log("FPS");
            return;
        }

        TpsCamera();
        //Debug.Log("TPS");

    }


    public void FpsCamera()
    {
        if (justOneMore==true)
        {
            _camera.transform.DOMove(_targetPos.position, 1f).OnComplete(() =>
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, _targetPos.position, fpsTrackingLimit);
            });
            justOneMore=false;
            return;
        }
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _targetPos.position, fpsTrackingLimit);

    }

    public void TpsCamera()
    {
        //Move
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _targetPos.position, tpsTrackingLimit);

        if (Vector3.Distance(_camera.transform.position, _targetPos.position) >= _maxDistance)
        {
            //Rotate
            Vector3 targetPos = _archer.position;
            Vector3 camPos = _camera.transform.position;
            //Vector3 newRotation = Quaternion.LookRotation(targetPos - camPos).eulerAngles;
            //_camera.transform.rotation = Quaternion.Euler(0, newRotation.y, 0);
            Quaternion targetRotation = Quaternion.LookRotation(targetPos - camPos);
            
            _camera.transform.rotation = Quaternion.Slerp(_camera.transform.rotation, targetRotation, tpsRotationSpeed);
        }
    }


    public void GetTarget(Transform transform)
    {
        _targetPos = transform; 
    }

    public void GetFpsBool(bool cam)
    {
        fpsCam = cam;
        
    }


    public void CameraRotate(float xPos, float yPos)
    {
        //Camera
        xPos = Mathf.Clamp(xPos, minXRotation, maxXRotation);
        yPos = Mathf.Clamp(yPos, minYRotation, maxYRotation);
        _camera.transform.rotation = Quaternion.Euler(xPos, yPos, 0);

        //Archer
        ArcherRotate();
    }

    public void ArcherRotate()
    {
        _archer.transform.LookAt(lookTarget);
    }


    
}
