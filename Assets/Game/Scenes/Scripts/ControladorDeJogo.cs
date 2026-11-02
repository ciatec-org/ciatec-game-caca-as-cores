using UnityEngine;

public class ControladorDeJogo : MonoBehaviour
{
    public ConfiguracaoDoJogo configJogo;
    public SpriteRenderer placeholderForma;

    void Start()
    {
        if (configJogo != null && placeholderForma != null)
        {
            // Aplica a cor vermelha do asset ao placeholder
            placeholderForma.color = configJogo.corVermelho;

            // Imprime um dos tempos no Console para provar que está lendo
            Debug.Log($"Configuração carregada! O tempo limite da rodada é: {configJogo.tempoLimiteRodada} segundos.");
        }
        else
        {
            Debug.LogWarning("Faltam referências no ControladorDeJogo!");
        }
    }
}
