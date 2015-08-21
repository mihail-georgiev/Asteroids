﻿using Entitas;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreSystem : IReactiveSystem, ISetPool{
	Pool _pool;
	Text _scoreLabel;

	public IMatcher trigger {get { return Matcher.AllOf(Matcher.Score);}}
	
	public GroupEventType eventType { get { return GroupEventType.OnEntityAdded;}}

	public void SetPool(Pool pool) {
		_pool = pool;
		_scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
	}

	public void Execute(List<Entity> entities) {
		_scoreLabel.text = "Score: " + _pool.score.score;
	}
}