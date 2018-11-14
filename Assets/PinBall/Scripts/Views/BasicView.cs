using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroupController))]
public abstract class BasicView : MonoBehaviour
{
    protected CanvasGroupController canvasController;

    protected virtual void Awake()
    {
        canvasController = GetComponent<CanvasGroupController>();
    }

    protected virtual void OnEnable()
    {
        // weird error fix here
        if (canvasController == null)
        {
            canvasController = GetComponent<CanvasGroupController>();
        }
        canvasController.RenderingEnabled = true;
    }
    protected virtual void OnDisable() { canvasController.RenderingEnabled = false; }
}
