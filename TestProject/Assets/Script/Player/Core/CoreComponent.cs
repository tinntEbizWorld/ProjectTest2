using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour,ILogicUpdate
{
    protected Core core;

    public void LogicUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();
        if (core == null)
            Debug.LogError("There is no Core on the parent");
        else
            core.AddComponent(this);
    }

}
