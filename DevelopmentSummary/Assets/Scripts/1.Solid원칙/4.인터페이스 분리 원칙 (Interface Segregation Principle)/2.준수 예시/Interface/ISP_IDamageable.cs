namespace Solid.Interface_Segregation_Principle
{
    public interface ISP_IDamageable
    {
        public ISP_IDamageable Target { get; set; }
        public void OnDamage(ISP_Unit sender, int value);
    }
}