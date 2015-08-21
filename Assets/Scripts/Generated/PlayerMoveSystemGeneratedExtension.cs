namespace Entitas {
    public partial class Pool {
        public ISystem CreatePlayerMoveSystem() {
            return this.CreateSystem<PlayerMoveSystem>();
        }
    }
}