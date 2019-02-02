using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[System. Serializable]
public struct Rotator : IComponentData {
    
    public int speed;
    
}

  
public class RotatorComponent : ComponentDataWrapper<Rotator>
{
}