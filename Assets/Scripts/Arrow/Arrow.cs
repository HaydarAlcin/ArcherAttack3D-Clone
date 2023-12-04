using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameEvent EnemyHit, EnemyAttack;

    [SerializeField] float arrowSpeed;
    

    private EnemyAnimationController enemyAnimationController;
    private Collider arrowBoxCollider;

    private GameObject bloodEffect;
    private void Start()
    {
        transform.parent = null;
        arrowBoxCollider = GetComponent<Collider>();
        //Mantikli bir yontem degil
        Destroy(this.gameObject,5f);

        bloodEffect = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        Move();   
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        arrowSpeed = 0f;
        if (other.gameObject.TryGetComponent(out enemyAnimationController))
        {
            EnemyDeathAnimationCalled();
            ArrowHit(other.gameObject.tag);
            transform.parent = other.gameObject.transform;
            return;
        }
        EnemyAttack.Raise();

    }

    public void ArrowHit(string other)
    {
        HitControlSystem.Instance.HitTarget(other);
        SoundsManager.Instance.Hit();
        arrowBoxCollider.enabled = false;
    }

    public void EnemyDeathAnimationCalled()
    {
        EnemyHit.Raise();
        enemyAnimationController.Death();
        bloodEffect.SetActive(true);
    }
}
