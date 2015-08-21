using Entitas;
using UnityEngine;

public class PlayerInputSystem : IExecuteSystem, ISetPool {
	Pool _pool;

	public void SetPool(Pool pool) {
		_pool = pool;
	}
	
	public void Execute() {	
		var playerEntity = _pool.playerEntity;
		Vector2 previousSpeed = new Vector2(playerEntity.playerSpeed.speedX, playerEntity.playerSpeed.speedY);
		Vector2 newSpeed = Vector2.zero;
		if(Input.GetKey(KeyCode.UpArrow))
		{
			newSpeed.y = 1;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			newSpeed.y = -1;
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			newSpeed.x = -1;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			newSpeed.x = 1;
		}

		if(newSpeed != Vector2.zero || previousSpeed!= newSpeed)
			playerEntity.ReplacePlayerSpeed(newSpeed.x,newSpeed.y);

		if (Input.GetKeyDown (KeyCode.Space))
			shoot(playerEntity.position);
}

	void shoot(PositionComponent playerPos){
		GameObject newBullet = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
		Entity e = _pool.CreateEntity();
		e.isBullet = true;
		e.AddGameObject (newBullet);
		e.AddPosition (playerPos.x + 15f, playerPos.y);
	}
}