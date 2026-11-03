// Tipos usados pela Rodada. São dados puros: não dependem da Unity.

/// <summary>As seis cores dos objetos (GDD 2.2, RT-74).</summary>
public enum CorDoJogo
{
    Vermelho,
    Azul,
    Verde,
    Amarelo,
    Laranja,
    Roxo
}

/// <summary>As quatro formas dos objetos (GDD 2.2, RT-72).</summary>
public enum FormaDoJogo
{
    Circulo,
    Quadrado,
    Triangulo,
    Estrela
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
