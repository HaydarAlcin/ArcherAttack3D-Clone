using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshArrowSetActiveControl : MonoBehaviour
{
    [SerializeField] GameObject meshArrow;
    
    public void Active()
    {
        meshArrow.SetActive(true);
    }

    public void Inactive()
    {
        meshArrow.SetActive(false);
    }
}
