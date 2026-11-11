using System;
using NUnit.Framework;

public class InstrucaoDaRodadaTests
{
    [TestCase(CorDoJogo.Vermelho, "Encontre o vermelho")]
    [TestCase(CorDoJogo.Azul, "Encontre o azul")]
    [TestCase(CorDoJogo.Verde, "Encontre o verde")]
    [TestCase(CorDoJogo.Marrom, "Encontre o marrom")]
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
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Marrom, "Encontre o círculo marrom")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Laranja, "Encontre o círculo laranja")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Roxo, "Encontre o círculo roxo")]

    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Vermelho, "Encontre o quadrado vermelho")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Azul, "Encontre o quadrado azul")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Verde, "Encontre o quadrado verde")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Marrom, "Encontre o quadrado marrom")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Laranja, "Encontre o quadrado laranja")]
    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Roxo, "Encontre o quadrado roxo")]

    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Vermelho, "Encontre o triângulo vermelho")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Azul, "Encontre o triângulo azul")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Verde, "Encontre o triângulo verde")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Marrom, "Encontre o triângulo marrom")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Laranja, "Encontre o triângulo laranja")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Roxo, "Encontre o triângulo roxo")]

    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Vermelho, "Encontre a estrela vermelha")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Azul, "Encontre a estrela azul")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Verde, "Encontre a estrela verde")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Marrom, "Encontre a estrela marrom")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Laranja, "Encontre a estrela laranja")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Roxo, "Encontre a estrela roxa")]

    [TestCase(FormaDoJogo.Retangulo, CorDoJogo.Vermelho, "Encontre o retângulo vermelho")]
    [TestCase(FormaDoJogo.Retangulo, CorDoJogo.Azul, "Encontre o retângulo azul")]
    [TestCase(FormaDoJogo.Retangulo, CorDoJogo.Verde, "Encontre o retângulo verde")]
    [TestCase(FormaDoJogo.Retangulo, CorDoJogo.Marrom, "Encontre o retângulo marrom")]
    [TestCase(FormaDoJogo.Retangulo, CorDoJogo.Laranja, "Encontre o retângulo laranja")]
    [TestCase(FormaDoJogo.Retangulo, CorDoJogo.Roxo, "Encontre o retângulo roxo")]
    public void CorEForma_ConcordaComAFormaDoAlvo(FormaDoJogo forma, CorDoJogo cor, string esperado)
    {
        var alvo = new ObjetoDaRodada(cor, forma);
        var rodada = Rodada.CriarCorEForma(cor, forma, new[] { alvo });

        Assert.AreEqual(esperado, InstrucaoDaRodada.Montar(rodada));
    }

    [Test]
    public void PaletaEFormas_SeguemOSgddV212EPreservamOsIndices()
    {
        CollectionAssert.AreEqual(new[] { "Vermelho", "Azul", "Verde", "Marrom", "Laranja", "Roxo" },
            Enum.GetNames(typeof(CorDoJogo)));
        CollectionAssert.AreEqual(new[] { "Circulo", "Quadrado", "Triangulo", "Estrela", "Retangulo" },
            Enum.GetNames(typeof(FormaDoJogo)));
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5 },
            Array.ConvertAll((CorDoJogo[])Enum.GetValues(typeof(CorDoJogo)), cor => (int)cor));
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 },
            Array.ConvertAll((FormaDoJogo[])Enum.GetValues(typeof(FormaDoJogo)), forma => (int)forma));
    }
}
