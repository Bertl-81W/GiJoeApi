namespace GiJoeApi.Models;

public class Character
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string PlaceOfBirth { get; set; } = string.Empty;    
    public string Specialty { get; set; } = string.Empty;
    
}