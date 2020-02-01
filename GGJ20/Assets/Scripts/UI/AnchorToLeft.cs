using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class AnchorToLeft : MonoBehaviour
{
    public float XAnchor = 0.0f;
    private RectTransform m_rect;

    void Start()
    {
        m_rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(m_rect);
        m_rect.anchoredPosition = new Vector2(
            m_rect.sizeDelta.x/2 + XAnchor,
            m_rect.anchoredPosition.y
        );
    }
}