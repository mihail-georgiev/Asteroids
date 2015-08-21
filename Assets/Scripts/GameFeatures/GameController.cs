using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity.VisualDebugging;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour {
    Systems _systems;
	
	[HideInInspector]
	public bool runSystems = true;
	
	void Start () {
		_systems = createSystems(Pools.pool);
		_systems.Start();
	}
	
	void Update () {
		if(runSystems){
			_systems.Execute();	
		}
	}
	Systems createSystems(Pool pool) {
//		#if (UNITY_EDITOR)
//		return new DebugSystems()
//			#else
			return new Systems()
//				#endif
				
				// Initialize
				.Add(pool.CreateSystem<InitGameSystem>())
				
				// Input
				.Add(pool.CreateSystem<PlayerInputSystem>())
				.Add(pool.CreateSystem<PlayerMoveSystem>())
				.Add(pool.CreateSystem<SpawnAsteroidsSystem>())
				.Add(pool.CreateSystem<HitDetectionSystem>())
				.Add(pool.CreateSystem<ScoreSystem>())
				.Add(pool.CreateSystem<AsteroidMoveSystem>())
				.Add(pool.CreateSystem<BulletMoveSystem>())
				.Add(pool.CreateSystem<RenderPositionSystem>())
				.Add(pool.CreateSystem<DestroyAsteroidsSystem>())
				.Add(pool.CreateSystem<DestroyBulletSystem>())
				.Add(pool.CreateSystem<StopGameSystem>());
	}

}