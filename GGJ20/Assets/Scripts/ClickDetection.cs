﻿using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ClickDetection : MonoBehaviour
{
    void OnMouseUpAsButton() {
        OnClick();
    }

    protected virtual void OnClick () {
        Debug.LogError("OnClick not implemented.");
    }
}
