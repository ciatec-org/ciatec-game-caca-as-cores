// Tipos usados pela Rodada. São dados puros: não dependem da Unity.

/// <summary>As seis cores dos objetos (GDD 2.2, RT-74).</summary>
public enum CorDoJogo
{
    Vermelho = 0,
    Azul = 1,
    Verde = 2,
    // O índice 3 passa de amarelo a marrom com a paleta aprovada no SGDD v2.12.
    Marrom = 3,
    Laranja = 4,
    Roxo = 5
}

/// <summary>As cinco formas dos objetos (GDD 2.2, RT-72).</summary>
public enum FormaDoJogo
{
    Circulo = 0,
    Quadrado = 1,
    Triangulo = 2,
    Estrela = 3,
    Retangulo = 4
}

/// <summary>Os dois modos da rodada, e só dois (GDD 2.2).</summary>
public enum ModoDeRodada
{
    /// <summary>A instrução nomeia só a cor (RT-03).</summary>
    SoCor,

    /// <summary>A instrução nomeia a forma e a cor (RT-04).</summary>
    CorEForma
}

/// <summary>O que o jogo registra quando a criança seleciona um objeto (RT-06).</summary>
public enum ResultadoDaSelecao
{
    Acerto,
    SelecaoIncorreta
}

/// <summary>
/// Como a rodada fechou no acerto (GDD 13.3). As outras duas categorias, não resolvida e omissão,
/// são das rodadas que fecham sem acerto (tempo limite ou saída) e entram com essas histórias.
/// </summary>
public enum FechamentoDaRodada
{
    /// <summary>Acertou na primeira tentativa. Só esta conta para o portão (RT-85).</summary>
    Correta,

    /// <summary>Errou e depois acertou. Não conta como correta (RT-85).</summary>
    ComErro
}

/// <summary>Um objeto da rodada: só o que ele é (cor e forma), sem posição (RT-127).</summary>
public readonly struct ObjetoDaRodada
{
    public CorDoJogo Cor { get; }
    public FormaDoJogo Forma { get; }

    public ObjetoDaRodada(CorDoJogo cor, FormaDoJogo forma)
    {
        Cor = cor;
        Forma = forma;
    }

    public override string ToString() => $"{Forma} {Cor}";
}
