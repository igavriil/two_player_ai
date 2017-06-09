using TwoPlayerAi.DataStructures;

namespace TwoPlayerAi.Quoridor
{
    public class Fence
    {
        public Vector StartVector { get; }

        public Vector EndVector { get; }

        public Fence(Vector startVector, Vector endVector)
        {
            StartVector = startVector;
            EndVector = endVector;
        } 
    }

}