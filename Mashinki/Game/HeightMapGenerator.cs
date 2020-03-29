using System;

namespace Mashinki.Game
{
    static class HeightMapGenerator
    {
        public static float[,] GetHeightMap(float minHeight, float maxHeight, uint width, uint height)
        {
            var randomizer = new Random(5521);
            float[,] result = new float[width, height];
            float left;
            float up;
            float ru;
            float min = float.MaxValue;
            float max = float.MinValue;
            uint n = 0;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (i > 0)
                    {
                        left = result[i - 1, j];
                        n++;
                    }
                    else
                    {
                        left = 0;
                    }
                    if (j > 0)
                    {
                        up = result[i, j - 1];
                        n++;
                    }
                    else
                    {
                        up = 0;
                    }
                    if (j > 0 && i < width - 1)
                    {
                        ru = result[i + 1, j - 1];
                        n++;
                    }
                    else
                    {
                        ru = 0;
                    }
                    if (n != 0)
                    {
                        result[i, j] = (left + up + ru) / n + ((float)randomizer.NextDouble() - 0.51f);
                        if (result[i, j] > max) max = result[i, j];
                        if (result[i, j] < min) min = result[i, j];
                    }
                    else
                    {
                        result[i, j] = (float)randomizer.NextDouble();
                    }
                    n = 0;
                }
            }

            max = max - min + minHeight;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    result[i, j] = (result[i, j] - min + minHeight) * maxHeight / max;
                }
            }

            return result;
        }

        public static float[,] GetHeightMap2(float minHeight, float maxHeight, uint width, uint height)
        {
            float smoothnessX = 0.1f;
            float smoothnessY = 0.3f;

            var randomizer = new Random(5521);
            float[,] result = new float[width, height];
            float[] xFunc = new float[width];
            xFunc[0] = minHeight + (float)randomizer.NextDouble() * (maxHeight - minHeight);
            for (int i = 1; i < 1000; i++)
            {
                xFunc[i] = xFunc[i - 1] + smoothnessX * ((float)randomizer.NextDouble() - 0.5f);
                if (xFunc[i] > maxHeight) xFunc[i] = maxHeight;
                if (xFunc[i] < minHeight) xFunc[i] = minHeight;
            }
            float[] yFunc = new float[height];
            yFunc[0] = minHeight + (float)randomizer.NextDouble() * (maxHeight - minHeight);
            for (int i = 1; i < 1000; i++)
            {
                yFunc[i] = yFunc[i - 1] + smoothnessY * ((float)randomizer.NextDouble() - 0.5f);
                if (yFunc[i] > maxHeight) yFunc[i] = maxHeight;
                if (yFunc[i] < minHeight) yFunc[i] = minHeight;
            }

            for (int j = 0; j < 1000; j++)
            {
                for (int i = 0; i < 1000; i++)
                {
                    result[i, j] = (xFunc[i] + yFunc[j]) / 2f;
                }
            }

            return result;
        }
    }
}
