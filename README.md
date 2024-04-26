# Juan Marcos Hernández Orozco - Prueba desarrollador Semisenior .NET

Este proyecto presenta como objetivo principal, brindar como solución para los clientes, la correcta asignación de números para la participación en sorteos. Esto por medio de un sistema con arquitectura hexagonal y principios SOLID, que ofrece dos Endpoints, uno para la creación de productos a sortear, y otro para la asignación de números a los clientes.

## Arquitectura Hexagonal

El proyecto sigue la arquitectura hexagonal, y se basa en los principios SOLID y de arquitectura limpia, lo que permite la modularidad, escalabilidad y mantenimiento.
Se presentan las siguientes capas:
 - Application:   Contiene la lógica de aplicación y actúa como un puente entre la capa de infraestructura y la capa de dominio.
 -  Infrastructure: Contiene la implementación concreta de los servicios externos, como bases de datos, servicios web y almacenamiento en la nube, además, Implementa los adaptadores necesarios para que la capa de aplicación pueda interactuar con los servicios externos
 - Domain: Contiene las entidades de dominio y los DTOs.
 - API: Es la capa de presentación representada por la API Rest que expone los endpoints para poder interactuar con el sistema.

## Tecnologías

 Para el proyecto se utilizaron las siguientes tecnologías:
 
 - .NET 8
 - .NET CORE
 - Entity Framework
 - Swagger
 - SQL
 - ADO .NET

## Base de datos

Los Scripts y los pasos a seguir para crear la base de datos y sus elementos se encuentran en la ruta:
.../.../NumeroAsignadoProject/Api/Resources/Steps.

Se utilizó SQL Server como administrador de base de datos, en el archivo Appconfig.json se encuentra la cadena de conexión para conectarse a la base de datos.

## Adicional

Se cumplieron los criterios de aceptación establecidas en el proyecto, además se implementaron patrones de diseño, la autenticación por ApiKey, y la implementación de Swagger para consumir los endpoints.
