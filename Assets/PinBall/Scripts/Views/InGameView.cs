using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class InGameView : BasicView
{
    [SerializeField]
    TextMeshProUGUI scoreLabel;
    [SerializeField]
    EventTrigger left;
    [SerializeField]
    EventTrigger right;
    [SerializeField]
    EventTrigger accelerator;

    [SerializeField]
    Image acceleratorFill;
    [SerializeField]
    CanvasGroupController acceleratorPanel;
    [SerializeField]
    Button toMenuButton;

    public UnityEvent LeftDown, LeftUp, RightDown, RightUp, ToMenu;
    public EventTriggerData OnAcceleratorUp;
    public EventTriggerData OnAcceleratorDrag;


    void Start()
    {
        var down1 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerDown };
        var down2 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerDown };
        var up1 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerUp };
        var up2 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerUp };

        down1.callback.AddListener(x => LeftDown.Invoke());
        up1.callback.AddListener(x => LeftUp.Invoke());
        down2.callback.AddListener(x => RightDown.Invoke());
        up2.callback.AddListener(x => RightUp.Invoke());

        left.triggers.AddRange(new[] { down1, up1 });
        right.triggers.AddRange(new[] { down2, up2 });

        var drag = new EventTrigger.Entry() { eventID = EventTriggerType.Drag };
        var up3 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerUp };
        drag.callback.AddListener(x => OnAcceleratorDrag.Invoke(x as PointerEventData));
        up3.callback.AddListener(x => OnAcceleratorUp.Invoke(x as PointerEventData));

        accelerator.triggers.AddRange(new[] { drag, up3 });

        toMenuButton.onClick.AddListener(ToMenu.Invoke);
    }

    public void SetScore(int score)
    {
        scoreLabel.text = $"Score: {score}";
    }

    public void SetAcceleratorFill(float value)
    {
        acceleratorFill.fillAmount = value;
    }

    public void SetActiveAcceleratorPanel(bool value)
    {
        acceleratorPanel.RenderingEnabled = value;
    }


    [Serializable]
    public class EventTriggerData : UnityEvent<PointerEventData> { }
}
