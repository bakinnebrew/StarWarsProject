using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace StarWarsProject
{
    public interface IStarshipService
    {
        string GetStarships(string manufacturer);
    }
}