using TwoPlayerAi.Graphs;
using TwoPlayerAi.DataStructures;
using System.Text;
using System;

namespace TwoPlayerAi.Games
{
    public class Board : UndirectedSparseGraph<Vector>
    {
        public int Dimension { get; }
        public Board(int dimension)
        {
            Dimension = dimension;
            this.SetVetrices();
            this.SetEdges();
        }

        private void SetVetrices()
        {
            for (int x = 0; x < Dimension; x++)
            {
                for (int y = 0; y < Dimension; y++)
                {
                    this.AddVertex(new Vector(x, y));
                }
            }
        }

        private void SetEdges()
        {
            for (int x = 0; x < Dimension; x++)
            {   
                for (int y = 0; y < Dimension; y++)
                {
                    if (y + 1 < Dimension)
                    {
                        this.SetEdge(new Vector(x,y), new Vector(x, y - 1));
                    }
                    if (y - 1 < Dimension)
                    {
                        this.SetEdge(new Vector(x,y), new Vector(x, y - 1));
                    }
                    if (x + 1 < Dimension)
                    {
                        this.SetEdge(new Vector(x,y), new Vector(x + 1, y));
                    }
                    if (x - 1 < Dimension)
                    {
                        this.SetEdge(new Vector(x,y), new Vector(x - 1, y));
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder boardBuilder = new StringBuilder();
            for (int y = Dimension - 1; y >= 0; y--)
            {
                boardBuilder.AppendLine(this.LineToString(y));
            }
            return boardBuilder.ToString();
        }

        private String LineToString(int y)
        {
            StringBuilder lineBuilder = new StringBuilder();
            StringBuilder horizontalBuilder = new StringBuilder();
            StringBuilder verticalBuilder = new StringBuilder();
            for (int x = 0; x < Dimension ; x++)
            {
                Vector vector = new Vector(x, y);
                if (x + 1 < Dimension)
                {
                    if (this.HasEdge(vector, new Vector(x+1, y)))
                    {
                        horizontalBuilder.Append($"[{vector}] - ");
                    }
                    else
                    {
                        horizontalBuilder.Append($"[{vector}]   ");
                    }
                }
                else
                {
                    horizontalBuilder.Append($"[{vector}]");
                }

                if (y - 1 < Dimension)
                {
                    if (this.HasEdge(vector, new Vector(x, y - 1)))
                    {
                        verticalBuilder.Append($"    |       ");
                    }
                    else
                    {
                        verticalBuilder.Append($"            ");
                    }
                }
                else
                {
                    verticalBuilder.Append($"            ");
                }
            }
            lineBuilder.AppendLine(horizontalBuilder.ToString());
            lineBuilder.AppendLine(verticalBuilder.ToString());
            return lineBuilder.ToString();
        }
    }
}