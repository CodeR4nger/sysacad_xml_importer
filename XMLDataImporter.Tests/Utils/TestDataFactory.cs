namespace XMLDataImporter.Tests.Utils;

using System.Numerics;
using XMLDataImporter.Models;

public static class TestDataFactory
{
    public static Especialidad CreateEspecialidad() => new()
    {
        Nombre = "Análisis de Sistemas"
    };
    public static Plan CreatePlan() => new()
    {
        Nombre = "2019",
        Especialidad = CreateEspecialidad()
    };
    public static Orientacion CreateOrientacion() => new()
    {
        Nombre = "Analista de Sistemas",
        Plan = CreatePlan(),
        Especialidad = CreateEspecialidad()
    };
    public static Materia CreateMateria() => new()
    {
        Nombre = "Estabilidad I",
        Ano = "2",
        Plan = CreatePlan(),
        Especialidad = CreateEspecialidad()
    };
    public static Pais CreatePais() => new()
    {
        Nombre = "AUSTRALIA",
    };
    public static Localidad CreateLocalidad() => new()
    {
        Ciudad = "FLORIDA",
        Provincia = "Buenos Aires",
        Pais = CreatePais(),
    };
}
