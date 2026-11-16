using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Confere o asset ConfiguracaoDoJogo: as seis cores e os cinco sprites das formas precisam estar atribuídos.
/// Lê o asset por SerializedObject, sem depender da classe ConfiguracaoDoJogo (que está no assembly padrão).
/// Referência quebrada ("Missing") conta como não atribuída, e é o que faz a rodada lançar
/// InvalidOperationException na FabricaDeFormas.
/// </summary>
public class ConfiguracaoDoJogoAssetTests
{
    private const string Caminho = "Assets/Game/Data/ConfiguracaoDoJogo.asset";

    private static readonly string[] CamposDeCor =
    {
        "corVermelho", "corAzul", "corVerde", "corMarrom", "corLaranja", "corRoxo"
    };

    private static readonly string[] CamposDeSprite =
    {
        "spriteCirculo", "spriteQuadrado", "spriteTriangulo", "spriteEstrela", "spriteRetangulo"
    };

    private static SerializedObject Carregar()
    {
        var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(Caminho);
        Assert.IsNotNull(asset, $"Não achei o asset em {Caminho}.");
        return new SerializedObject(asset);
    }

    private static List<string> CamposSemReferencia(string[] campos)
    {
        var so = Carregar();
        var faltando = new List<string>();

        foreach (string campo in campos)
        {
            SerializedProperty propriedade = so.FindProperty(campo);
            Assert.IsNotNull(propriedade, $"O campo '{campo}' não existe na ConfiguracaoDoJogo.");

            if (propriedade.objectReferenceValue == null)
                faltando.Add(campo);
        }

        return faltando;
    }

    [Test]
    public void AsSeisCoresEstaoAtribuidas()
    {
        Assert.IsEmpty(CamposSemReferencia(CamposDeCor), "Cores sem ColorData atribuído");
    }

    [Test]
    public void OsCincoSpritesDasFormasEstaoAtribuidos()
    {
        Assert.IsEmpty(CamposSemReferencia(CamposDeSprite), "Formas sem sprite atribuído");
    }

    [Test]
    public void AsCoresAtribuidasSaoColorData()
    {
        var so = Carregar();

        foreach (string campo in CamposDeCor)
        {
            Object referencia = so.FindProperty(campo).objectReferenceValue;
            Assert.IsInstanceOf<ColorData>(referencia, $"'{campo}' deveria apontar para um ColorData.");
        }
    }

    [Test]
    public void OsSpritesAtribuidosSaoSprites()
    {
        var so = Carregar();

        foreach (string campo in CamposDeSprite)
        {
            Object referencia = so.FindProperty(campo).objectReferenceValue;
            Assert.IsInstanceOf<Sprite>(referencia, $"'{campo}' deveria apontar para um Sprite.");
        }
    }
}
