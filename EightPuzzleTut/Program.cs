using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleTut
{
    class Program
    {
        static void Main(string[] args)
        {
            //test puzzle  scenario
            int[] puzzle = {
                1, 2, 4,
                3, 0, 5,
                7, 6, 8
            };
            //set up board
            Node root = new Node(puzzle);
            //get bfs solution
            UninformedSearch ui = new UninformedSearch();
            List<Node> solution = ui.breadthFirstSearch(root);

            //if solution found, print it
            if (solution.Count > 0)
            {
                for (int i = 0; i < solution.Count; i++)
                {
                    solution[i].printPuzzle();
                }
            }
            else
            {
                Console.WriteLine("No Path to Solution Found");
            }

            //hang to show output
            Console.Read();
        }
    }
}
