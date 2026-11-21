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
            new ObjetoDaRodada(CorDoJogo.Marrom, FormaDoJogo.Estrela),
        });

        // O acerto fecha a rodada, então cada índice é avaliado numa rodada nova.
        for (int i = 0; i < rodada.Objetos.Count; i++)
        {
            var nova = Rodada.CriarCorEForma(rodada.CorAlvo, rodada.FormaAlvo.Value, rodada.Objetos);
            var esperado = i == 2 ? ResultadoDaSelecao.Acerto : ResultadoDaSelecao.SelecaoIncorreta;
            Assert.AreEqual(esperado, nova.Avaliar(i), $"índice {i}");
        }
    }

    [Test]
    public void DepoisDeUmErro_ARodadaContinuaAbertaEAindaPodeAcertar()
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

    // ---------- US-02.4: errar e tentar de novo (RT-41, RT-85, RT-89) ----------

    private static Rodada CriarRodadaComTresObjetos()
    {
        // 0 círculo azul, 1 quadrado vermelho (alvo), 2 estrela verde
        return Rodada.CriarSoCor(CorDoJogo.Vermelho, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Circulo),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Verde, FormaDoJogo.Estrela),
        });
    }

    [Test]
    public void RodadaNova_ComecaAbertaESemTentativas()
    {
        var rodada = CriarRodadaComTresObjetos();

        Assert.IsTrue(rodada.Aberta);
        Assert.AreEqual(0, rodada.Tentativas);
        Assert.IsNull(rodada.Fechamento);
        Assert.IsFalse(rodada.Correta);
    }

    [Test]
    public void OutroClique_DepoisDeUmErro_EAceitoEConferidoDeNovo()
    {
        var rodada = CriarRodadaComTresObjetos();

        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.IsTrue(rodada.Aberta);

        // Dado uma seleção incorreta, quando clica em outra forma, o jogo aceita e confere de novo.
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(2));
        Assert.IsTrue(rodada.Aberta);
        Assert.AreEqual(2, rodada.Tentativas);
    }

    [Test]
    public void MesmoObjetoErradoDeNovo_TambemEAceito()
    {
        var rodada = CriarRodadaComTresObjetos();

        rodada.Avaliar(0);
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(2, rodada.Tentativas);
        Assert.IsTrue(rodada.Aberta);
    }

    [Test]
    public void AcertoDePrimeira_FechaComoCorreta()
    {
        var rodada = CriarRodadaComTresObjetos();

        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));

        Assert.IsFalse(rodada.Aberta);
        Assert.AreEqual(1, rodada.Tentativas);
        Assert.AreEqual(FechamentoDaRodada.Correta, rodada.Fechamento);
        Assert.IsTrue(rodada.Correta);
    }

    [Test]
    public void AcertoNaSegunda_FechaComErro_ENaoComoCorreta()
    {
        var rodada = CriarRodadaComTresObjetos();

        rodada.Avaliar(0);
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));

        Assert.IsFalse(rodada.Aberta);
        Assert.AreEqual(2, rodada.Tentativas);
        Assert.AreEqual(FechamentoDaRodada.ComErro, rodada.Fechamento);
        Assert.IsFalse(rodada.Correta);
    }

    [Test]
    public void AcertoDepoisDeVariosErros_TambemFechaComErro()
    {
        var rodada = CriarRodadaComTresObjetos();

        rodada.Avaliar(0);
        rodada.Avaliar(2);
        rodada.Avaliar(0);
        rodada.Avaliar(1);

        Assert.AreEqual(4, rodada.Tentativas);
        Assert.AreEqual(FechamentoDaRodada.ComErro, rodada.Fechamento);
    }

    [Test]
    public void ErroNaoFechaARodada_NemMarcaFechamento()
    {
        var rodada = CriarRodadaComTresObjetos();

        rodada.Avaliar(0);

        Assert.IsTrue(rodada.Aberta);
        Assert.IsNull(rodada.Fechamento);
        Assert.IsFalse(rodada.Correta);
    }

    [Test]
    public void DepoisDoAcerto_AvaliarLancaExcecao_ENaoContaTentativa()
    {
        var rodada = CriarRodadaComTresObjetos();
        rodada.Avaliar(1);

        Assert.Throws<InvalidOperationException>(() => rodada.Avaliar(0));
        Assert.Throws<InvalidOperationException>(() => rodada.Avaliar(1));

        Assert.AreEqual(1, rodada.Tentativas);
        Assert.AreEqual(FechamentoDaRodada.Correta, rodada.Fechamento);
    }

    [Test]
    public void IndiceInvalido_NaoContaComoTentativa()
    {
        var rodada = CriarRodadaComTresObjetos();

        Assert.Throws<ArgumentOutOfRangeException>(() => rodada.Avaliar(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => rodada.Avaliar(3));

        Assert.AreEqual(0, rodada.Tentativas);
        Assert.IsTrue(rodada.Aberta);
    }

    [Test]
    public void ModoCorEForma_AcertoNaSegunda_TambemEComErro()
    {
        var rodada = Rodada.CriarCorEForma(CorDoJogo.Vermelho, FormaDoJogo.Estrela, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Vermelho, FormaDoJogo.Estrela),
        });

        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(1));
        Assert.AreEqual(FechamentoDaRodada.ComErro, rodada.Fechamento);
    }

    [Test]
    public void RetanguloMarrom_ExigeCorEFormaEPreservaTentativasEFechamento()
    {
        var rodada = Rodada.CriarCorEForma(CorDoJogo.Marrom, FormaDoJogo.Retangulo, new[]
        {
            new ObjetoDaRodada(CorDoJogo.Marrom, FormaDoJogo.Quadrado),
            new ObjetoDaRodada(CorDoJogo.Azul, FormaDoJogo.Retangulo),
            new ObjetoDaRodada(CorDoJogo.Marrom, FormaDoJogo.Retangulo),
        });

        Assert.AreEqual(2, rodada.IndiceDoAlvo);
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(0));
        Assert.AreEqual(ResultadoDaSelecao.SelecaoIncorreta, rodada.Avaliar(1));
        Assert.IsTrue(rodada.Aberta);
        Assert.AreEqual(ResultadoDaSelecao.Acerto, rodada.Avaliar(2));
        Assert.AreEqual(3, rodada.Tentativas);
        Assert.AreEqual(FechamentoDaRodada.ComErro, rodada.Fechamento);
        Assert.Throws<InvalidOperationException>(() => rodada.Avaliar(2));
        Assert.AreEqual(3, rodada.Tentativas);
    }
}
