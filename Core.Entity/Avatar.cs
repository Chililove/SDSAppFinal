using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Avatar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarType { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
