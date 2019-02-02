using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using UnityEngine.UI;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
public class ObjectCreate : MonoBehaviour {
	public GameObject ECSprefab;

	public GameObject NormalPrefab;
	public int size;

	public Mesh pMesh;
	public Material pM;	
	public InputField input;
	//[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static EntityManager entityManager;
	public List<Entity> entityList=new List<Entity>();
	public List<GameObject> objList=new List<GameObject>();

	public Transform cam;
	bool ecsFlag;
	bool showFlag;
	public  void Start(){
		ecsFlag=true;
		showFlag=true;
		Create();
	}
	public void SetECS(bool ecs){
		ecsFlag=ecs;
		Restart();
	}
	public void SetShow(bool show){
		showFlag=show;
		Restart();
	}
	public void Create(){
		try
		{
			size=int.Parse(input.text);
		}
		catch (System.Exception)
		{
			
			size=100;
		}
		if(size<0){
			size=0;
		}
		if(size>500){
			size=500;
		}
		cam.position=Vector3.one*size+Vector3.up*size*0.1f;
		if(ecsFlag){
			entityManager=World.Active.GetOrCreateManager<EntityManager>();
			//var objArchetype=entityManager.CreateArchetype(typeof(Position),typeof(Rotation),typeof(Rotator),typeof(MeshInstanceRendererComponent));
			//var objEntity=entityManager.CreateEntity();
		
		
			for (int i = 0; i <size; i++)
			{
				for (int j = 0; j <size; j++)
				{
					NativeArray<Entity> ea=new NativeArray<Entity>(1,Allocator.Temp);
					//var obj= Instantiate(viewPrefab,new Vector3(2*i,0,2*j),quaternion.identity);	
					entityManager.Instantiate(ECSprefab,ea);
					entityManager.SetComponentData(ea[0],new Position{Value=new int3( 2*i,0,2*j)});
				//	Debug.Log( ea[0].Index);
					if(showFlag){
						entityManager.AddSharedComponentData(ea[0],new MeshInstanceRenderer{
							mesh=pMesh,
							material=pM
						});
					}
				//	obj.GetComponent<ViewComponent>().entity=ea[0];
				//	ViewMagagerCenter.single.objList.Add(obj.GetComponent<ViewComponent>());
					entityList.Add(ea[0]);
					ea.Dispose();
				
					//
				
					//Instantiate(prefab,new Vector3(2*i,0,2*j),quaternion.identity);	
				}
			}
		}else{
			for (int i = 0; i <size; i++)
			{
				for (int j = 0; j <size; j++)
				{
					var obj= Instantiate(NormalPrefab,new Vector3(2*i,0,2*j),quaternion.identity);	
					objList.Add(obj);
					if(!showFlag){
						GameObject.DestroyImmediate(obj.GetComponent<MeshRenderer>());
						GameObject.DestroyImmediate(obj.GetComponent<MeshFilter>());
					}
				}
			}
		}
		
	}
	public void Restart(){
		DestoryAll();
		Create();
	}
	public void DestoryAll(){
		for (int i = 0; i <entityList.Count; i++)
		{
			entityManager.DestroyEntity(entityList[i]);
		}
		entityList.Clear();
		for (int i = 0; i < objList.Count; i++)
		{
			GameObject.DestroyImmediate(objList[i]);
		}
	}

}
