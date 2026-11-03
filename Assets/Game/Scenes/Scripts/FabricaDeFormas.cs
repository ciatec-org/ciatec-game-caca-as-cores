using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PLACEHOLDER (US-02.3, T-02.3.2): gera por código um sprite branco para cada uma
/// das quatro formas, para a cor vir do Image.color. Substituir pela arte final (seção 14 do GDD).
/// </summary>
public static class FabricaDeFormas
{
    private const int Tamanho = 128;
    private const int Amostras = 3; // subamostragem por eixo, para suavizar a borda

    private static readonly Dictionary<FormaDoJogo, Sprite> cache = new Dictionary<FormaDoJogo, Sprite>();

    // Garante que o cache não sobreviva entre execuções com "Enter Play Mode" sem domain reload.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Reiniciar() => cache.Clear();

    public static Sprite Obter(FormaDoJogo forma)
    {
        if (cache.TryGetValue(forma, out Sprite existente) && existente != null)
            return existente;

        Sprite criado = Criar(forma);
        cache[forma] = criado;
        return criado;
    }

    private static Sprite Criar(FormaDoJogo forma)
    {
        var textura = new Texture2D(Tamanho, Tamanho, TextureFormat.RGBA32, false)
        {
            name = $"Forma_{forma}",
            wrapMode = TextureWrapMode.Clamp,
            filterMode = FilterMode.Bilinear
        };

        var pixels = new Color32[Tamanho * Tamanho];
        for (int py = 0; py < Tamanho; py++)
        {
            for (int px = 0; px < Tamanho; px++)
            {
                int dentro = 0;
                for (int sy = 0; sy < Amostras; sy++)
                {
                    for (int sx = 0; sx < Amostras; sx++)
                    {
                        float x = (px + (sx + 0.5f) / Amostras) / Tamanho;
                        float y = (py + (sy + 0.5f) / Amostras) / Tamanho;
                        if (Dentro(forma, x, y))
                            dentro++;
                    }
                }

                byte alfa = (byte)(255 * dentro / (Amostras * Amostras));
                pixels[py * Tamanho + px] = new Color32(255, 255, 255, alfa);
            }
        }

        textura.SetPixels32(pixels);
        textura.Apply();

        var sprite = Sprite.Create(textura, new Rect(0, 0, Tamanho, Tamanho), new Vector2(0.5f, 0.5f), 100f);
        sprite.name = textura.name;
        return sprite;
    }

    // x e y em 0..1, com y para cima.
    private static bool Dentro(FormaDoJogo forma, float x, float y)
    {
        switch (forma)
        {
            case FormaDoJogo.Circulo:
                float dx = x - 0.5f, dy = y - 0.5f;
                return dx * dx + dy * dy <= 0.47f * 0.47f;

            case FormaDoJogo.Quadrado:
                return x >= 0.06f && x <= 0.94f && y >= 0.06f && y <= 0.94f;

            case FormaDoJogo.Triangulo:
                return DentroDoPoligono(Triangulo, x, y);

            case FormaDoJogo.Estrela:
                return DentroDoPoligono(Estrela, x, y);

            default:
                return false;
        }
    }

    private static readonly Vector2[] Triangulo =
    {
        new Vector2(0.50f, 0.95f),
        new Vector2(0.04f, 0.10f),
        new Vector2(0.96f, 0.10f)
    };

    private static readonly Vector2[] Estrela = CriarEstrela();

    private static Vector2[] CriarEstrela()
    {
        const int pontas = 5;
        const float raioExterno = 0.48f;
        const float raioInterno = 0.19f;
        var centro = new Vector2(0.5f, 0.52f);

        var pontos = new Vector2[pontas * 2];
        for (int i = 0; i < pontos.Length; i++)
        {
            float raio = (i % 2 == 0) ? raioExterno : raioInterno;
            float angulo = Mathf.PI / 2f + i * Mathf.PI / pontas; // começa apontando para cima
            pontos[i] = centro + new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo)) * raio;
        }
        return pontos;
    }

    // Ray casting: conta quantas arestas um raio horizontal cruza à direita do ponto.
    private static bool DentroDoPoligono(Vector2[] poligono, float x, float y)
    {
        bool dentro = false;
        for (int i = 0, j = poligono.Length - 1; i < poligono.Length; j = i++)
        {
            Vector2 a = poligono[i];
            Vector2 b = poligono[j];
            bool cruza = (a.y > y) != (b.y > y);
            if (cruza && x < (b.x - a.x) * (y - a.y) / (b.y - a.y) + a.x)
                dentro = !dentro;
        }
        return dentro;
    }
}
