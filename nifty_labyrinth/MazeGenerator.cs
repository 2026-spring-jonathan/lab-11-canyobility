using labyrinth;
using nifty_labyrinth;

public class MazeGenerator
{
    private static IEnumerable<NodeLink> links =[];
    private static string MazeBody = string.Empty;
    public static (IEnumerable<NodeLink>, string, MazeCell startLocation) GenerateMaze(string userName, bool isTwisty)
    {
        MazeCell startLocation = (isTwisty) ? MazeUtilities.twistyMazeFor(userName) : MazeUtilities.mazeFor(userName);
        
        links = exploreMaze(startLocation);        
        MazeBody = "graph TD\n";
        MazeBody += string.Join(separator: "\n", links.Select(l => l.Label));

        return (links, MazeBody, startLocation);
    }

    private static IEnumerable<NodeLink> exploreMaze(MazeCell start)
    {
        List<NodeLink> linksTest = new List<NodeLink>();
        exploreNode(start, linksTest);
        return linksTest;
    }

    private static void exploreNode(MazeCell current, List<NodeLink> links)
    {
        if (current is null)
        { return; }

        if (current.North is not null)
        {
            var northLink = new NodeLink(current, "North", current.North);
            if (!links.Contains(northLink))
            {
                links.Add(northLink);
                exploreNode(current.North, links);
            }
        }

        if (current.East is not null)
        {
            var eastLink = new NodeLink(current, "North", current.East);
            if (!links.Contains(eastLink))
            {
                links.Add(eastLink);
                exploreNode(current.East, links);
            }
        }
    
        if (current.South is not null)
        {
            var southLink = new NodeLink(current, "North", current.South);
            if (!links.Contains(southLink))
            {
                links.Add(southLink);
                exploreNode(current.South, links);
            }
        }
    
        if (current.West is not null)
        {
            var westLink = new NodeLink(current, "North", current.West);
            if (!links.Contains(westLink))
            {
                links.Add(westLink);
                exploreNode(current.West, links);
            }
        }
    }
}
