using UnityEngine;

// PLACEHOLDER (US-02.3): conferência manual da Rodada.
// Substituir pela tela da rodada e pelo gerador de rodadas.

public class TesteRodada : MonoBehaviour
{
    private Rodada rodada;

    void Start()
    {
        // "Encontre o vermelho"
        rodada = Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
        });
    }

    // Ligue ao OnClick de um Button da UI, passando o índice (0, 1 ou 2).
    public void Selecionar(int indice)
    {
        Debug.Log($"Objeto {indice}: {rodada.Avaliar(indice)}");
    }
}
