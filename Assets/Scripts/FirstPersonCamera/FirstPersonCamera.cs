using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] GameEvent zoomOnShot;

    private Vector3 currentTransform;

    private Vector3 targetPosition;


    public void FireFpsCameraAnimation()
    {
        currentTransform = transform.localPosition;
        targetPosition = transform.position + transform.forward * 2f;
        transform.DOMove(targetPosition, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            
            transform.localPosition = currentTransform;
            zoomOnShot.Raise();

        });
       
    }
}
