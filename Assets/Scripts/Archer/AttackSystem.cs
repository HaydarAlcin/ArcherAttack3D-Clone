using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class AttackSystem : MonoBehaviour
{
    private static bool readyToAttack;
    private bool isFiring = false;
    private bool isTheUIElements;

    private MoveSystem moveSystem;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameEvent attackEvent,fireEvent,crosshairDetected,crosshairUndetected;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform hand;
    [SerializeField] private byte targetLayer;
    [SerializeField] private float fireCooldown;
    [SerializeField] private const byte MAX_FIRE_COOLDOWN=1;
    private byte arrowNumber = 7;

    private Camera _camera;
    

    [SerializeField] private float rotationSpeed;
    private float xVector;
    private float yVector;

    private Vector3 arrowTarget;
    RaycastHit hit;

    private void Start()
    {
        moveSystem= GetComponent<MoveSystem>();
        _camera = Camera.main;
        SendTheArrowNumber();
    }

    private void Update()
    {
        AttackControl();
    }

    public void AttackControl()
    {
        if (!readyToAttack)return;

        if (readyToAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    isTheUIElements = true;
                    return;
                }
                attackEvent.Raise();
                isTheUIElements= false;
            }

            if (Input.GetMouseButton(0)&&!isTheUIElements)
            {
                
                xVector += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                yVector -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
                AimSystem(xVector, yVector);
                fireCooldown += 0.03f;
                isFiring = false;
                
            }
        }

        if (Input.GetMouseButtonUp(0) && !isFiring)
        {
            if (fireCooldown >= MAX_FIRE_COOLDOWN)
            {
                fireEvent.Raise();
                fireCooldown = 0f;
                isFiring = true;
                Fire();
                transform.GetChild(0).rotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }

    public void AimSystem(float y, float x)
    {
        //Camera Rotation
        cameraController.CameraRotate(x,y);

        //Aim
        hit = CameraManager.Instance.SetHit(_camera.transform);
        arrowTarget = hit.point;

        //Crosshair color changes
        if (hit.collider.gameObject.layer==targetLayer)
        {
            crosshairDetected.Raise();
            return;
        }
        crosshairUndetected.Raise();
        
    }

    public void Fire()
    {
        GameObject arrow = Instantiate(arrowPrefab, hand.position,Quaternion.identity);
        arrow.transform.LookAt(arrowTarget);
        readyToAttack = false;
    }

    public void ReadyToAttackTrue()
    {
        if (readyToAttack) return;
        readyToAttack = true;
    }
    public void ReadyToAttackFalse()
    {
        if (!readyToAttack) return;
        readyToAttack = false;
    }

    public void SendTheArrowNumber()
    {
        CanvasManager.Instance.SetTheArrowNumber(arrowNumber);
    }
}