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
}