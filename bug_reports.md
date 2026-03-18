Bug reports pro PingPong (QA)

Formát bug reportu
- ID: BUG-XXX
- Název: Stručný popis
- Priorita: vysoká/střední/nízká
- Prostředí: OS, .NET verze (požadavek: .NET 10), terminál
- Verze/commit: SHA nebo popis build
- Krok k reprodukci:
  1) krok jeden
  2) krok dva
  3) ...
- Očekávané chování:
- Aktuální chování:
- Logy / výstup konzole: (vložit ukázku nebo odkaz na soubor)
- Screenshot / nahrávka: (pokud dostupné)
- Poznámky / dočasné workaroundy:
- Stav: new / confirmed / assigned / fixed / verified

Příklad (prázdný template k použití)

ID: BUG-001
Název: Hra padají při stisknutí klávesy 'r' pro restart
Priorita: vysoká
Prostředí: macOS 13.6, .NET 10 SDK
Verze/commit: 
Kroky k reprodukci:
 1) dotnet run -f net10.0
 2) během hry stisknout 'r' pro restart
 3) pozorovat pád
Očekávané chování: hra se restartuje bez chyby
Aktuální chování: aplikace vyhodí NullReferenceException a končí
Logy: (vložit stacktrace)
Screenshot: (pokud existuje)
Poznámky: 
Stav: new


Instrukce pro QA po nalezení bugů
- Vložit report sem a poslat issue do repozitáře s odkazem na tento report
- Přidat kroky pro reproduce a připravit minimal repro pokud je to možné
- Po opravě aktualizovat Stav na fixed a přidat verifikaci (kdo, kdy, commit)
