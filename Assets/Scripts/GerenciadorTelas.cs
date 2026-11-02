
using UnityEngine;

public class GerenciadorDeTelas : MonoBehaviour
{
    [Header("Painéis da interface")]
    [SerializeField] private GameObject painelInicio;
    [SerializeField] private GameObject painelConfiguracoes;
    [SerializeField] private GameObject painelFases;
    [SerializeField] private GameObject painelJogo;

    private void Start()
    {
        MostrarTela("Inicio");
    }

    public void MostrarTela(string nomeTela)
    {
        GameObject telaEscolhida = null;

        switch (nomeTela)
        {
            case "Inicio":
                telaEscolhida = painelInicio;
                break;

            case "Configuracoes":
                telaEscolhida = painelConfiguracoes;
                break;

            case "Fases":
                telaEscolhida = painelFases;
                break;

            case "Jogo":
                telaEscolhida = painelJogo;
                break;

            default:
                Debug.LogWarning(
                    $"Tela '{nomeTela}' não reconhecida.",
                    this
                );
                return;
        }

        if (telaEscolhida == null)
        {
            Debug.LogWarning(
                $"O painel da tela '{nomeTela}' não foi atribuído.",
                this
            );
            return;
        }

        // Esconde todas as telas.

        if (painelInicio != null)
            painelInicio.SetActive(false);

        if (painelConfiguracoes != null)
            painelConfiguracoes.SetActive(false);

        if (painelFases != null)
            painelFases.SetActive(false);

        if (painelJogo != null)
            painelJogo.SetActive(false);

        // Mostra somente a tela solicitada.
        telaEscolhida.SetActive(true);
    }

    // Métodos para conectar aos botões pelo Inspector.

    public void AbrirInicio()
    {
        MostrarTela("Inicio");
    }

    public void AbrirConfiguracoes()
    {
        MostrarTela("Configuracoes");
    }

    public void AbrirFases()
    {
        MostrarTela("Fases");
    }

    public void AbrirJogo()
    {
        MostrarTela("Jogo");
    }


    public void TestarNomeInvalido()
    {
        MostrarTela("Inventario");
    }

}
