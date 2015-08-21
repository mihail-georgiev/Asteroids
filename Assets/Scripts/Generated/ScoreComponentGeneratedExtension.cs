using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public ScoreComponent score { get { return (ScoreComponent)GetComponent(ComponentIds.Score); } }

        public bool hasScore { get { return HasComponent(ComponentIds.Score); } }

        static readonly Stack<ScoreComponent> _scoreComponentPool = new Stack<ScoreComponent>();

        public static void ClearScoreComponentPool() {
            _scoreComponentPool.Clear();
        }

        public Entity AddScore(int newScore) {
            var component = _scoreComponentPool.Count > 0 ? _scoreComponentPool.Pop() : new ScoreComponent();
            component.score = newScore;
            return AddComponent(ComponentIds.Score, component);
        }

        public Entity ReplaceScore(int newScore) {
            var previousComponent = hasScore ? score : null;
            var component = _scoreComponentPool.Count > 0 ? _scoreComponentPool.Pop() : new ScoreComponent();
            component.score = newScore;
            ReplaceComponent(ComponentIds.Score, component);
            if (previousComponent != null) {
                _scoreComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveScore() {
            var component = score;
            RemoveComponent(ComponentIds.Score);
            _scoreComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity scoreEntity { get { return GetGroup(Matcher.Score).GetSingleEntity(); } }

        public ScoreComponent score { get { return scoreEntity.score; } }

        public bool hasScore { get { return scoreEntity != null; } }

        public Entity SetScore(int newScore) {
            if (hasScore) {
                throw new SingleEntityException(Matcher.Score);
            }
            var entity = CreateEntity();
            entity.AddScore(newScore);
            return entity;
        }

        public Entity ReplaceScore(int newScore) {
            var entity = scoreEntity;
            if (entity == null) {
                entity = SetScore(newScore);
            } else {
                entity.ReplaceScore(newScore);
            }

            return entity;
        }

        public void RemoveScore() {
            DestroyEntity(scoreEntity);
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherScore;

        public static AllOfMatcher Score {
            get {
                if (_matcherScore == null) {
                    _matcherScore = new Matcher(ComponentIds.Score);
                }

                return _matcherScore;
            }
        }
    }
}
