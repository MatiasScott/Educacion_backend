# Educacion_backend
 
 Creado: Matias Valdivieso
 
 PRUEBA TÉCNICA DESARROLLADOR BACKEND
 
 Pasos de instalcion:
 
1. Clonar el repositorio en visual studio 2022.
2. En nuestro IDE, entrar a la opcion de herramientas, seleccionar la opcion de "Administrador de paquetes Nuget".
3. En el nuevo menu selecionar la opcion "Administrar paquetes Nuget para la solucion".
4. En el apartadio de examinar buscaremos los siguientes paquetes y los instalaremos:
   -Microsoft.EntityFrameworkCore.SqlServer.
   -Microsoft.EntityFrameworkCore.Tools.
5. Abrir Microsoft SQL Server y copiar el .sql para la creacion de la base de datos y ejecutamos.
6. Abriremos la consola para ejecutar el siguiente comando: Scaffold-Dbcontext "server=localhost; database=Educacion; integrated security=true" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models.
7. Esperamos a que se instale y Verificar en la carpeta "Dependencias"si se instalaron correctamente los paquetes.
