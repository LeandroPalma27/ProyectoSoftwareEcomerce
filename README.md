# Repositorio del proyecto para Ing. Software - VII Ciclo

## A implementar:

- Sitema de pagos
- Historial de compras (parte backend)
- Boton para pdf (reporte de compras)
- Mejora del diseño (en funcion a un analisis continuo)
- Al darle añadir al carro, preguntar si desea añadir mas o pasar al carrito

## Problemas:

- Errores en la parte del backend 
- No se actualizan los cambios de la pagina
- Revisar que unión de ramas no genere conflicto
- Error del HEAD (Gravedad	Código	Descripción	Proyecto	Archivo	Línea	Estado suprimido
Error	MSB3541	Files tiene un valor "<<<<<<< HEAD" no válido. Caracteres no válidos en la ruta de acceso.	Evaluacion4	C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\Microsoft.Common.CurrentVersion.targets	5244	
)

## Rediseñar:

- La foto de perfil debe desplegar un menu de detalles de cuenta (para poder editar la cuenta)
- Al crear un perfil, la foto debe selecionarse como en las paginas web mas famosas.
- Al hacer clic a una categoria en el index, se debe mostrar el lista de productos.
- Hacer un carrousel de ofertas.
- Barra buscadora (de productos).
- El carrito de compras es independiente de las cuentas (se gurdaria en localstorage o sesionstorage).
- Por ende, el historial de compras y el pago efectuado si estaria ligado a una cuenta de manera obligatoria.
- Mejorar footer (como el de las aplicaciones famosas).
- Corregir errores de diseño responsive y si es necesario añadir media queries.

## Nueva pestaña de carrito (ocurrencias):

- El resumen de pedido cargara defrente todos los productos sumados al entrar al carrito (al menos por ahora)
- Si se quita un producto del carro, la pagina se debe actualizar automaticamente del carrito
- Si se agrega algo al carro, no debe redirigir al carro automaticamente, solo debe mantenerse en la pagina de productos (al menos por ahora)
- Queda pendiente añadir los botones de check para seleccionar si queremos comprar todos los productos, o solo un producto. En caso de que se implemente esto, el resumen del pedido debe ser reactivo a la seleccion de productos en funcion a lo que desee el cliente
