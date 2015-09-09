﻿namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Read { get; set; }
    }
}
