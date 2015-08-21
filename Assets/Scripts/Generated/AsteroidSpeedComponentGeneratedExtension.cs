using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public AsteroidSpeedComponent asteroidSpeed { get { return (AsteroidSpeedComponent)GetComponent(ComponentIds.AsteroidSpeed); } }

        public bool hasAsteroidSpeed { get { return HasComponent(ComponentIds.AsteroidSpeed); } }

        static readonly Stack<AsteroidSpeedComponent> _asteroidSpeedComponentPool = new Stack<AsteroidSpeedComponent>();

        public static void ClearAsteroidSpeedComponentPool() {
            _asteroidSpeedComponentPool.Clear();
        }

        public Entity AddAsteroidSpeed(float newSpeed) {
            var component = _asteroidSpeedComponentPool.Count > 0 ? _asteroidSpeedComponentPool.Pop() : new AsteroidSpeedComponent();
            component.speed = newSpeed;
            return AddComponent(ComponentIds.AsteroidSpeed, component);
        }

        public Entity ReplaceAsteroidSpeed(float newSpeed) {
            var previousComponent = hasAsteroidSpeed ? asteroidSpeed : null;
            var component = _asteroidSpeedComponentPool.Count > 0 ? _asteroidSpeedComponentPool.Pop() : new AsteroidSpeedComponent();
            component.speed = newSpeed;
            ReplaceComponent(ComponentIds.AsteroidSpeed, component);
            if (previousComponent != null) {
                _asteroidSpeedComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveAsteroidSpeed() {
            var component = asteroidSpeed;
            RemoveComponent(ComponentIds.AsteroidSpeed);
            _asteroidSpeedComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherAsteroidSpeed;

        public static AllOfMatcher AsteroidSpeed {
            get {
                if (_matcherAsteroidSpeed == null) {
                    _matcherAsteroidSpeed = new Matcher(ComponentIds.AsteroidSpeed);
                }

                return _matcherAsteroidSpeed;
            }
        }
    }
}
