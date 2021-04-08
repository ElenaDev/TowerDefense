using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform panelAlly;

    int direction = 1;
    private void Awake()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            direction = direction * -1;
            panelAlly.DOAnchorPosX(direction * 100, 2).SetEase(Ease.OutElastic);
        }
    }
}
