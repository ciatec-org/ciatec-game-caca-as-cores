using UnityEngine;

[CreateAssetMenu(fileName = "ConfiguracaoDoJogo", menuName = "CacaAsCores/ConfiguracaoDoJogo")]
public class ConfiguracaoDoJogo : ScriptableObject
{
    [Header("Cores (Recomendação Seção 2.2)")]
    public Color corVermelho = Color.red;
    public Color corAzul = Color.blue;
    public Color corVerde = Color.green;
    public Color corAmarelo = Color.yellow;
    public Color corLaranja = new Color(1f, 0.5f, 0f);
    public Color corRoxo = new Color(0.5f, 0f, 0.5f);

    [Header("Tempos - Acerto (Seção 8.1)")]
    [Tooltip("Tempo para o alvo crescer de 1 para 1,1 vez (300 ms)")]
    public float tempoCrescimentoAcerto = 0.3f;
    [Tooltip("Duração dos brilhos claros (600 ms)")]
    public float tempoBrilhosAcerto = 0.6f;
    [Tooltip("Tempo de espera até a troca começar (500 ms)")]
    public float esperaTrocaRodada = 0.5f;

    [Header("Tempos - Troca de Rodada (Seção 8.1)")]
    [Tooltip("Tempo de saída/encolhimento das formas antigas (250 ms)")]
    public float tempoSaidaTroca = 0.25f;
    [Tooltip("Tempo de entrada/crescimento das formas novas (250 ms)")]
    public float tempoEntradaTroca = 0.25f;

    [Header("Tempos - Erro (Seção 8.1)")]
    [Tooltip("Tempo total de ir e voltar no balanço e esmaecimento (400 ms)")]
    public float tempoAnimacaoErro = 0.4f;

    [Header("Tempos - Limite e Alvo (Seções 7.3 e 8.1)")]
    [Tooltip("Duração do tempo limite quando ligado (15 s)")]
    public float tempoLimiteRodada = 15.0f;
    [Tooltip("Tempo em que o alvo pulsa após o tempo esgotar (1 s)")]
    public float tempoPulsoAlvo = 1.0f;

    [Header("Tempos - Interface (Seção 7.4)")]
    [Tooltip("Tempo de reação visual de objetos e botões ao clique (80 ms)")]
    public float tempoRespostaBotao = 0.08f;
}
