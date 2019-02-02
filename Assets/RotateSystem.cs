using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Mathematics;
public class RotateSystem : JobComponentSystem
{
    [Unity.Burst.BurstCompile]
    struct Components:IJobProcessComponentData<Rotation,Rotator,Position>
    {
        public float time;
        public float deltaTtme;
        public void Execute(ref Rotation ro,ref Rotator po,ref Position pos){
            
            ro.Value=Quaternion.Euler(Vector3.up*time*120);
            pos.Value+=deltaTtme* math.forward(ro.Value)*5;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job=new Components(){time=Time.time ,deltaTtme=Time.deltaTime};
        var handle=job.Schedule(this,inputDeps);
        return handle;
        
    }

}



    

