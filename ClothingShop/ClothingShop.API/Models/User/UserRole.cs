﻿namespace ClothingShop.API.Models.User
{
    public class UserRole : AuditEntity
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
