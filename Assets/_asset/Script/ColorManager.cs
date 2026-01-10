using UnityEngine;

public static class ColorManager
{
    public static int cubeIndex = 0;
    public static float currentHue;
    public static Color currentColor;

    public static Color GetNextColor()
    {
        // Cube đầu tiên (StartCube)
        if (cubeIndex == 0)
        {
            currentHue = Random.value;
        }

        int step = cubeIndex % 7;

        // Mỗi chu kỳ 7 cube → đổi hue nhẹ
        if (step == 0 && cubeIndex != 0)
        {
            currentHue += Random.Range(0.08f, 0.15f);
            if (currentHue > 1f) currentHue -= 1f;
        }

        float value = Mathf.Lerp(0.55f, 0.9f, step / 6f);

        cubeIndex++;

        currentColor = Color.HSVToRGB(currentHue, 0.6f, value);
        return currentColor;
    }

    public static void Reset()
    {
        cubeIndex = 0;
    }
}
