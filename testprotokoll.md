# Testprotokoll

## Testfall 1 | Nicht gültige Eingabe in der Breite
**Beschreibung:** Test des `ConnectFour`-Spiels, bei dem ein Zug außerhalb des gültigen Spielfeldbereichs versucht wird.

---

### Ausgangszustand des Spielfelds
```plaintext
0 1 2 3 4 5 6
_ _ _ _ _ _ _
_ _ _ _ _ _ _
_ _ _ _ _ _ _
_ _ _ _ _ _ _
_ _ _ _ _ _ _
_ _ _ _ _ x _
```

### Aktion
**Spieler:** o  
**Versuchter Zug:** Spalte 9

### Erwartetes Verhalten
Ein Fehler oder eine Ausnahme sollte ausgelöst werden, die darauf hinweist, dass der Zug ungültig ist (z. B. "Spalte außerhalb des gültigen Bereichs").

### Tatsächliches Verhalten
Eine nicht abgefangene Ausnahme wurde ausgelöst (Programmabsturz):
```plaintext
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ConnectFour.Board.MakeMove(Char player, Int32 column) in C:\vsc\_Repos\ConnectFour\ConnectFour\Board.cs:line 47
   at ConnectFour.Demo.Program.Main(String[] args) in C:\vsc\_Repos\ConnectFour\ConnectFour.Demo\Program.cs:line 18
```

## Testfall 2 | Nicht gültige Eingabe in der Höhe
**Beschreibung:** Test des `ConnectFour`-Spiels, bei dem nach einem gültigen Zug versucht wird, den Gewinner zu ermitteln, aber eine Ausnahme aufgrund eines ungültigen Zeilenindex ausgelöst wird.

---

### Ausgangszustand des Spielfelds
```plaintext
0 1 2 3 4 5 6
o _ _ _ _ _ _
x _ _ _ _ _ _
o _ _ _ _ _ _
x _ _ _ _ _ _
o _ _ _ _ _ _
x _ _ _ _ _ _
```

### Aktion
**Spieler:** x  
**Versuchter Zug:** Spalte 0

### Erwartetes Verhalten
Der Zug wird erfolgreich ausgeführt, und das Programm überprüft, ob der Spieler `x` gewonnen hat.

### Tatsächliches Verhalten
Das Spielfeld bleibt unverändert, und eine nicht abgefangene Ausnahme wurde ausgelöst (Programmabsturz):
```plaintext
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ConnectFour.Board.GetRow(Int32 r) in C:\vsc\_Repos\ConnectFour\ConnectFour\Board.cs:line 117
   at ConnectFour.Board.HorizontalWinner(Char player, Int32 r) in C:\vsc\_Repos\ConnectFour\ConnectFour\Board.cs:line 78
   at ConnectFour.Board.Winner(Char player, Int32 row, Int32 col) in C:\vsc\_Repos\ConnectFour\ConnectFour\Board.cs:line 58
   at ConnectFour.Demo.Program.Main(String[] args) in C:\vsc\_Repos\ConnectFour\ConnectFour.Demo\Program.cs:line 20
```

## Testfall 3 | Spielregeln
**Beschreibung:** Test des `ConnectFour`-Spiels, bei dem ein Gewinner korrekt ermittelt wird.

---

### Ausgangszustand des Spielfelds
```plaintext
0 1 2 3 4 5 6
_ x _ _ _ _ _
_ x _ _ _ _ _
_ o o _ _ _ _
- o x _ _ _ _
o x o _ _ _ _
x o x _ _ _ _
```

### Aktion
**Spieler:** x  
**Versuchter Zug:** Spalte 0

### Erwartetes Verhalten
Der Spieler `x` wird nicht als Gewinner erkannt, da nur 3 'x' in einer diagonalen Linie sind.

### Tatsächliches Verhalten
Der Spieler `x` wurde als Gewinner erkannt:
```plaintext
Player x: A winner is you!

Process finished with exit code 0.
```
