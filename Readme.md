# API Rest NET Core 3.1

### Operaciones CRUD:

Operación             | Endpoint                    | Descripción
--------------------- | ----------------------------|----------------------------------------------------- 
 GET                  | **/api/Aspirante**          | Operación encargada de consultar todos los aspirantes
 POST                 | **/api/Aspirante/{clase}**  | Operación encargada de registrar todos los aspirantes
 PUT                  | **/api/Aspirante/{id}**     | Operación encargada de actualizar un aspirante por numero de identificacion
 DELETE               | **/api/Aspirante**          | Operación encargada de eliminar todos los aspirantes



## Pasos para ejecutar el script base de datos

```sql
Ejecutar los archivos ubicados dentro de DBScript en el siguiente orden 

1. WebApplicationBackend\DBScript\1.Estructura BD.sql
2. WebApplicationBackend\DBScript\2.SP Create aspirante.sql
3. WebApplicationBackend\DBScript\3.SP Delete aspirante.sql
4. WebApplicationBackend\DBScript\4.SP Read all aspirante.sql
5. WebApplicationBackend\DBScript\5.SP Update aspirante.sql
```

> Configurar los parametros de conexion en el archivo *appsettings.json*

## Patrones utilizados

- Fabrica
- Comando
- DAO
- Entidad
- Traductores
- DTO

## Estructura principal del proyecto

```bash
C:.
├───bin
│   └───Debug
│       └───netcoreapp3.1
│           ├───Properties
│           └───runtimes
│               └───win
│                   └───lib
│                       └───netstandard2.0
├───BusinessLogic
│   ├───Command
│   │   └───Aspirante
│   └───Factory
├───Common
│   ├───Const
│   ├───CustomException
│   ├───Entities
│   │   └───Factory
│   └───Resources
├───Controllers
├───Data
│   ├───DAO
│   │   └───Interface
│   └───Factory
├───DBScript
├───obj
│   └───Debug
│       └───netcoreapp3.1
│           ├───staticwebassets
│           └───TempPE
├───Properties
└───Services
    ├───DTO
    ├───Factory
    └───Translators
        └───Factory
```


## Realizado por:

**Jesus Yepes**

- [Perfil](https://github.com/jdyepes "Jesus Yepes")
- [Repo](https://github.com/jdyepes/DesafioBackend "Desafio Backend CRUD Aspirantes Repo")
- [Email](mailto:jesusyepes.1205@gmail.com?subject=FromGitHubProject "Hi!")

