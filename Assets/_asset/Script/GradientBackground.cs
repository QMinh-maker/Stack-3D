using UnityEngine;

[ExecuteAlways]
public class GradientBackground : MonoBehaviour
{
    public Camera cam;

    [Header("Colors")]
    public Color topColor = new Color(0.3f, 0.7f, 0.65f);
    public Color bottomColor = new Color(0.65f, 0.85f, 0.75f);

    private void OnEnable()
    {
        if (cam == null)
            cam = Camera.main;

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = topColor;
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

        Material mat = new Material(Shader.Find("Hidden/Internal-Colored"));
        mat.SetPass(0);

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
