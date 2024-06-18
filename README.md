# LibroClub

Este es un proyecto de ejemplo para la gestión de productos multimedia creada para el curso de Progrmación 3. Incluye un backend desarrollado en Java con NetBeans y un frontend desarrollado en C# con Visual Studio.

## Estructura del Proyecto

- **libroClubSoft**: Proyecto backend en Java (NetBeans).
  - **libroClubWS**: Servicios web.
  - **libroClubDBManager**: Gestión de la base de datos.
  - **libroClubModel**: Modelos de datos. (Se divide en 4 Model)
  - **libroClubController**: Controladores y DAOs.(Cada Model tiene su controller)
- **libroClubViews**: Proyecto frontend en C# (Visual Studio).

## Requisitos

- JDK 21
- NetBeans 21
- Visual Studio 2022
- MySQL 8.0 o superior
- Apache Ant
- GlassFish 5 o superior

## Configuración del Proyecto

##Configuración Backend

1. Clona el repositorio:

2. Ejecutar el .sql en Base de Datos a disposición (este proyecto tiene las credenciales de una base de Datos de AWS, cambiar si es que lo necesita o esta no funciona)
   
4. Abrir el proyecto libroClubSoft en Netbeans

5. En lado servidores iniciar un servidor de Glasshfish

6. Tiene una base de Datos de AWS vinculada, pero en caso no funcione. Cambiar a base de datos a disposición que contenga las tablas del .sql

7. Ejecutar y compilar LibroWS

##Configuración Frontend

9. En la parte LibroClubViews. Abrir el .sln en Visual Studio

11. Ejecutar proyecto

12. Ingresar al proyecto con estas credenciales:   user: brunogerente   pass:gerente123
