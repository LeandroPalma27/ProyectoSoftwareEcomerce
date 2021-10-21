# Repositorio del proyecto para Ing. Software - VII Ciclo

## A implementar:

Backend:
- Sitema de pagos
- Historial de compras (parte backend)
- Redireccion pdf al darle a comprar (reporte de compras a traves de la tabla factura)
- Al darle añadir al carro, preguntar si desea añadir mas o pasar al carrito
- Añadir pop ups a tittles que estan incluidos en toda la pagina web
- La foto de perfil debe desplegar un menu de detalles de cuenta (para poder editar la cuenta)
- La seleccion de fotos debe hacerse en una vista especial como se hace en sitios web famosos.
- Al hacer clic a una categoria en el index, se debe mostrar el lista de productos.
- Hacer un carrousel de ofertas.
- Barra buscadora (de productos).
- Tratar de incluir popups en la mayoria de cosas que se puedan.
- El carrito de compras es independiente de las cuentas (se gurdaria en localstorage o sesionstorage).
- Por ende, el historial de compras y el pago efectuado si estaria ligado a una cuenta de manera obligatoria.
- Crear footer (como la app de ishop).
- Cualquier cosa que se idee o se vea en otras aplicaciones web, analizar si hace falta incluirlas o si seria bueno
- Si el carro esta vacio, mostrar un texto en la vista que el carro no tiene productos.
- La lista de deseos
- Nueva tabla factura: paint(discord).
- Añadir ventanas emergentes: En los botones de comprar productos, etc.
- Si hay un producto repetido en el carrito, no se agrega otro, se suma uno mas a la cantidad que se quiere comprar.
- Rediseñar vista detalles, crear y editar 
- Mejorar boton para la paginacion (traducir al español)
- Tema envio (debate): Pueden ser en funcion a que lugar de envio seleccione el usuario (las zonas que cubre el delivery deben ser incluidas en los terminos y condiciones). 
- Backend: No se permite eliminar un producto. Sin un adminnistrador quiere eliminar un producto, lo que hara es reducir el stock a 0 (idear como seria gestionar eso para el cliente).

AHORA: CORREGIR DISEÑO DE LA VISTA DEL CARRITO


## Problemas:

- Error del HEAD (Gravedad	Código	Descripción	Proyecto	Archivo	Línea	Estado suprimido
Error	MSB3541	Files tiene un valor "<<<<<<< HEAD" no válido. Caracteres no válidos en la ruta de acceso.	Evaluacion4	C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\Microsoft.Common.CurrentVersion.targets	5244)
- Posible error en produccion: Al añadir imagenes desde la nube, como se guardarian esos archivos en el backend de la nube?
- Los precios en double no se cargan
- Error de seguridad por display none en un div de edit (mandar el id obtenido desde el backend)

## Rediseñar:

- Mejorar componente siempre que se pueda
- Corregir errores de diseño responsive y si es necesario añadir media queries.

## Nueva pestaña de carrito (ocurrencias):

- El resumen de pedido cargara defrente todos los productos sumados al entrar al carrito (al menos por ahora)
- Si se quita un producto del carro, la pagina se debe actualizar automaticamente del carrito
- Si se agrega algo al carro, no debe redirigir al carro automaticamente, solo debe mantenerse en la pagina de productos (al menos por ahora)
- Queda pendiente añadir los botones de check para seleccionar si queremos comprar todos los productos, o solo un producto. En caso de que se implemente esto, el resumen del pedido debe ser reactivo a la seleccion de productos en funcion a lo que desee el cliente
