﻿namespace SignalRExample.WebUI.Dtos.ProductDtos
{
    public class ResultProductDtos
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
