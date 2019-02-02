using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Mathematics;
public class ViewMagagerCenter : MonoBehaviour
{
    public static ViewMagagerCenter single;
    [HideInInspector]
    public List<ViewComponent> objList;


  
    private void Awake() {
        single=this;
        objList=new List<ViewComponent>();
     

    }
    private void Update() {
    
        foreach (var item in objList)
        {
            var pos= ObjectCreate. entityManager.GetComponentData<Position>(item.entity);
            item.transform.position=pos.Value;
            var rot=  ObjectCreate.entityManager.GetComponentData<Rotation>(item.entity);
            item.transform.rotation=rot.Value;
         
        }
    }
}



    

