﻿namespace LibraryApiExample.Models
{
    public class PublishingPlace
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}