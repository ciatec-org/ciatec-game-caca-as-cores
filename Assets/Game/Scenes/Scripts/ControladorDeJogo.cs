using UnityEngine;

public class ControladorDeJogo : MonoBehaviour
{
    public ConfiguracaoDoJogo configJogo;

    void Start()
    {
        if (configJogo == null)
        {
            Debug.LogWarning("Falta a ConfiguracaoDoJogo no ControladorDeJogo!", this);
            return;
        }

        // Imprime um dos tempos no Console para provar que o asset está sendo lido.
        Debug.Log($"Configuração carregada! O tempo limite da rodada é: {configJogo.tempoLimiteRodada} segundos.");
    }
}
