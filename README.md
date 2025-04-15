# Backend de Juego de la Ruleta

Backend desarrollado en ASP.NET MVC para gestionar un juego de ruleta.

## Tecnologías Utilizadas

- ASP.NET MVC
- .NET Framework 4.8
- Entity Framework 6
- SQL Server

## Configuración del Proyecto

1. Restaurar paquetes NuGet:
```
nuget restore
```

2. Modificar la cadena de conexión en `Web.config` según tu entorno:
```xml
<connectionStrings>
    <add name="DefaultConnection" 
         connectionString="Server=localhost;Database=GameRoulette;User Id=sa;Password=tu_password;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Estructura del Proyecto

- **Controllers/**
  - ApuestaController.cs - Gestión de apuestas
  - UsuarioController.cs - Gestión de usuarios
  - JuegoController.cs - Lógica del juego

- **Models/**
  - ApuestaModel.cs - Modelo de apuestas
  - Usuario.cs - Modelo de usuarios
  - AppDbContext.cs - Contexto de base de datos

- **Modules/**
  - CorsHttpModule.cs - Configuración CORS

## Ejecución

1. Compilar el proyecto
2. Ejecutar en IIS Express
3. La API estará disponible en `https://localhost:44382/`

## Características

- Sistema backend de Juego de Ruleta
- Gestión de usuarios
- Cálculo de premios
- CORS habilitado para integración con frontend

## Autor

Cristhian Farfan