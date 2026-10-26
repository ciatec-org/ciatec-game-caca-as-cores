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
    [Tooltip("Tempo para o alvo crescer de 1 para 1,1 vez")]
    public float tempoCrescimentoAcerto = 0.3f;   // 300 ms
    [Tooltip("Duração dos brilhos claros")]
    public float tempoBrilhosAcerto = 0.6f;       // 600 ms
    [Tooltip("Tempo de espera até a troca começar")]
    public float esperaTrocaRodada = 0.5f;        // 500 ms

    [Header("Tempos - Troca de Rodada (Seção 8.1)")]
    [Tooltip("Tempo de saída/encolhimento das formas antigas")]
    public float tempoSaidaTroca = 0.25f;         // 250 ms
    [Tooltip("Tempo de entrada/crescimento das formas novas")]
    public float tempoEntradaTroca = 0.25f;       // 250 ms

    [Header("Tempos - Erro (Seção 8.1)")]
    [Tooltip("Tempo total de ir e voltar (balanço e esmaecimento)")]
    public float tempoAnimacaoErro = 0.4f;        // 400 ms

    [Header("Tempos - Limite e Alvo (Seções 7.3 e 8.1)")]
    [Tooltip("Duração do tempo limite (quando ligado)")]
    public float tempoLimiteRodada = 15.0f;       // 15 s
    [Tooltip("Tempo em que o alvo pulsa após o tempo esgotar")]
    public float tempoPulsoAlvo = 1.0f;           // 1 s

    [Header("Tempos - Interface")]
    [Tooltip("Tempo de reação visual de objetos e botões ao clique")]
    public float tempoRespostaBotao = 0.08f;      // 80 ms
}
