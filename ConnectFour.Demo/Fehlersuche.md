**Aufgabe 3:**

Vorgehen:
- In Program.cs die main Methode analysieren.
- Methoden in Board.cs anschauen.
- DiagonalWinner Methode genauen anschauen.
- DiagonalWinner Methode mit einem Breakpoint durchlaufen lassen.
- Ich merke das die Variabel "diagDown" zu früh 4 in einer Reihe war.
- Program nochmals durchlaufen lassen, mit Breakpoint, um den genauen failpoint zu finden.
- In "DiagonalWinner" wird mit contains geprüft ob es über 4 Reihen jeweils das gleiche Zeichen gibt (z.B "x").
  - Wegen dem wird bei dem Brett:
    ```
    0 1 2 3 4 5 6
    _ _ _ _ _ _ _ 
    _ _ _ _ _ _ _ 
    _ _ _ _ _ _ _ 
    _ _ x _ _ _ _
    _ _ o x _ _ _
    _ x o o x _ _ 

  Der "x" Spieler gewinnen, weil er in den Reihen 1-4 ein Zeichen hat, auch wenn sie nicht in einer richtigen Reihe sind.

Fix:
- Anstatt das der Code prüft ob es in 4 Reihen das Zeichen gibt, kontrolliert es jetzt ob die auch in einer richtigen Reihe sind.