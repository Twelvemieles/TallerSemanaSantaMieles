Desarrollo de actividad 

lo primero que tuve en cuenta, fue hacer un "�rbol de familia" en el que pude
darme cuenta de que todos los jugadores, podr�an depender de un padre en com�n 
tambi�n pude aclarar el c�mo introducir�a las armas a los personajes 

luego de aplicar f�sicas para los disparos y verificar que hicieran da�o , el 
siguiente reto ser�a los turnos intercalados, luego de muchos intentos, la forma 
que me funcion� mejor, fue usar dos listas (una para cada bando) y dos variables,
una que indica el bando y otra que indica el jugador del bando , as�, cada que dispara,
el mananger (singleton pues si dos instancias hac�an esto se formaba un l�o)
cambia de bando y cuando el del segundo bando dispara, cambia el n�mero de jugador del
bando . esto.. es lo que aun no pude solucionar y llevo todo un d�a pensando en c�mo 
solucionarlo, pero no pude.   cuando muere un enemigo, el valor queda en null dentro 
de la lista, aprovech� esto, para decir que si el espacio no estaba en null, ejecutara
el c�digo, de lo contrario, se quedara en el mismo bando, le sumara uno al n�mero 
del jugador y volviera a intentar (para que habilitara al siguiente jugador de la
lista) ... cosa que no funcion� , al final me di por vencido y lo que logr� hacer, 
es que elimine estos espacios en null, pero esto igual trae sus conflictos.

en conclusi�n pude solucionar los puntos del taller, pero no implementar adecuadamente
el sistema de turnos, ya que ocurren problemas cuando mueren los personajes.
