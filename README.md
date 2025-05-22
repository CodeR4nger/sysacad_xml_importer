# Proyecto SYSACAD - Importador de Datos XML

## Descripción

Este proyecto en C# forma parte de un Trabajo Práctico cuyo objetivo es continuar con el desarrollo del sistema **SYSACAD**. Para ello, es necesario importar datos provenientes de un sistema heredado, almacenados en archivos XML, y persistir dichos datos en la base de datos **DEV_SYSACAD**.

## Funcionalidades

- Importación de datos desde archivos XML.
- Procesamiento y validación de registros únicos por identificador.
- Persistencia de cada registro en su tabla correspondiente dentro de la base de datos.

## Archivos XML a importar

La aplicación procesa los siguientes archivos:

- `grados.xml`
- `universidad.xml`
- `facultades.xml`
- `materias.xml`
- `localidades.xml`
- `especialidades.xml`
- `orientaciones.xml`
- `planes.xml`
- `paises.xml`

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server con la base de datos `DEV_SYSACAD`
- Visual Studio o editor compatible con C#
