using UnityEngine;

public class ImageFader : MonoBehaviour
{
    public float alpha = 1f;

    private Shader fadeShader = null;
    private Material fadeMaterial = null;

    void Awake()
    {
        fadeMaterial = (fadeShader != null) ? new Material(fadeShader) : new Material(Shader.Find("Transparent/Diffuse"));
    }

    void OnDestroy()
    {
        if (fadeMaterial != null)
        {
            Destroy(fadeMaterial);
        }
    }

    void OnPostRender()
    {
        if (alpha != 0)
        {
            fadeMaterial.color = new Color(0f, 0f, 0f, alpha);

            fadeMaterial.SetPass(0);
            GL.PushMatrix();
            GL.LoadOrtho();
            GL.Color(fadeMaterial.color);
            GL.Begin(GL.QUADS);
            GL.Vertex3(0f, 0f, -12f);
            GL.Vertex3(0f, 1f, -12f);
            GL.Vertex3(1f, 1f, -12f);
            GL.Vertex3(1f, 0f, -12f);
            GL.End();
            GL.PopMatrix();
        }
    }
}