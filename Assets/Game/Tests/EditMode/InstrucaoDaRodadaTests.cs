using System;
using NUnit.Framework;

public class InstrucaoDaRodadaTests
{
    [TestCase(CorDoJogo.Vermelho, "Encontre o vermelho")]
    [TestCase(CorDoJogo.Azul, "Encontre o azul")]
    [TestCase(CorDoJogo.Verde, "Encontre o verde")]
    [TestCase(CorDoJogo.Amarelo, "Encontre o amarelo")]
    [TestCase(CorDoJogo.Laranja, "Encontre o laranja")]
    [TestCase(CorDoJogo.Roxo, "Encontre o roxo")]
    public void SoCor_IgnoraAGramaticaDaFormaDoAlvo(CorDoJogo cor, string esperado)
    {
        foreach (FormaDoJogo forma in Enum.GetValues(typeof(FormaDoJogo)))
        {
            var alvo = new ObjetoDaRodada(cor, forma);
            var rodada = Rodada.CriarSoCor(cor, new[] { alvo });

            Assert.AreEqual(esperado, InstrucaoDaRodada.Montar(rodada), $"Forma do alvo: {forma}");
        }
    }

    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Vermelho, "Encontre o círculo vermelho")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Azul, "Encontre o círculo azul")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Verde, "Encontre o círculo verde")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Amarelo, "Encontre o círculo amarelo")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Laranja, "Encontre o círculo laranja")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Roxo, "Encontre o círculo roxo")]

    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Vermelho, "Encontre o quadrado vermelho")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Azul, "Encontre o quadrado azul")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Verde, "Encontre o quadrado verde")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Amarelo, "Encontre o quadrado amarelo")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Laranja, "Encontre o quadrado laranja")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Roxo, "Encontre o quadrado roxo")]

    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Vermelho, "Encontre o triângulo vermelho")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Azul, "Encontre o triângulo azul")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Verde, "Encontre o triângulo verde")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Amarelo, "Encontre o triângulo amarelo")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Laranja, "Encontre o triângulo laranja")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Roxo, "Encontre o triângulo roxo")]

    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Vermelho, "Encontre a estrela vermelha")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Azul, "Encontre a estrela azul")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Verde, "Encontre a estrela verde")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Amarelo, "Encontre a estrela amarela")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Laranja, "Encontre a estrela laranja")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Roxo, "Encontre a estrela roxa")]
    public void CorEForma_ConcordaComAFormaDoAlvo(FormaDoJogo forma, CorDoJogo cor, string esperado)
    {
        var alvo = new ObjetoDaRodada(cor, forma);
        var rodada = Rodada.CriarCorEForma(cor, forma, new[] { alvo });

        Assert.AreEqual(esperado, InstrucaoDaRodada.Montar(rodada));
    }
}
