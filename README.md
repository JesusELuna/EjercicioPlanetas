# Challenge

Realizar un programa informático para poder predecir en los próximos 10 años:
1. ¿Cuántos períodos de sequía habrá?
2. ¿Cuántos períodos de lluvia habrá y qué día será el pico máximo de lluvia?
3. ¿Cuántos períodos de condiciones óptimas de presión y temperatura habrá?
## Bonus:
Para poder utilizar el sistema como un servicio a las otras civilizaciones, los Vulcanos requieren
tener una base de datos con las condiciones meteorológicas de todos los días y brindar una API
REST de consulta sobre las condiciones de un día en particular.
1) Generar un modelo de datos con las condiciones de todos los días hasta 10 años en adelante
utilizando un job para calcularlas.
2) Generar una API REST la cual devuelve en formato JSON la condición climática del día
consultado.
3) Hostear el modelo de datos y la API REST en un cloud computing libre (como APP Engine o
Cloudfoudry) y enviar la URL para consulta:
Ej: GET → http://....../clima?dia=566 → Respuesta: {“dia”:566, “clima”:”lluvia”}

## Uso local:

```shell
dotnet run ./API/API.csproj
```

## Uso 
La api está desplegada en GCloud, en la ruta https://rare-disk-256818.appspot.com (ahí mismo está la documentación)

## Posibles Mejoras
1. No usar una base de datos en memoria 
2. Implementar interfaz gráfica para observar el movimiento de los planetas
3. Mejorar diseño de obtención de climas 
4. Ver como cambiar id de google cloud porque queda fea la url
5. Mejorar despliegue (es muy manual)
6. Mover constantes a appsettings
7. usar automapper 