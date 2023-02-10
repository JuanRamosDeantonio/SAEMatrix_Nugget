
El comando debe ser actualizado cada vez que se suba la versión

---------------------------- Compilar Paquete Nuget ----------------------------

dotnet pack

---------------------------- Publicar Paquete Nuget ----------------------------

dotnet nuget push Saesas.Matrix.CommonLibrary.1.0.0.nupkg --api-key oy2m32fkqp5w3u3ljp6qxv4xmqtvtbeenporvam575l5zq --source https://api.nuget.org/v3/index.json

NOTA:

Para omitir los paquetes ya publicados, usar la opción --skip-duplicate