﻿namespace LoginBackend.Domain.Entities;

public class User
{
    public Guid Guid { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
