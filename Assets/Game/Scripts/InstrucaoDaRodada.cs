using System;

/// <summary>Monta o texto da rodada de acordo com o SGDD 9.2 (RT-90).</summary>
public static class InstrucaoDaRodada
{
    public static string Montar(Rodada rodada)
    {
        if (rodada == null)
            throw new ArgumentNullException(nameof(rodada));

        if (rodada.Modo == ModoDeRodada.SoCor)
            return $"Encontre o {NomeDaCor(rodada.CorAlvo, feminino: false)}";

        FormaDoJogo forma = rodada.FormaAlvo.Value;
        bool feminino = forma == FormaDoJogo.Estrela;
        string artigo = feminino ? "a" : "o";
        return $"Encontre {artigo} {NomeDaForma(forma)} {NomeDaCor(rodada.CorAlvo, feminino)}";
    }

    private static string NomeDaForma(FormaDoJogo forma)
    {
        switch (forma)
        {
            case FormaDoJogo.Circulo:   return "círculo";
            case FormaDoJogo.Quadrado:  return "quadrado";
            case FormaDoJogo.Triangulo: return "triângulo";
            case FormaDoJogo.Estrela:   return "estrela";
            default: throw new ArgumentOutOfRangeException(nameof(forma), forma, "Forma sem nome na instrução.");
        }
    }

    private static string NomeDaCor(CorDoJogo cor, bool feminino)
    {
        switch (cor)
        {
            case CorDoJogo.Vermelho: return feminino ? "vermelha" : "vermelho";
            case CorDoJogo.Amarelo:  return feminino ? "amarela" : "amarelo";
            case CorDoJogo.Roxo:     return feminino ? "roxa" : "roxo";
            case CorDoJogo.Azul:     return "azul";
            case CorDoJogo.Verde:    return "verde";
            case CorDoJogo.Laranja:  return "laranja";
            default: throw new ArgumentOutOfRangeException(nameof(cor), cor, "Cor sem nome na instrução.");
        }
    }
}
