namespace PCBuilder.DataAccess.Entities
{
    public class ComputerBuildEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string MB { get; set; }
        public decimal Price { get; set; }

    }
}