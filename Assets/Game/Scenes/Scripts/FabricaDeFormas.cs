using System;
using UnityEngine;

/// <summary>Resolve as formas da rodada para os sprites importados (SGDD 2.2, RT-72).</summary>
public static class FabricaDeFormas
{
    public static Sprite Obter(FormaDoJogo forma, ConfiguracaoDoJogo configuracao)
    {
        if (configuracao == null)
            throw new ArgumentNullException(nameof(configuracao));

        Sprite sprite;
        switch (forma)
        {
            case FormaDoJogo.Circulo:   sprite = configuracao.spriteCirculo; break;
            case FormaDoJogo.Quadrado:  sprite = configuracao.spriteQuadrado; break;
            case FormaDoJogo.Triangulo: sprite = configuracao.spriteTriangulo; break;
            case FormaDoJogo.Estrela:   sprite = configuracao.spriteEstrela; break;
            case FormaDoJogo.Retangulo: sprite = configuracao.spriteRetangulo; break;
            default: throw new ArgumentOutOfRangeException(nameof(forma), forma, "Forma sem sprite na rodada.");
        }

        if (sprite == null)
            throw new InvalidOperationException($"Atribua o sprite de {forma} na ConfiguracaoDoJogo.");

        return sprite;
    }
}
