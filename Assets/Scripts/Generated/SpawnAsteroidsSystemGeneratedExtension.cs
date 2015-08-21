namespace Entitas {
    public partial class Pool {
        public ISystem CreateSpawnAsteroidsSystem() {
            return this.CreateSystem<SpawnAsteroidsSystem>();
        }
    }
}