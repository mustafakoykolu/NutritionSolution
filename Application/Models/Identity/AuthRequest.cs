﻿namespace Application.Models.Identity
{
    public class AuthRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
