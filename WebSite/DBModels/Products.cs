using System;

namespace WebSite.DBModels
{
    public class Products
    {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFavorite { get; set; }
    }
}
