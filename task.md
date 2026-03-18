Úkol pro Developer (branch: PingPong-Squad/Developer)

Cíl: Implementovat konzolovou hru PingPong v C# (1 hráč vs PC) podle designu.

Požadavky a kroky:
- Vytvořit nový .NET 10 console projekt (dotnet new console -f net10.0) v tomto worktree.
- Implementovat herní smyčku: inicializace, update (pohyb, kolize), render (ASCII) a input (klávesnice).
- Mechanics:
  - Míček s jednoduchou fyzikou (pohyb v 2D, odraz od pálek a stěn)
  - Hráč ovládá levou páku (W/S nebo šipky)
  - PC paddle ovládána "thin AI":
    - Pohyb směrem k y-pozici míčku
    - Omezená rychlost a malé zpoždění/reakční doba
    - Volitelně jednoduchá predikce pozice míčku (jedna rovina, bez komplexních výpočtů)
- Skórování: bod pro soupeře, když míček projde za páčkou; cílové skóre 11 (nastavitelné)
- Ovládání: pauza, restart hry, ukončení
- Logging/README: přidat README s instrukcí jak build/run (dotnet run) a jak upravit AI parametry
- Tests: přidat jednoduché unit testy pro jádrové funkce (např. odraz míčku)
- Commity: pravidelně commitovat a po dokončení pushnout branch PingPong-Squad/Developer a otevřít PR. Commit message musí obsahovat Co-authored-by trailer.

Očekávání výstupu:
- Funkční konzolová hra spustitelná příkazem dotnet run
- README s build/run instrukcemi a popisem AI parametrů
- Otevřený PR pro review
=======
Úkol pro QA (branch: PingPong-Squad/QA)

Cíl: Otestovat implementaci konzolové hry PingPong a připravit reporty chyb.

Požadavky a kroky:
- Vytvořit testovací plán a seznam test caseů (manuální + případné automatizované testy) v tomto worktree.
- Testovací oblasti:
  - Funkčnost hry: spuštění (dotnet run) targeting .NET 10, ovládání hráče, skórování, restart, pauza, ukončení
  - AI chování: plynulost pohybu, reakční doba, spravedlnost pro hráče
  - Hrací mechaniky: odrazy míčku, hranice, edge-casey (míček rychle u stěny, více odrazů)
  - Stabilita a výkon v terminálu
  - Cross-platform pozorování (minimálně macOS)
- Pro každý bug report uvést: krok k reprodukci, očekávané chování, aktuální chování, logy/screenshoty (pokud možné)
- Po nalezení chyb vytvořit issues nebo dokument s jasnými kroky pro vývojáře
- Po opravách ověřit fixy a potvrdit regression tests

Očekávání výstupu:
- Soubor se seznamem test caseů + statusy
- Sada bug reportů s reprodukčními kroky
- Ověření oprav a závěrečné shrnutí testů
