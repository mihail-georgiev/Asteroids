using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class RenderPositionSystem : IReactiveSystem {
	public IMatcher trigger {get { return Matcher.AllOf(Matcher.GameObject, Matcher.Position);}}
	
	public GroupEventType eventType {get{return GroupEventType.OnEntityAdded;}}
	
	public void Execute(List<Entity> entities) {
		foreach (var e in entities) {
			var pos = e.position;
			if(e.hasGameObject) {
				e.gameObject.gameObject.transform.position = new Vector3(pos.x, 0, pos.y);
			}
		}
	}
}