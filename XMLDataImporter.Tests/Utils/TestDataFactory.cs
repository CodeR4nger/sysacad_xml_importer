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
        Codigo = 2019,
        Especialidad = CreateEspecialidad()
    };
    public static Orientacion CreateOrientacion() => new()
    {
        Nombre = "Analista de Sistemas",
        Plan = CreatePlan(),
        Codigo = 1,
        Especialidad = CreateEspecialidad()
    };
    public static Materia CreateMateria() => new()
    {
        Nombre = "Estabilidad I",
        Ano = "2",
        Codigo = 203,
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
        Pais = "Argentina",
    };
    public static Grado CreateGrado() => new()
    {
        Nombre = "Adjunto"
    };
    public static Facultad CreateFacultad() => new()
    {
        Nombre = "Facultad Regional Chubut"
    };
    public static Universidad CreateUniversidad() =>  new()
    {
        Nombre = "Universidad Nacional del Comahue"
    };
}
