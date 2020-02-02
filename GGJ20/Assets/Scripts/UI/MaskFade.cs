using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MaskFade : MonoBehaviour
{
    [SerializeField]
    float m_ScaleTime = 0.75f;

    [SerializeField]
    float m_ScaleDelay = 0.75f;
    
    [SerializeField]
    Transform m_SpriteTransform;
    
    Vector3 m_EndScale;
    
    const float k_MaxSize = 3.5f;

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
        m_SpriteTransform.DOScale(m_EndScale, m_ScaleTime);
    }

    void OnDisable()
    {
        m_SpriteTransform.localScale = Vector3.zero;
    }

    public void ResetMask()
    {
        m_SpriteTransform.localScale = Vector3.zero;
    }
}
