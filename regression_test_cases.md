Regresní testy pro konzolovou hru PingPong (QA)

Cíl: Otestovat implementaci konzolové hry PingPong (1 hráč vs PC) targeting .NET 10 a připravit bug reporty.

Instrukce pro testery
- Spouštět hru pomocí: dotnet run -f net10.0
- Testovat na macOS (minimálně), zaznamenat poznámky pro další platformy
- Reportovat každý nalezený bug do bug_reports.md nebo jako issue s krokem k reprodukci

Legenda polí ve výčtu test caseů: ID, Název, Předpoklady, Kroky, Očekávané chování, Priorita, Status

Seznam test caseů

TS-001 — Start a běh hry
- Předpoklady: .NET 10 SDK nainstalován, projekt v pracovním adresáři
- Kroky: spustit dotnet run -f net10.0; zkontrolovat, že hra se vykreslí v konzoli a že je viditelný prompt pro ovládání
- Očekávané: hra se spustí, zobrazení ASCII hrací plochy, možnost ovládat páku
- Priorita: Vysoká; Status: pending

TS-002 — Ovládání hráče (W/S a šipky)
- Předpoklady: hra spuštěna
- Kroky: stisknout W/S a šipky; pozorovat pohyb levé páky
- Očekávané: páka se pohybuje plynule a korektně podle vstupu
- Priorita: Vysoká; Status: pending

TS-003 — Skórování a reset po bodu
- Předpoklady: hra spuštěna
- Kroky: nechat míček projít za páčkou (nebo použít debug příkaz), ověřit inkrement skóre a restart rundy
- Očekávané: skóre se aktualizuje správně; po bodu se míček resetuje do středu a hra pokračuje
- Priorita: Vysoká; Status: pending

TS-004 — Restart hry (klávesa r nebo menu)
- Předpoklady: během hry
- Kroky: stisknout tlačítko pro restart
- Očekávané: skóre se vyresetuje na 0-0, hra začíná od začátku
- Priorita: Střední; Status: pending

TS-005 — Pauza a pokračování
- Předpoklady: hra spuštěna
- Kroky: stisknout pauza (např. P) -> pozorovat, že herní smyčka zastaví posun míčku -> stisknout pokračovat
- Očekávané: při pauze se zastaví aktualizace pozic; po pokračování hra běží dál
- Priorita: Střední; Status: pending

TS-006 — Ukončení hry (q/ctrl+c)
- Předpoklady: hra spuštěna
- Kroky: stisknout ukončovací klávesu
- Očekávané: čisté ukončení aplikace bez stack trace; návratový kód 0
- Priorita: Střední; Status: pending

TS-007 — AI chování: plynulost a reakční doba
- Předpoklady: hra spuštěna
- Kroky: nechat hru běžet; pozorovat pohyb PC páky vůči míčku při různých rychlostech míčku; zkusit situace, kdy je míček rychle u stěny
- Očekávané: AI pohybuje pálkou plynule, s omezenou rychlostí; není nepřiměřeně perfektní ani příliš pomalá
- Priorita: Vysoká; Status: pending

TS-008 — Odrazy míčku a hranice (edge-casey)
- Předpoklady: hra spuštěna
- Kroky: vygenerovat scénáře: rychlý míček podél stěny, vícenásobné odrazy mezi páčkou a stěnou, velmi malý úhel odrazu
- Očekávané: fyzikální model odrazů konzistentní a bez průniků přes stěny/pálky
- Priorita: Vysoká; Status: pending

TS-009 — Stabilita a výkon v terminálu
- Předpoklady: Mac s běžným terminálem
- Kroky: nechat hru běžet 30+ minut, sledovat CPU a paměť; opakovaně restartovat hru
- Očekávané: stabilní spotřeba, bez memory leaků nebo postupného zpomalení
- Priorita: Střední; Status: pending

TS-010 — Cross-platform kontrola (macOS)
- Předpoklady: macOS testovací zařízení
- Kroky: spustit klíčové scénáře na macOS (start, ovládání, skóre, AI)
- Očekávané: funkčnost na macOS bez rozdílů oproti očekávanému
- Priorita: Vysoká; Status: pending

Sekce: Ověření oprav a regrese
- Po každé opravě zapsat do sekce "Verifikace" datum, verzi commitu a které test casey byly ověřeny (pass/fail).

