using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class BaseButton : DatMono
{

    [SerializeField] protected Button button;
    public override void Start()
    {
        base.Start();

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {
        if (button == null)
        {
            button = this.GetComponent<Button>();
        }
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
