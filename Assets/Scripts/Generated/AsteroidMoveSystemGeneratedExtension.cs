namespace Entitas {
    public partial class Pool {
        public ISystem CreateAsteroidMoveSystem() {
            return this.CreateSystem<AsteroidMoveSystem>();
        }
    }
}