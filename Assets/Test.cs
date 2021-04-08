using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void MovePanel(int direction)
    {
        rectTransform.DOAnchorPosX(direction * 100, 2).SetEase(Ease.OutElastic);
    }

}
