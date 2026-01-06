namespace GiJoeApi.Models;

public class Joe
{
    public string Name { get; set; }
    public string Specialty { get; set; }

    public Joe(string name, string specialty)
    {
        Name = name;
        Specialty = specialty;
    }
}