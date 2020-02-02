using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MaskFade : MonoBehaviour
{
    [SerializeField]
    float m_ScaleTime = 2.0f;

    [SerializeField]
    float m_ScaleDelay = 0.75f;
    
    [SerializeField]
    Transform m_SpriteTransform;
    
    Vector3 m_EndScale;
    
    const float k_MaxSize = 2.5f;

    [SerializeField]
    GameObject m_BackButton;

    void Start()
    {
        m_SpriteTransform.localScale = Vector3.zero;
        m_EndScale = new Vector3(k_MaxSize, k_MaxSize, k_MaxSize);
    }

    public void ScaleMask()
    {
        StartCoroutine(DelayScale());
    }

    IEnumerator DelayScale()
    {
        yield return new WaitForSeconds(m_ScaleDelay);
        m_SpriteTransform.DOScale(m_EndScale, m_ScaleTime).OnComplete(()=> m_BackButton.SetActive(true));
    }

    void OnDisable()
    {
        m_SpriteTransform.localScale = Vector3.zero;
    }

    public void ResetMask()
    {
        DOTween.Kill(m_SpriteTransform);
        m_SpriteTransform.localScale = Vector3.zero;
    }
}
