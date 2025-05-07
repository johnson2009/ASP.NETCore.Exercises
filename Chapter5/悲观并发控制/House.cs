namespace 悲观并发控制;

public class House
{
    public long Id{get;set;}
    public string Name {get;set;} = null!;

    public string? Owner {get;set;}
}
