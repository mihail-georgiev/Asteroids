namespace Entitas {
    public partial class Pool {
        public ISystem CreateDestroyBulletSystem() {
            return this.CreateSystem<DestroyBulletSystem>();
        }
    }
}