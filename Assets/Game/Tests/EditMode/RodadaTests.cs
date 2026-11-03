using System;
using NUnit.Framework;

public class RodadaTests
{
    // ---------- Cenários de aceite (US-02.3) ----------

    [Test]
    public void SoCor_ClicarNaUnicaFormaVermelha_EhAcerto()
    {
        // Dado a instrução "Encontre o vermelho"
        var rodada = Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
        });

        // Quando ela clica na única forma vermelha
        var resultado = rodada.Avaliar(1);

        // Então o jogo registra acerto
        Assert.AreEqual(ResultadoDaSelecao.Acerto, resultado);
    }

    [Test]
    public void SoCor_ClicarNumaFormaAzul_EhSelecaoIncorreta()
    {
        // Mesma rodada do cenário anterior
        var rodada = Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
        });

        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(2));
    }

    [Test]
    public void CorEForma_ClicarNoQuadradoVermelhoQuandoOPedidoEEstrelaVermelha_EhSelecaoIncorreta()
    {
        // Dado o modo cor e forma: "Encontre a estrela vermelha"
        var rodada = Rodada.CriarCorEForma(CorDoJogo.Vermelho, FormaDoJogo.Estrela, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),   // mesma cor, outra forma
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Estrela),    // alvo
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Estrela),        // mesma forma, outra cor
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
        });

        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(2));
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));
    }

    // ---------- RT-02, RT-03, RT-04: exatamente um alvo ----------

    [Test]
    public void SoCor_FormasNaoImportam_AcertaPelaCor()
    {
        // RT-03: no modo só cor, o alvo é o único objeto daquela cor, qualquer que seja a forma.
        var rodada = Rodada.CriarSoCor(CorDoJogo.Azul, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Triangulo),
        });

        Assert.AreEqual(1, rodada.IndiceDoAlvo);
        Assert.IsNull(rodada.FormaAlvo);
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));
    }

    [Test]
    public void SoCor_DoisObjetosDaCorPedida_NaoEhRodadaValida()
    {
        Assert.Throws<ArgumentException>(() => Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Estrela),
        }));
    }

    [Test]
    public void CorEForma_DoisObjetosIguaisAoPedido_NaoEhRodadaValida()
    {
        Assert.Throws<ArgumentException>(() => Rodada.CriarCorEForma(CorDoJogo.Vermelho, FormaDoJogo.Estrela, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Estrela),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Estrela),
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
        }));
    }

    [Test]
    public void NenhumObjetoSatisfazAInstrucao_NaoEhRodadaValida()
    {
        Assert.Throws<ArgumentException>(() => Rodada.CriarSoCor(CorDoJogo.Roxo, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
        }));

        // Na cor e forma, só a cor ou só a forma não bastam.
        Assert.Throws<ArgumentException>(() => Rodada.CriarCorEForma(CorDoJogo.Vermelho, FormaDoJogo.Estrela, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Estrela),
        }));
    }

    [Test]
    public void ListaNulaOuVazia_NaoEhRodadaValida()
    {
        Assert.Throws<ArgumentNullException>(() => Rodada.CriarSoCor(CorDoJogo.Vermelho, null));
        Assert.Throws<ArgumentException>(() => Rodada.CriarSoCor(CorDoJogo.Vermelho, new ObjetoDaRodada[0]));
    }

    // ---------- RT-06: acerto e seleção incorreta ----------

    [Test]
    public void ApenasOAlvoAcerta_TodosOsOutrosSaoSelecaoIncorreta()
    {
        var rodada = Rodada.CriarCorEForma(CorDoJogo.Azul, FormaDoJogo.Quadrado, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Roxo, FormaDoJogo.Triangulo),
            new ObjetoDaRodada(CorDoJogo.Amarelo, FormaDoJogo.Estrela),
        });

        for (int i = 0; i < rodada.Objetos.Count; i++)
        {
            var esperado = i == 2 ? ResultadoDaSelecao.Acerto : ResultadoDaSelecao.SelecaoIncorreta;
            Assert.AreEqual(esperado, rodada.Avaliar(i), $"índice {i}");
        }
    }

    [Test]
    public void AvaliarNaoMudaARodada_DepoisDeUmErroAindaPodeAcertar()
    {
        // RT-41: depois de um erro a rodada continua aberta.
        var rodada = Rodada.CriarSoCor(CorDoJogo.Verde, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
        });

        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));
    }

    [Test]
    public void IndiceForaDaLista_LancaExcecao()
    {
        var rodada = Rodada.CriarSoCor(CorDoJogo.Verde, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
        });

        Assert.Throws<ArgumentOutOfRangeException>(() => rodada.Avaliar(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => rodada.Avaliar(2));
    }

    [Test]
    public void ListaOriginalMudandoDepois_NaoAlteraARodada()
    {
        var objetos = new System.Collections.Generic.List<ObjetoDaRodada>
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Circulo),
        };
        var rodada = Rodada.CriarSoCor(CorDoJogo.Verde, objetos);

        objetos.Clear();

        Assert.AreEqual(2, rodada.Objetos.Count);
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));
    }
}
