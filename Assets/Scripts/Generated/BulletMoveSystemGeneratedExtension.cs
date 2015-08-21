namespace Entitas {
    public partial class Pool {
        public ISystem CreateBulletMoveSystem() {
            return this.CreateSystem<BulletMoveSystem>();
        }
    }
}