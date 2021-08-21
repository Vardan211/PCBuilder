namespace PCBuilder.DataAccess.Entities
{
    public class ComputerBuildEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? GPUId { get; set; }
        public int? CPUId { get; set; }
        public int? MBId { get; set; }
        public decimal Price { get; set; }
        
    }
}