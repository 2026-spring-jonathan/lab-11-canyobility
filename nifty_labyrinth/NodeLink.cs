using labyrinth;
namespace nifty_labyrinth;

public record NodeLink(MazeCell From, string Direction, MazeCell To)
{
    public string Label => $"{From.Id}[\"{From}\"]--{Direction}-->{To.Id}[\"{To}\"]";
}