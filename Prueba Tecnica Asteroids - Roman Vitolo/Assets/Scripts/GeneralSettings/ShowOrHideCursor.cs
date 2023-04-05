using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHideCursor : MonoBehaviour
{
    [SerializeField] private bool activeOrDeactivated;
    private void Start()
    {
        CursorVisibility();
    }

    private void CursorVisibility()
    {
        Cursor.visible = activeOrDeactivated;
    }
}
