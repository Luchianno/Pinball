using System;
using UnityEngine;
using UnityEngine.UI;

// Wrapper around CanvasGroup
[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    CanvasGroup group;

    bool renderingEnabled;

    public bool RenderingEnabled
    {
        get
        {
            return renderingEnabled;
        }
        set
        {
            if (value == renderingEnabled)
                return;
            Debug.Log("rendering changed" + value);
            renderingEnabled = value;

            if (value)
                TurnOn();
            else
                TurnOff();
        }
    }

    // TurnOn might be called from other classes in Start cycle, making sure it's ready at that time
    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    void TurnOn()
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    void TurnOff()
    {
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }
}