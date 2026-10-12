# Comparativa de análisis OWASP ZAP - Blazor

| Alerta encontrada                            | Riesgo | Corrección realizada                                                                                                                                             | Resultado final |
| -------------------------------------------- | ------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------- |
| Content Security Policy (CSP) no configurada | Medio  | Se implementó una política CSP desde el host ASP.NET Core.                                                                                                       | Corregida       |
| Falta de cabecera Anti-Clickjacking          | Medio  | Se agregó `X-Frame-Options: DENY` y `frame-ancestors 'none'`.                                                                                                    | Corregida       |
| Falta encabezado X-Content-Type-Options      | Bajo   | Se agregó `X-Content-Type-Options: nosniff`.                                                                                                                     | Corregida       |
| CSP: script-src unsafe-inline                | Medio  | Se restringieron los scripts a recursos propios. Se mantiene `unsafe-inline` por compatibilidad con Blazor WebAssembly y el importmap generado por el framework. | Mitigada        |
| CSP: style-src unsafe-inline                 | Medio  | Se restringieron los estilos a recursos propios. Se mantiene `unsafe-inline` por compatibilidad con estilos generados/utilizados durante la ejecución de Blazor. | Mitigada        |

## Justificación de alertas mitigadas

Las directivas `unsafe-inline` permanecen por compatibilidad con Blazor WebAssembly.

Se intentó endurecer la política eliminando `unsafe-inline`, pero el navegador bloqueó estilos necesarios para el funcionamiento normal de la aplicación.

Por esta razón, se mantuvo una política CSP restrictiva para el resto de recursos y se documentaron ambas alertas como mitigadas.
