using System;
using System.Collections.Generic;

/// <summary>
/// Uma rodada: a instrução (cor, ou cor e forma) e os objetos da tela.
/// Exatamente um objeto satisfaz a instrução; os outros são distratores (RT-02).
///
/// É uma classe C# pura (não é MonoBehaviour). A instrução e os objetos não mudam depois de
/// criada; o que muda é a conta das tentativas e o fechamento:
/// - Um erro não fecha a rodada: a criança tenta de novo, quantas vezes precisar (RT-41).
/// - O acerto fecha a rodada. Se foi a primeira tentativa, ela é correta; se não, é com erro (RT-85).
/// - As tentativas são só a conta para classificar a rodada (RT-89): não aparecem para a criança
///   e não valem nada além do fechamento.
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

    /// <summary>Quantas seleções a criança fez nesta rodada, contando o acerto, se já houve.</summary>
    public int Tentativas { get; private set; }

    /// <summary>Como a rodada fechou. É null enquanto ela está aberta.</summary>
    public FechamentoDaRodada? Fechamento { get; private set; }

    /// <summary>Verdadeiro até o acerto: depois de um erro a rodada continua aberta (RT-41).</summary>
    public bool Aberta => Fechamento == null;

    /// <summary>Verdadeiro só se a rodada fechou com acerto na primeira tentativa (RT-85).</summary>
    public bool Correta => Fechamento == FechamentoDaRodada.Correta;

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
    /// Avalia uma seleção e conta a tentativa. Selecionar o alvo é acerto e fecha a rodada;
    /// qualquer outro objeto é seleção incorreta e a rodada continua aberta (RT-06, RT-41).
    /// O acerto na primeira tentativa fecha como <see cref="FechamentoDaRodada.Correta"/>;
    /// o acerto depois de um erro, como <see cref="FechamentoDaRodada.ComErro"/> (RT-85).
    /// </summary>
    /// <param name="indiceSelecionado">Posição do objeto tocado em <see cref="Objetos"/>.</param>
    /// <exception cref="InvalidOperationException">A rodada já fechou no acerto. Quem chama deve
    /// ignorar a seleção enquanto <see cref="Aberta"/> for falso (RT-77).</exception>
    public ResultadoDaSelecao Avaliar(int indiceSelecionado)
    {
        if (!Aberta)
        {
            throw new InvalidOperationException(
                "A rodada já fechou no acerto e não aceita novas seleções.");
        }

        // Índice inválido é erro de quem chama, e não uma tentativa da criança: não é contado.
        if (indiceSelecionado < 0 || indiceSelecionado >= Objetos.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(indiceSelecionado),
                indiceSelecionado,
                $"O índice deve estar entre 0 e {Objetos.Count - 1}.");
        }

        Tentativas++;

        if (indiceSelecionado != IndiceDoAlvo)
            return ResultadoDaSelecao.SelecaoIncorreta;

        Fechamento = Tentativas == 1
            ? FechamentoDaRodada.Correta
            : FechamentoDaRodada.ComErro;
        return ResultadoDaSelecao.Acerto;
    }

    private string DescreverPedido()
    {
        return Modo == ModoDeRodada.SoCor
            ? $"cor {CorAlvo}"
            : $"forma {FormaAlvo.Value}, cor {CorAlvo}";
    }
}
