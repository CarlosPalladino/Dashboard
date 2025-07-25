﻿public class Provider
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public long Cuit { get; private set; }
    public string Email { get; private set; }

    private Provider() { }

    public Provider(Guid id, string name, long cuit, string email)
    {
        Id = id;
        Name = name;
        Cuit = cuit;
        Email = email;
    }
}
