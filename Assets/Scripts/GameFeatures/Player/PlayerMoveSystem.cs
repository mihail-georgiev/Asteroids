using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMoveSystem : IReactiveSystem {
	public IMatcher trigger {get { return Matcher.PlayerSpeed;} }
	public GroupEventType eventType { get {	return GroupEventType.OnEntityAdded;}}

	public void Execute(List<Entity> entities) {
		var player = entities.SingleEntity();
		var pos = getNewClampedPlayerPos(player.position.x, player.position.y, player.playerSpeed.speedX, player.playerSpeed.speedY);
		player.ReplacePosition(pos.x, pos.y);
	}

	Vector2 getNewClampedPlayerPos(float posX, float posY, float speedX, float speedY)	{
		posX = posX + speedX;
		posX = Mathf.Min(posX, 60f);
		posX= Mathf.Max(posX, -60f);
		posY = posY + speedY;
		posY = Mathf.Min(posY, 43f);
		posY = Mathf.Max(posY, -43f);

		return new Vector2(posX, posY);
	}
}