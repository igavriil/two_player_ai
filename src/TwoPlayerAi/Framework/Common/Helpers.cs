namespace TwoPlayerAi.Framework.Common
{
    public static class Helpers
    {
        public static void Populate<T>(this T[,] array, uint rows, uint columns, T defaultValue = default(T))
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    array[i, j] = defaultValue;
                }
            }
        }
    }
}