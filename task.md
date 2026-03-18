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
