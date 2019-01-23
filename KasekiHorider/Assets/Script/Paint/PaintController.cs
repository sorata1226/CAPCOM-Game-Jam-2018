using UnityEngine;
using System.Collections;

public class PaintController : MonoBehaviour
{

    Texture2D drawTexture;
    Color[] buffer;

    void Start()
    {
        var spriteRend = GetComponent<SpriteRenderer>();
        Texture2D mainTexture = spriteRend.sprite.texture;
        Color[] pixels = mainTexture.GetPixels();

        buffer = new Color[pixels.Length];
        pixels.CopyTo(buffer, 0);

        // 画面上半分を塗りつぶす
        for (int x = 0; x < mainTexture.width; x++)
        {
            for (int y = 0; y < mainTexture.height; y++)
            {
                if (y < mainTexture.height / 2)
                {
                    buffer.SetValue(Color.black, x + 256 * y);
                }
            }
        }

        drawTexture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        drawTexture.filterMode = FilterMode.Point;
    }

    void Update()
    {
        drawTexture.SetPixels(buffer);
        drawTexture.Apply();
        GetComponent<Renderer>().material.mainTexture = drawTexture;
    }
}