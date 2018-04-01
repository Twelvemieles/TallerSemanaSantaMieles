Desarrollo de actividad 

lo primero que tuve en cuenta, fue hacer un "árbol de familia" en el que pude
darme cuenta de que todos los jugadores, podrían depender de un padre en común 
también pude aclarar el cómo introduciría las armas a los personajes 

luego de aplicar físicas para los disparos y verificar que hicieran daño , el 
siguiente reto sería los turnos intercalados, luego de muchos intentos, la forma 
que me funcionó mejor, fue usar dos listas (una para cada bando) y dos variables,
una que indica el bando y otra que indica el jugador del bando , así, cada que dispara,
el mananger (singleton pues si dos instancias hacían esto se formaba un lío)
cambia de bando y cuando el del segundo bando dispara, cambia el número de jugador del
bando . esto.. es lo que aun no pude solucionar y llevo todo un día pensando en cómo 
solucionarlo, pero no pude.   cuando muere un enemigo, el valor queda en null dentro 
de la lista, aproveché esto, para decir que si el espacio no estaba en null, ejecutara
el código, de lo contrario, se quedara en el mismo bando, le sumara uno al número 
del jugador y volviera a intentar (para que habilitara al siguiente jugador de la
lista) ... cosa que no funcionó , al final me di por vencido y lo que logré hacer, 
es que elimine estos espacios en null, pero esto igual trae sus conflictos.

en conclusión pude solucionar los puntos del taller, pero no implementar adecuadamente
el sistema de turnos, ya que ocurren problemas cuando mueren los personajes.
