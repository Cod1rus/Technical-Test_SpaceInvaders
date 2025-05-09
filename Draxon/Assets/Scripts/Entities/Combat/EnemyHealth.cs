namespace Entities.Combat
{
    public class EnemyHealth : Health
    {
        private const float DeathDelay = 1f;
        
        protected override void KillEntity()
        {
            // TODO add effect
            Destroy(this,DeathDelay);
        }
    }
}