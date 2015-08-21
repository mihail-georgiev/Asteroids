using Entitas;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StopGameSystem : IReactiveSystem, ISetPool{
	Pool _pool;
	GameObject _gameOverPanel;
	Text _infoLabel;

	public IMatcher trigger {get{return Matcher.StopGame;}}
	
	public GroupEventType eventType {get{return GroupEventType.OnEntityAdded;}}

	public void SetPool(Pool pool) {
		_pool = pool;
		_gameOverPanel = GameObject.Find("GameOverPanel");
		_infoLabel = GameObject.Find("InfoLabel").GetComponent<Text>();
		_gameOverPanel.SetActive(false);
	}

	public void Execute(List<Entity> entities) {
		GameObject.FindObjectOfType<GameController>().runSystems = false;
		_gameOverPanel.SetActive(true);
		_infoLabel.text = "Game Over\nYou got: " + _pool.score.score + " points!";
		_pool.DestroyAllEntities();
	}
}