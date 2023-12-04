using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControlSystem : MonoBehaviour
{
    public static HitControlSystem Instance { get; private set; }
    [SerializeField] private short archerHealth = 200;

    private bool killDelay;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void HitTarget(string hitTargetLayer)
    {
        Debug.Log(hitTargetLayer + " " + "shot");
        CanvasManager.Instance.FunctionOfThePartHit(hitTargetLayer);
    }

    public void ArcherGetTheDamage()
    {
        archerHealth -= 15;
        if (archerHealth<=0)
        {
            CanvasManager.Instance.GameOver();
        }
    }
    
}
