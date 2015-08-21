using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public PlayerSpeedComponent playerSpeed { get { return (PlayerSpeedComponent)GetComponent(ComponentIds.PlayerSpeed); } }

        public bool hasPlayerSpeed { get { return HasComponent(ComponentIds.PlayerSpeed); } }

        static readonly Stack<PlayerSpeedComponent> _playerSpeedComponentPool = new Stack<PlayerSpeedComponent>();

        public static void ClearPlayerSpeedComponentPool() {
            _playerSpeedComponentPool.Clear();
        }

        public Entity AddPlayerSpeed(float newSpeedX, float newSpeedY) {
            var component = _playerSpeedComponentPool.Count > 0 ? _playerSpeedComponentPool.Pop() : new PlayerSpeedComponent();
            component.speedX = newSpeedX;
            component.speedY = newSpeedY;
            return AddComponent(ComponentIds.PlayerSpeed, component);
        }

        public Entity ReplacePlayerSpeed(float newSpeedX, float newSpeedY) {
            var previousComponent = hasPlayerSpeed ? playerSpeed : null;
            var component = _playerSpeedComponentPool.Count > 0 ? _playerSpeedComponentPool.Pop() : new PlayerSpeedComponent();
            component.speedX = newSpeedX;
            component.speedY = newSpeedY;
            ReplaceComponent(ComponentIds.PlayerSpeed, component);
            if (previousComponent != null) {
                _playerSpeedComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemovePlayerSpeed() {
            var component = playerSpeed;
            RemoveComponent(ComponentIds.PlayerSpeed);
            _playerSpeedComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherPlayerSpeed;

        public static AllOfMatcher PlayerSpeed {
            get {
                if (_matcherPlayerSpeed == null) {
                    _matcherPlayerSpeed = new Matcher(ComponentIds.PlayerSpeed);
                }

                return _matcherPlayerSpeed;
            }
        }
    }
}
