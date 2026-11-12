using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfiguracaoDoJogo", menuName = "CacaAsCores/ConfiguracaoDoJogo")]
public class ConfiguracaoDoJogo : ScriptableObject
{
    [Header("Cores — assets da paleta aprovada (SGDD 2.2)")]
    public ColorData corVermelho;
    public ColorData corAzul;
    public ColorData corVerde;
    public ColorData corMarrom;
    public ColorData corLaranja;
    public ColorData corRoxo;

    [Header("Sprites das cinco formas (SGDD 2.2)")]
    public Sprite spriteCirculo;
    public Sprite spriteQuadrado;
    public Sprite spriteTriangulo;
    public Sprite spriteEstrela;
    public Sprite spriteRetangulo;

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

    /// <summary>A cor configurada para cada uma das seis cores do jogo (RT-61).</summary>
    public Color ObterCor(CorDoJogo cor)
    {
        ColorData dados;
        switch (cor)
        {
            case CorDoJogo.Vermelho: dados = corVermelho; break;
            case CorDoJogo.Azul:     dados = corAzul; break;
            case CorDoJogo.Verde:    dados = corVerde; break;
            case CorDoJogo.Marrom:   dados = corMarrom; break;
            case CorDoJogo.Laranja:  dados = corLaranja; break;
            case CorDoJogo.Roxo:     dados = corRoxo; break;
            default:
                Debug.LogWarning($"Cor '{cor}' sem valor configurado.", this);
                return Color.white;
        }

        if (dados == null)
            throw new InvalidOperationException($"Atribua o ColorData de {cor} na ConfiguracaoDoJogo.");

        return dados.color;
    }
}
