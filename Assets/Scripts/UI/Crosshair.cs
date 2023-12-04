using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private Image crossImage;

    private Color32 crossColorRed=Color.red;
    private Color32 crossColorGreen=Color.green;

    private float scaleDuration = .5f;
    private Vector3 maxScale = new Vector3(1.5f, 1.5f, 0f);
    private Vector3 minScale = new Vector3(.8f, .8f, 0f);

    private void Awake()
    {
        crossImage = GetComponent<Image>();
        crossImage.enabled = false;
    }

    public void TargetDetected()
    {
        crossImage.color = crossColorRed;

        crossImage.transform.DOScale(minScale, scaleDuration)
            .SetEase(Ease.OutBounce);
    }

    public void Undetected()
    {
        crossImage.color=crossColorGreen;
        crossImage.transform.DOScale(maxScale, scaleDuration)
            .SetEase(Ease.OutBounce);
    }

    public void VisibilityOn()
    {
        crossImage.enabled = true;
    }

    public void VisibilityOff()
    {
        crossImage.enabled = false;
    }


}
