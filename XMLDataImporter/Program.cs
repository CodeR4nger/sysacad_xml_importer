// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using XMLDataImporter.Data;
using XMLDataImporter.Import;
using XMLDataImporter.Repositories;
using XMLDataImporter.Services;

Console.WriteLine("IMPORTADOR XML");

Console.WriteLine("Conectando a base de datos");
var databaseContext = new DatabaseContextFactory().CreateDbContext([]);
databaseContext.Database.Migrate();
Console.WriteLine("Conexion establecida exitosamente");

const string PATH = "files/";

Console.WriteLine("Importando paises.xml");
var paisImporter = new PaisImporter(new PaisService(new PaisRepository(databaseContext)));
paisImporter.Import(PATH + "paises.xml");

Console.WriteLine("Importando localidades.xml");
var localidadImporter = new LocalidadImporter(new LocalidadService(new LocalidadRepository(databaseContext)));
localidadImporter.Import(PATH + "localidades.xml");

Console.WriteLine("Importando especialidades.xml");
var especialidadImporter = new EspecialidadImporter(new EspecialidadService(new EspecialidadRepository(databaseContext)));
especialidadImporter.Import(PATH + "especialidades.xml");

Console.WriteLine("Importando grados.xml");
var gradoImporter = new GradoImporter(new GradoService(new GradoRepository(databaseContext)));
gradoImporter.Import(PATH + "grados.xml");

Console.WriteLine("Importando universidad.xml");
var universidadImporter = new UniversidadImporter(new UniversidadService(new UniversidadRepository(databaseContext)));
universidadImporter.Import(PATH + "universidad.xml");

Console.WriteLine("Importando facultades.xml");
var facultadImporter = new FacultadImporter(new FacultadService(new FacultadRepository(databaseContext)));
facultadImporter.Import(PATH + "facultades.xml");

Console.WriteLine("Importando planes.xml");
var planService = new PlanService(new PlanRepository(databaseContext));
var planImporter = new PlanImporter(planService);
planImporter.Import(PATH + "planes.xml");

Console.WriteLine("Importando materias.xml");
var materiaImporter = new MateriaImporter(new MateriaService(new MateriaRepository(databaseContext)),planService);
materiaImporter.Import(PATH + "materias.xml");

Console.WriteLine("Importando orientaciones.xml");
var orientacionImporter = new OrientacionImporter(new OrientacionService(new OrientacionRepository(databaseContext)),planService);
orientacionImporter.Import(PATH + "orientaciones.xml");
