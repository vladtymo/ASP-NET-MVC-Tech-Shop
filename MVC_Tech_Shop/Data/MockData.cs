using MVC_Tech_Shop.Models;

namespace MVC_Tech_Shop.Data
{
    public static class MockData
    {
        static Random rnd = new Random();
        public static List<Laptop> GetLaptops()
        {
            return new List<Laptop>()
            {
                new Laptop()
                {
                    Id = 1,
                    Model = "Dell Latitude 5320",
                    Display = "13.3″ Full HD",
                    Processor = "11th Gen Intel® Core i5",
                    Price = 699
                },
                new Laptop()
                {
                    Id = 2,
                    Model = "Samsung Chromebook 4 310XBA-KA1",
                    Display = "11.6″ HD LED Display",
                    Processor = "Intel® Dual-Core",
                    Price = 199
                },
                new Laptop()
                {
                    Id = 3,
                    Model = "Lenovo IdeaPad Flex 5",
                    Display = "13.3″ Full HD IPS Touch Screen",
                    Processor = "Intel® Core i3",
                    Price = 419
                },
                new Laptop()
                {
                    Id = 4,
                    Model = "Dell Latitude E7420",
                    Display = "14” 4K Anti-glare",
                    Processor = "11th Gen Intel Core i7",
                    Price = 899
                }
            };
        }
        public static Laptop GetRandomLaptop()
        {
            var list = GetLaptops();
            return list[rnd.Next(list.Count)];
        }
        public static Laptop GetLaptopById(int id)
        {
            return GetLaptops().FirstOrDefault(l => l.Id == id);
        }
    }
}
