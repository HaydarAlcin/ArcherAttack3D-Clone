using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance { get; private set; }

    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clipList;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        
    }

    public void Hit()
    {
        audioSource.PlayOneShot(clipList[2]);
    }

    public void Fire()
    {
        audioSource.PlayOneShot(clipList[1]);
    }

    public void Aim()
    {
        audioSource.PlayOneShot(clipList[0]);
    }

    public void EnemyFire()
    {
        audioSource.PlayOneShot(clipList[3]);
    }
}
