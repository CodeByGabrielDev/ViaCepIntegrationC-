namespace CepIntegration.Entities;

public class Pessoa
{
    
    public int Id{get;set;}
    public string Name{get;set;}
    public DateTime BornDate{get;set;}
    public int Age{get;set;}
    public List<CepEntity>Ceps {get;set;}= new List<CepEntity>();



}