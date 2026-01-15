using UnityEngine;

[ExecuteAlways]
public class GradientBackground : MonoBehaviour
{
    public Camera cam;

    [Header("Gradient Palettes (Top Color)")]
    [SerializeField] private Color[] topColors =
    {
        new Color(0.3f, 0.7f, 0.65f), // xanh ngọc
        new Color(0.55f, 0.45f, 0.85f), // tím
        new Color(0.2f, 0.6f, 0.9f), // xanh dương
        new Color(0.9f, 0.4f, 0.4f), // đỏ
        new Color(0.95f, 0.7f, 0.3f), // cam
        new Color(0.3f, 0.8f, 0.4f), // xanh lá
        new Color(0.9f, 0.3f, 0.7f), // hồng
        new Color(0.6f, 0.6f, 0.6f)  // xám
    };

    [Header("Gradient Strength")]
    [Range(0.1f, 0.5f)]
    [SerializeField] private float lightenAmount = 0.25f;

    private Color topColor;
    private Color bottomColor;

    private Material gradientMat;

    private void OnEnable()
    {
        if (cam == null)
            cam = Camera.main;

        if (gradientMat == null)
            gradientMat = new Material(Shader.Find("Hidden/Internal-Colored"));

        PickRandomGradient();

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = topColor;
    }

    private void PickRandomGradient()
    {
        topColor = topColors[Random.Range(0, topColors.Length)];
        bottomColor = LightenColor(topColor, lightenAmount);
    }

    private Color LightenColor(Color color, float amount)
    {
        return Color.Lerp(color, Color.white, amount);
    }

    private void OnPreRender()
    {
        GL.Clear(true, true, topColor);
    }

    private void OnPostRender()
    {
        DrawGradient();
    }

    void DrawGradient()
    {
        GL.PushMatrix();
        GL.LoadOrtho();

        gradientMat.SetPass(0);

        GL.Begin(GL.QUADS);

        // Trên (đậm)
        GL.Color(topColor);
        GL.Vertex3(0, 1, 0);
        GL.Vertex3(1, 1, 0);

        // Dưới (nhạt)
        GL.Color(bottomColor);
        GL.Vertex3(1, 0, 0);
        GL.Vertex3(0, 0, 0);

        GL.End();
        GL.PopMatrix();
    }
}
