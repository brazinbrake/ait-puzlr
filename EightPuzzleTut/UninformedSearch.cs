using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleTut
{
    class UninformedSearch
    {
        public UninformedSearch()
        {

        }

        //queue (FIFO) implementation search
        public List<Node> breadthFirstSearch(Node root)
        {
            List<Node> pathToSolution = new List<Node>();
            //frontier (nodes which can be expanded)
            List<Node> openList = new List<Node>();
            //store nodes we've already expanded so we don't go back to them
            List<Node> closedList = new List<Node>();

            //start processing at the root
            openList.Add(root);

            bool goalFound = false;
            //while we still have more nodes to process and we haven't reached the goal...
            while (openList.Count > 0 && !goalFound)
            {
                //traversing node - first element from the open list queue
                Node currentNode = openList[0];
                //add it to the list of the things we've seen
                closedList.Add(currentNode);
                //remove it from the queue
                openList.RemoveAt(0);

                //expand the current node - get the possible moves
                currentNode.expandNode();

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.goalTest())
                    {
                        Console.WriteLine("Goal found");
                        goalFound = true;
                        //trace pathe to root
                        pathTrace(pathToSolution, currentChild);
                    }

                    //if not in the open list and not in the closed list...
                    if (!contains(openList, currentChild) && !contains(closedList, currentChild))
                    {
                        //add the node
                        openList.Add(currentChild);
                    }
                }
            }
            return pathToSolution;
        }

        //method to call when goal node is found
        public void pathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Tracing Path");
            Node current = n;
            path.Add(current);

            //while we haven't gotten to the root..
            while(current.parent != null)
            {
                //traverse up the nodes list
                current = current.parent;
                //add it to the path
                path.Add(current);
            }
        }

        public static bool contains(List<Node> list, Node c)
        {
            bool contains = false;

            for (int i = 0; i < list.Count; i ++)
            {
                if (list[i].isSamePuzzle(c.puzzle))
                {
                    return true;
                }
            }
            return contains;
        }
    }
}
