@ECHO OFF
::Autor: Carlos Ochoa
::Date: 25-11-2021
::Desc: Genera los insert de Magic para los sistemas y guarda el archivo
::      en la ruta que se la asigna

ECHO ===Ingresar Datos par Inserts ===


SET /p idu_prod="ID Producto:":
SET /p idReporte="Id Reporte:":
SET /p nomReporte="Nombre del reporte:":


ECHO .
TIMEOUT /t 1 /nobreak > NUL
ECHO ..
TIMEOUT /t 1 /nobreak > NUL

ECHO Generando Archivo!

::Executa BCP
::LOCAL
::bcp "exec carteras.dbo.PROC_MagicT0076 @autorNombre=5, @idu_prod=%idu_prod%, @idu_reporte=%idReporte%, @nomReporte=%nomReporte%, @peticion=37116" queryout "INSERT_Reporte_%nomReporte%_37116.sql" -c -t -S"localhost\MCD-231119-00S,1433" -U operacion -P xoperacion

::10.44.4.144
bcp "exec carteras.dbo.PROC_MagicT0076 @autorNombre=5, @idu_prod=%idu_prod%, @idu_reporte=%idReporte%, @nomReporte=%nomReporte%, @peticion=37116" queryout "INSERT_Reporte_%nomReporte%_37116.sql" -c -t -S"10.44.4.144" -U operacion -P xoperacion
SET Result=%errorlevel%

IF %Result% EQU 0 GOTO FINBIEN
GOTO FINMAL

::si todo termina bien
:FINBIEN
    COLOR 02
	echo "exec carteras.dbo.PROC_MagicT0076 @autorNombre=5, @idu_prod=%idu_prod%, @idu_reporte=%idReporte%, @nomReporte=%nomReporte%, @peticion=37116" queryout "INSERT_Reporte_%nomReporte%_37116.sql" -c -t -S"10.44.4.144" -U operacion -P xoperacion
    ECHO ...
    ECHO Abriendo Script....
    TIMEOUT /t 1 /nobreak > NUL
    START "" notepad.exe "INSERT_Reporte_%nomReporte%_37116.sql"
    ECHO ==== Ejecucion Completada ====
    PAUSE
    EXIT /b 0

::si algo falla
:FINMAL
    COLOR 10
    ECHO ==== Hubo un error ====
    PAUSE
    EXIT /b 1