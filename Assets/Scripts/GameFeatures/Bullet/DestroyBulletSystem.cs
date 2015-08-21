using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class DestroyBulletSystem : IReactiveSystem, ISetPool{
	Pool _pool;

	public IMatcher trigger {get {return Matcher.AllOf(Matcher.DestroyBullet);}	}
	
	public GroupEventType eventType {get {return GroupEventType.OnEntityAdded;}	}

	public void SetPool(Pool pool) {
		_pool = pool;
	}
	public void Execute(List<Entity> entities) {
		foreach (var e in entities) {
			GameObject.Destroy(e.gameObject.gameObject);
			_pool.DestroyEntity(e);
		}
	}
}