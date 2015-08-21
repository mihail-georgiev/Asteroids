using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class DestroyAsteroidsSystem : IReactiveSystem, ISetPool{
	public IMatcher trigger { get { return Matcher.AllOf(Matcher.DestroyAsteroid);}}
	public GroupEventType eventType { get {	return GroupEventType.OnEntityAdded;}}

	Pool _pool;

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