using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleTut
{
    class Node
    {
        //represents frontier of legal actions
        public List<Node> children = new List<Node>();
        //for tracking backward path
        public Node parent;
        //one dimensional array rep. of 2 dimensional board
        public int[] puzzle = new int[9];
        //init index of puzzle start
        public int x = 0;
        public const int COLUMNS = 3;

        //construtor --> set up board
        public Node(int[] p)
        {
            makePuzzle(p);
        }

        //setup helper
        public void makePuzzle(int[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                this.puzzle[i] = p[i];
            }
        }

        //perform all legal actions
        public void expandNode()
        {
            for (int i =0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == 0)
                {
                    x = i;
                }
            }

            moveRight(puzzle, x);
            moveLeft(puzzle, x);
            moveUp(puzzle, x);
            moveDown(puzzle, x);
        }

        //shift right --> index + 1
        public void moveRight(int[] p, int i)
        {
            //check if a valid move (cant move far right Nodes to the right)
            if (i % COLUMNS < COLUMNS - 1)
            {
                //set up a dummy array
                //to simulate making a possible move
                //without affecting the real board
                int[] dummy = new int[9];
                //copy the p array to the dummy
                copyPuzzle(p, dummy);
                //create temp variable for the location of the place we want to move
                int temp = dummy[i + 1];
                //perform swap
                dummy[i + 1] = dummy[i];
                dummy[i] = temp;
                
                //set up the frontier
                Node child = new Node(dummy);
                children.Add(child);
                //set up the tracing 
                child.parent = this;
            }
        }

        /*
         * START LEGAL MOVES
         */
        //shift left --> index - 1
        public void moveLeft(int[] p, int i)
        {
            //check if a valid move (cant move far right Nodes to the right
            if (i % COLUMNS > 0)
            {
                //set up a dummy array
                int[] dummy = new int[9];
                //copy the p array to the dummy
                copyPuzzle(p, dummy);
                //create temp variable for the location of the place we want to move
                int temp = dummy[i - 1];
                //perform swap
                dummy[i - 1] = dummy[i];
                dummy[i] = temp;

                //set up the frontier
                Node child = new Node(dummy);
                children.Add(child);
                //set up the tracing 
                child.parent = this;
            }
        }

        //shift up --> index -3
        public void moveUp(int[] p, int i)
        {
            //check if a valid move (cant move far right Nodes to the right
            if (i - COLUMNS >= 0)
            {
                //set up a dummy array
                int[] dummy = new int[9];
                //copy the p array to the dummy
                copyPuzzle(p, dummy);
                //create temp variable for the location of the place we want to move
                int temp = dummy[i - 3];
                //perform swap
                dummy[i - 3] = dummy[i];
                dummy[i] = temp;

                //set up the frontier
                Node child = new Node(dummy);
                children.Add(child);
                //set up the tracing
                child.parent = this;
            }
        }

        //shift down --> index + 3
        public void moveDown(int[] p, int i)
        {
            //check if a valid move (cant move far right Nodes to the right
            if (i + COLUMNS < p.Length)
            {
                //set up a dummy array
                int[] dummy = new int[9];
                //copy the p array to the dummy
                copyPuzzle(p, dummy);
                //create temp variable for the location of the place we want to move
                int temp = dummy[i + 3];
                //perform swap
                dummy[i + 3] = dummy[i];
                dummy[i] = temp;

                //set up the frontier
                Node child = new Node(dummy);
                children.Add(child);
                //set up the tracing
                child.parent = this;
            }
        }
        /*
        * END LEGAL MOVES
        */

        public void printPuzzle()
        {
            Console.WriteLine();
            int m = 0;
            for (int i = 0; i < COLUMNS; i ++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Console.Write(puzzle[m] + "");
                    m++;
                }
                Console.WriteLine();
            }
        }

        public bool isSamePuzzle(int[] p)
        {
            bool samePuzzle = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (puzzle[i] != p[i])
                {
                    return false;
                }
            }
            return samePuzzle;
        }

        //copy initArray to newArray
        public void copyPuzzle(int[] initArray, int[] newArray)
        {
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = initArray[i];
            }
        }

        //rtn true if reached goal reached, else false
        public bool goalTest()
        {
            bool isGoal = true;
            //start search at first element
            int m = puzzle[0];
            //run through all elements
            for (int i = 1; i < puzzle.Length; i++)
            {
                //if previous number is greater than the next...
                if (m > puzzle[i])
                {
                    //we have an out of order puzzle so goal not reached
                    isGoal = false;
                }
                m = puzzle[i];
            }
            return isGoal;
        }
    }
}
