using System;
using System.Collections.Generic;

/// <summary>
/// Uma rodada: a instrução (cor, ou cor e forma) e os objetos da tela.
/// Exatamente um objeto satisfaz a instrução; os outros são distratores (RT-02).
///
/// É uma classe C# pura (não é MonoBehaviour) e imutável depois de criada:
/// o sorteio monta a rodada, e a tela só pergunta se a escolha acerta.
/// Quem sorteia (gerador de rodadas) e quem registra (telemetria) ficam fora dela.
/// </summary>
public class Rodada
{
    public ModoDeRodada Modo { get; }

    /// <summary>A cor pedida pela instrução, nos dois modos.</summary>
    public CorDoJogo CorAlvo { get; }

    /// <summary>A forma pedida. Só existe no modo cor e forma; no modo só cor é null.</summary>
    public FormaDoJogo? FormaAlvo { get; }

    /// <summary>Os objetos, na ordem do sorteio (RT-127).</summary>
    public IReadOnlyList<ObjetoDaRodada> Objetos { get; }

    /// <summary>Posição do alvo em <see cref="Objetos"/>.</summary>
    public int IndiceDoAlvo { get; }

    /// <summary>O único objeto que satisfaz a instrução.</summary>
    public ObjetoDaRodada Alvo => Objetos[IndiceDoAlvo];

    /// <summary>Modo só cor: "Encontre o vermelho". As formas não importam (RT-03).</summary>
    public static Rodada CriarSoCor(CorDoJogo corAlvo, IEnumerable<ObjetoDaRodada> objetos)
    {
        return new Rodada(ModoDeRodada.SoCor, corAlvo, null, objetos);
    }

    /// <summary>Modo cor e forma: "Encontre a estrela vermelha". O alvo tem as duas (RT-04).</summary>
    public static Rodada CriarCorEForma(CorDoJogo corAlvo, FormaDoJogo formaAlvo, IEnumerable<ObjetoDaRodada> objetos)
    {
        return new Rodada(ModoDeRodada.CorEForma, corAlvo, formaAlvo, objetos);
    }

    private Rodada(ModoDeRodada modo, CorDoJogo corAlvo, FormaDoJogo? formaAlvo, IEnumerable<ObjetoDaRodada> objetos)
    {
        if (objetos == null)
            throw new ArgumentNullException(nameof(objetos));

        Modo = modo;
        CorAlvo = corAlvo;
        FormaAlvo = formaAlvo;

        // Copia, para a lista não mudar por fora depois de validada.
        var lista = new List<ObjetoDaRodada>(objetos);
        if (lista.Count == 0)
            throw new ArgumentException("A rodada precisa de ao menos um objeto.", nameof(objetos));

        // RT-02: exatamente um objeto satisfaz a instrução.
        int indice = -1;
        int quantosSatisfazem = 0;
        for (int i = 0; i < lista.Count; i++)
        {
            if (Satisfaz(lista[i]))
            {
                quantosSatisfazem++;
                indice = i;
            }
        }

        if (quantosSatisfazem != 1)
        {
            throw new ArgumentException(
                $"Rodada inválida: {quantosSatisfazem} objetos satisfazem a instrução ({DescreverPedido()}), " +
                "e deve haver exatamente um (RT-02).",
                nameof(objetos));
        }

        Objetos = lista.AsReadOnly();
        IndiceDoAlvo = indice;
    }

    /// <summary>
    /// Diz se o objeto satisfaz a instrução desta rodada.
    /// Só cor: a cor basta. Cor e forma: precisa das duas.
    /// </summary>
    public bool Satisfaz(ObjetoDaRodada objeto)
    {
        if (objeto.Cor != CorAlvo)
            return false;

        return Modo == ModoDeRodada.SoCor || objeto.Forma == FormaAlvo.Value;
    }

    /// <summary>
    /// O método que diz se a escolha acerta (RT-06): selecionar o alvo é acerto,
    /// e qualquer outro objeto é seleção incorreta. Não muda o estado da rodada:
    /// depois de um erro a rodada continua aberta (RT-41).
    /// </summary>
    /// <param name="indiceSelecionado">Posição do objeto tocado em <see cref="Objetos"/>.</param>
    public ResultadoDaSelecao Avaliar(int indiceSelecionado)
    {
        if (indiceSelecionado < 0 || indiceSelecionado >= Objetos.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(indiceSelecionado),
                indiceSelecionado,
                $"O índice deve estar entre 0 e {Objetos.Count - 1}.");
        }

        return indiceSelecionado == IndiceDoAlvo
            ? ResultadoDaSelecao.Acerto
            : ResultadoDaSelecao.SelecaoIncorreta;
    }

    private string DescreverPedido()
    {
        return Modo == ModoDeRodada.SoCor
            ? $"cor {CorAlvo}"
            : $"forma {FormaAlvo.Value}, cor {CorAlvo}";
    }
}
