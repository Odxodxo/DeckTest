using DeckTest.DecksClasses;
using Microsoft.AspNetCore.Mvc;

namespace DeckTest.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{
    Decks decks = new();
    // GET
    [HttpGet]
    public string Get(string name)
    {
        decks.Get(name);
        return $"GET Some Random {name}";
    }

    // POST
    [HttpPost]
    public string Post(string name)
    {
        decks.Add(name);
        return $"POST ${name}";
    }
    
    //DELETE
    [HttpDelete]
    public string Delete(string name)
    {
        decks.Remove(name);
        return $"DELETE ${name}";
    }
    
    //GET ALL DECKS
    [HttpGet]
    public string GetAll()
    {
        decks.GetDecksNames();
        return $"Get All decks names";
    }
    
    //PUT ANOTHER SHUFFLE METHOD
    [HttpPut]
    public string ChangeShuffleConfiguration(string shaffleName="Base")
    {
        decks.ChangeShuffle(shaffleName);
        return $"Shuffle provider changed to ${shaffleName}";
    }
}