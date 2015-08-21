namespace Entitas {
    public partial class Pool {
        public ISystem CreateDestroyAsteroidsSystem() {
            return this.CreateSystem<DestroyAsteroidsSystem>();
        }
    }
}