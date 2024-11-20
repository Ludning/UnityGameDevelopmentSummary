namespace Solid.Interface_Segregation_Principle
{
    public interface ISP_IPickable
    {
        public void OnPickUp(ISP_Inventory owner);
        public void OnPickDown(ISP_Inventory owner);
    }
}