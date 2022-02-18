using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    //public CollisionSenses CollisionSenses
    //{
    //    get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
    //    private set => collisionSenses = value;
    //}

    public CollisionSenses collisionSenses;
    public Movement movement;

    private List<ILogicUpdate> components = new List<ILogicUpdate>();

    private void Awake()
    {

    }
    public void LogicUpdate()
    {
        foreach(ILogicUpdate component in components)
        {
            component.LogicUpdate();
        }
    }
    public void AddComponent(ILogicUpdate component)
    {
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }
}
