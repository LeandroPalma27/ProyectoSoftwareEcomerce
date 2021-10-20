# Repositorio del proyecto para Ing. Software - VII Ciclo

## A implementar:

- Sitema de pagos
- Historial de compras (parte backend)
- Boton para pdf (reporte de compras)
- Mejora del diseño (en funcion a un analisis continuo)
- Al darle añadir al carro, preguntar si desea añadir mas o pasar al carrito
- Añadir pop ups a tittles que estan incluidos en toda la pagina web
- La foto de perfil debe desplegar un menu de detalles de cuenta (para poder editar la cuenta)
- Al crear un perfil, la foto debe selecionarse como en las paginas web mas famosas.
- Al hacer clic a una categoria en el index, se debe mostrar el lista de productos.
- Hacer un carrousel de ofertas.
- Barra buscadora (de productos).
- El carrito de compras es independiente de las cuentas (se gurdaria en localstorage o sesionstorage).
- Por ende, el historial de compras y el pago efectuado si estaria ligado a una cuenta de manera obligatoria.
- Crear footer (como la app de ishop).
- Cualquier cosa que se idee o se vea en otras aplicaciones web, analizar si hace falta incluirlas o si seria bueno
- Si el carro esta vacio, mostrar un texto en la vista que el carro no tiene productos.
- Implementacion del stock en la vista 
- Resta de stock si se compra
- La lista de deseos
- Nueva tabla: Que almacene un id de compra general, id de usuario, un json donde esten todos los productos comprados en esa compra, la fecha, el precio, etc.
- Añadir ventanas emergentes: En los botones de comprar productos, etc.
- Corregir redirecciones o mejorarlas
- Si hay un producto repetido en el carrito, no se agrega otro, se suma uno mas a la cantidad que se quiere comprar.
- Resta de stock cuando se compra todo.
- Mejorar redirecciones automaticas.
- Mejorar border (a toda la caja)
- Mejorar vista de detalles 
- Mejorar boton para la paginacion
- Tema envio (debate)
- Backend: Implementar un atributo para el control de precios en la tabla hisorial.

AHORA: CORREGIR DISEÑO DE LA VISTA DEL CARRITO


## Problemas:

- No se actualizan los cambios de la pagina (Duda)
- Error del HEAD (Gravedad	Código	Descripción	Proyecto	Archivo	Línea	Estado suprimido
Error	MSB3541	Files tiene un valor "<<<<<<< HEAD" no válido. Caracteres no válidos en la ruta de acceso.	Evaluacion4	C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\Microsoft.Common.CurrentVersion.targets	5244)

## Rediseñar:

- Mejorar componente siempre que se pueda
- Corregir errores de diseño responsive y si es necesario añadir media queries.

## Nueva pestaña de carrito (ocurrencias):

- El resumen de pedido cargara defrente todos los productos sumados al entrar al carrito (al menos por ahora)
- Si se quita un producto del carro, la pagina se debe actualizar automaticamente del carrito
- Si se agrega algo al carro, no debe redirigir al carro automaticamente, solo debe mantenerse en la pagina de productos (al menos por ahora)
- Queda pendiente añadir los botones de check para seleccionar si queremos comprar todos los productos, o solo un producto. En caso de que se implemente esto, el resumen del pedido debe ser reactivo a la seleccion de productos en funcion a lo que desee el cliente
