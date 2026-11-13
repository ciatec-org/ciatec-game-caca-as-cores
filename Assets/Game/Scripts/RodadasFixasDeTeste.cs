using System;

/// <summary>
/// PLACEHOLDER (US-02.5, T-02.5.1): sequência fixa de rodadas para a troca depois do acerto,
/// até o gerador de rodadas existir. Duas rodadas seguidas nunca têm a mesma instrução,
/// inclusive na volta do fim para o começo, para a troca ser visível ("com outra instrução").
/// </summary>
public static class RodadasFixasDeTeste
{
    public const int Quantidade = 4;

    /// <summary>
    /// Cria a rodada da posição pedida (0 a <see cref="Quantidade"/> - 1). Devolve sempre uma rodada nova,
    /// porque a Rodada guarda tentativas e fechamento.
    /// </summary>
    public static Rodada Criar(int posicao)
    {
        switch (posicao)
        {
            case 0:
                // "Encontre o vermelho"
                return Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
                {
                    new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
                    new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
                });

            case 1:
                // "Encontre a estrela vermelha": distratores com a mesma cor e com a mesma forma (G-05).
                return Rodada.CriarCorEForma(CorDoJogo.Vermelho, FormaDoJogo.Estrela, new[]
                {
                    new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Estrela),
                    new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Estrela),
                    new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
                });

            case 2:
                // "Encontre o azul"
                return Rodada.CriarSoCor(CorDoJogo.Azul, new[]
                {
                    new ObjetoDaRodada(CorDoJogo.Laranja, FormaDoJogo.Circulo),
                    new ObjetoDaRodada(CorDoJogo.Roxo, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Triangulo),
                });

            case 3:
                // "Encontre o quadrado verde": distratores com a mesma cor e com a mesma forma (G-05).
                return Rodada.CriarCorEForma(CorDoJogo.Verde, FormaDoJogo.Quadrado, new[]
                {
                    new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
                    new ObjetoDaRodada(CorDoJogo.Marrom, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Laranja, FormaDoJogo.Estrela),
                });

            default:
                throw new ArgumentOutOfRangeException(
                    nameof(posicao), posicao, $"A posição deve estar entre 0 e {Quantidade - 1}.");
        }
    }
}
