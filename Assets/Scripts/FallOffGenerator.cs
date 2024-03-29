using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FallOffGenerator
{
    public static float[,] GenerateFalloffMap(int height, int width) {
        float[,] map = new float[width, height];
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                float x = j/(float)height * 2 - 1;
                float y = i/(float)width * 2 - 1;

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                map[i, j] = Evaluate(value);
            }
        }

        return map;
    }

    static float Evaluate(float value) {
        float a = 3;
        float b = 4.2f;

        return Mathf.Pow(value,a)/(Mathf.Pow(value,a) + Mathf.Pow(b-b*value,a));
    }
}
