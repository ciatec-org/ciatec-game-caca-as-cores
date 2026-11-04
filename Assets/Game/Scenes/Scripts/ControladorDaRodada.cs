using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Controlador fino da rodada (US-02.3, T-02.3.2 e T-02.3.3).
///
/// - Põe os objetos da <see cref="Rodada"/> numa fileira simples, provisória até o layout do EP-06.
/// - Liga o clique (ou toque) de cada forma à regra: <see cref="Rodada.Avaliar"/>.
/// - Mostra o resultado em texto, sem usar cor (RT-102).
///
/// Não decide nada de regra: quem diz se acertou é a Rodada. O clique é o do uGUI
/// (Button), um gesto só: sem arrastar, segurar nem duplo clique (RT-11, RT-12),
/// e não usa câmera, microfone nem outro sensor (RT-13).
///
/// PLACEHOLDER: a rodada vem de um exemplo escolhido no Inspector até o gerador de rodadas existir.
/// </summary>
public class ControladorDaRodada : MonoBehaviour
{
    public enum RodadaDeExemplo
    {
        SoCorVermelho,
        CorEFormaEstrelaVermelha
    }

    [Header("Referências")]
    [SerializeField] private ConfiguracaoDoJogo configuracao;

    [Header("Rodada de exemplo (provisório)")]
    [SerializeField] private RodadaDeExemplo rodadaDeExemplo = RodadaDeExemplo.SoCorVermelho;

    [Header("Fileira provisória")]
    [SerializeField] private float tamanhoDaForma = 200f;
    [SerializeField] private float espacamento = 40f;

    /// <summary>Disparado a cada seleção, com o índice do objeto e o resultado.</summary>
    public event Action<int, ResultadoDaSelecao> SelecaoAvaliada;

    public Rodada RodadaAtual { get; private set; }

    private RectTransform fileira;
    private TextMeshProUGUI textoInstrucao;
    private TextMeshProUGUI textoResultado;

    private void Start()
    {
        if (configuracao == null)
        {
            Debug.LogWarning("ControladorDaRodada: atribua a ConfiguracaoDoJogo no Inspector.", this);
            return;
        }

        if (FindFirstObjectByType<EventSystem>() == null)
            Debug.LogWarning("ControladorDaRodada: não há EventSystem na cena, e sem ele o clique não chega.", this);

        CriarInterface();
        IniciarRodada(MontarRodadaDeExemplo());
    }

    /// <summary>Mostra a rodada na tela e liga cada forma à regra.</summary>
    public void IniciarRodada(Rodada rodada)
    {
        if (rodada == null)
            throw new ArgumentNullException(nameof(rodada));

        RodadaAtual = rodada;

        foreach (Transform filho in fileira)
            Destroy(filho.gameObject);

        textoInstrucao.text = MontarInstrucao(rodada);
        textoResultado.text = string.Empty;

        for (int i = 0; i < rodada.Objetos.Count; i++)
            CriarForma(i, rodada.Objetos[i]);
    }

    private void CriarForma(int indice, ObjetoDaRodada objeto)
    {
        var go = new GameObject($"Forma{indice}_{objeto.Forma}_{objeto.Cor}", typeof(RectTransform), typeof(Image), typeof(Button));
        go.transform.SetParent(fileira, false);

        var rect = (RectTransform)go.transform;
        rect.sizeDelta = new Vector2(tamanhoDaForma, tamanhoDaForma);

        var imagem = go.GetComponent<Image>();
        imagem.sprite = FabricaDeFormas.Obter(objeto.Forma);
        imagem.color = configuracao.ObterCor(objeto.Cor);

        // O índice vem do próprio objeto, e não digitado à mão.
        int indiceDaForma = indice;
        go.GetComponent<Button>().onClick.AddListener(() => AoSelecionar(indiceDaForma));
    }

    private void AoSelecionar(int indice)
    {
        ResultadoDaSelecao resultado = RodadaAtual.Avaliar(indice);

        textoResultado.text = resultado == ResultadoDaSelecao.Acerto
            ? "Acerto!"
            : "Seleção incorreta";

        Debug.Log($"[Rodada] {RodadaAtual.Objetos[indice]} (índice {indice}) → {resultado}");
        SelecaoAvaliada?.Invoke(indice, resultado);
    }

    // ---------- Rodadas de exemplo ----------

    private Rodada MontarRodadaDeExemplo()
    {
        switch (rodadaDeExemplo)
        {
            case RodadaDeExemplo.CorEFormaEstrelaVermelha:
                // "Encontre a estrela vermelha": distratores com a mesma cor e com a mesma forma (G-05).
                return Rodada.CriarCorEForma(CorDoJogo.Vermelho, FormaDoJogo.Estrela, new[]
                {
                    new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Estrela),
                    new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Estrela),
                    new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
                });

            default:
                // "Encontre o vermelho"
                return Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
                {
                    new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
                    new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
                    new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
                });
        }
    }

    // PROVISÓRIO: o texto final da instrução é da US-02.2 (RT-90). Existe aqui só para a
    // conferência jogando saber o que foi pedido.
    private static string MontarInstrucao(Rodada rodada)
    {
        bool corFeminina = rodada.FormaAlvo == FormaDoJogo.Estrela;
        string cor = NomeDaCor(rodada.CorAlvo, corFeminina);

        if (rodada.Modo == ModoDeRodada.SoCor)
            return $"Encontre o {cor}";

        FormaDoJogo forma = rodada.FormaAlvo.Value;
        string artigo = forma == FormaDoJogo.Estrela ? "a" : "o";
        return $"Encontre {artigo} {NomeDaForma(forma)} {cor}";
    }

    private static string NomeDaForma(FormaDoJogo forma)
    {
        switch (forma)
        {
            case FormaDoJogo.Circulo:   return "círculo";
            case FormaDoJogo.Quadrado:  return "quadrado";
            case FormaDoJogo.Triangulo: return "triângulo";
            default:                    return "estrela";
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
            default:                 return "laranja";
        }
    }

    // ---------- Interface provisória, montada por código ----------

    private void CriarInterface()
    {
        var canvasGo = new GameObject("Canvas_Rodada", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        canvasGo.transform.SetParent(transform, false);

        var canvas = canvasGo.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        var escala = canvasGo.GetComponent<CanvasScaler>();
        escala.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        escala.referenceResolution = new Vector2(1920f, 1080f);
        escala.matchWidthOrHeight = 0.5f;

        // Fileira: ocupa a tela e centraliza as formas.
        var fileiraGo = new GameObject("Fileira", typeof(RectTransform), typeof(HorizontalLayoutGroup));
        fileiraGo.transform.SetParent(canvasGo.transform, false);
        fileira = (RectTransform)fileiraGo.transform;
        Esticar(fileira);

        var layout = fileiraGo.GetComponent<HorizontalLayoutGroup>();
        layout.childAlignment = TextAnchor.MiddleCenter;
        layout.spacing = espacamento;
        layout.childControlWidth = false;
        layout.childControlHeight = false;
        layout.childForceExpandWidth = false;
        layout.childForceExpandHeight = false;

        textoInstrucao = CriarTexto("Instrucao", canvasGo.transform, 72f, new Vector2(0.5f, 1f), new Vector2(0f, -140f));
        textoResultado = CriarTexto("Resultado", canvasGo.transform, 64f, new Vector2(0.5f, 0f), new Vector2(0f, 140f));
    }

    private static TextMeshProUGUI CriarTexto(string nome, Transform pai, float tamanhoDaFonte, Vector2 ancora, Vector2 posicao)
    {
        var go = new GameObject(nome, typeof(RectTransform), typeof(TextMeshProUGUI));
        go.transform.SetParent(pai, false);

        var rect = (RectTransform)go.transform;
        rect.anchorMin = ancora;
        rect.anchorMax = ancora;
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = posicao;
        rect.sizeDelta = new Vector2(1600f, 120f);

        var texto = go.GetComponent<TextMeshProUGUI>();
        texto.fontSize = tamanhoDaFonte;
        texto.alignment = TextAlignmentOptions.Center;
        texto.color = Color.black;
        texto.raycastTarget = false; // o texto não rouba o clique das formas
        return texto;
    }

    private static void Esticar(RectTransform rect)
    {
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }
}
