namespace DAL.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoryDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}