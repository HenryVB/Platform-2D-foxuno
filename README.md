# Platform-2D-foxuno
Juego de plataformas 2D en Unity

# [Link del aplicativo desplegado en Itch.io](https://henryvb.itch.io/foxuno-platform-2d-game-beta)

## 1) Instrucciones
=============
1. Se muestra un menú inicial con el botón de "Play" para iniciar el juego.
2. Se cuenta con menú de pausa (Usar la tecla "p").
3. Se cuenta con un mapa del juego donde se visualizan los 3 niveles del juego.
4. El juego tiene 3 niveles (2 niveles + 1 Boss). Se gana cuando se superen todos. 	
5. Los niveles son consecutivos y deben superarse para acceder al siguiente.
6. En el menú del jugador se le muestra las vidas y las gemas recolectadas por cada nivel.
7. El jugador tiene 3 corazones (puede perder más o menos dependiendo del daño del enemigo).
8. Si llega a perder las 3 vidas regresará al último punto de donde empezó o donde tuvo un checkpoint.
9. En caso caiga al vacío perderá todas sus vidas y regresará al último punto de donde empezó o donde tuvo un checkpoint.

## 2) Los personajes
==============

### Player o Jugador 
================
- Puede moverse arriba, abajo, izquierda, derecha.
- Puede hacer salto simple o salto doble. Debe saltar sobre los enemigos para vencerlos.
- Recolecta objetos como gemas lo más que pueda y corazones (para su salud).

### Enemigo
=======
- **Enemigo 1 (Rana):** Enemigo en tierra que se encuentra saltando en un espacio determinado. Cuenta con 1 vida. Quita 1/2 corazón.
- **Enemigo 2 (Águila):** Enemigo volador que perseguirá en un rango al personaje. Cuenta con 1 vida. Quita 1/2 corazón.
- **Enemigo 3 (Jefe militar):** Enemigo jefe que dispara con su tanque y deja minas en el campo. Cuenta con 5 vidas. Quita 1 vida por disparo y 1/2 por explosión de minas.

## 3) Objetos u obstáculos
- **Plataformas:** Estas pueden ser estáticas para saltar o movibles de lado a lado ya sea horizontal, vertical o diagonal.
- **Gemas:** Recolección de gemas para obtener todas las del nivel.
- **Corazones:** Para recuperar corazones.
- **Pinchos:** Obstáculos que quitan vida al jugador.
- **Checkpoint:** Cartel con el símbolo (CP) donde el jugador puede regresar en caso de morir.
- **Pogo o saltarín:** Objeto amarillo para saltar más alto e impulsa hacia arriba.

## 4) Menús
- Menú de inicio.
- Menú de pausa.
- Menú de fin de juego al ganar.

## 5) Mapas
- Mapa de niveles que recorre el personaje.
- Mapa del mundo donde se ven todos los niveles.

## 6) Efectos Especiales
==================
### Sonidos
=======
- Para la música de fondo del mundo o con el jefe.
- Para los saltos del jugador.
- Para los daños hacia enemigos o al jugador.
- Toma de objetos.
	
### Efecto Explosión
=========
- Cuando se destruye a un enemigo o al jugador.

### Ambiente
========
- Se maneja un fondo (similar al parallax) a medida que se va avanzando.
