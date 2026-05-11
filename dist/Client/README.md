SpawnEditor2 — Deployment & Changes
=================================

> **Lingua / Language:** [Italiano](#italiano) | [English](#english)

---

<a name="italiano"></a>

SpawnEditor2 — Note di rilascio (Italiano)
==========================================

Panoramica
----------
Questo repository contiene una versione modificata di SpawnEditor2 (WinForms, .NET Framework 4.8) con supporto al tracking server-driven e automazione della build per produrre artefatti distribuibili in `dist\Client`.

Novità e fix
------------

### Configurazione e profili (2026-04)
- La configurazione (percorso client, impostazioni connessione, ecc.) è ora salvata in un file XML (`SpawnEditor.config.xml`) invece che nel registro di sistema, eliminando problemi di permessi e portabilità.
- Aggiunto menu **File → Profili**: è possibile salvare, caricare ed eliminare profili di configurazione personalizzati. Il profilo di default viene scritto automaticamente al primo avvio.

### Layout e UI (2026-05)
- **Ridisegno completo del layout principale**: tutti i pannelli rimangono all'interno della finestra principale a qualsiasi dimensione. Eliminato l'overflow che causava la fuoriuscita dei controlli oltre il bordo destro.
- **Splitter ajustabili**: introdotto un `SplitContainer` verticale (`splitPanel3`) tra il pannello *Spawn Templates* e il pannello *Spawn Entries*, e uno orizzontale (`splitContainerRightDetails`) tra il tab dei dettagli e la sezione inferiore. L'utente può ridimensionare le aree trascinando i divisori.
- **Mappa a dimensione fissa con aggiornamento dinamico**: `axUOMap` non usa più `Dock=Fill`. La larghezza è calcolata come spazio residuo dopo `pnlControls` e `panelRight`; viene ricalcolata ad ogni ridimensionamento della finestra (`SpawnEditor_Resize`). Questo risolve il bug per cui i click sulla mappa producevano coordinate errate e la mappa si spostava in modo anomalo.
- **Zoom con rotella del mouse**: funziona correttamente in ogni modalità di layout.
- **`grpSpawnEntries` ancorato al bordo destro**: il pannello Spawn Entries riempie l'intera area disponibile; `vScrollBar1` è ancorato `Top|Bottom|Right` così rimane sempre al bordo destro del gruppo.
- **Textbox dei trigger (`textSkillTrigger`, `textSpeechTrigger`, ecc.)**: già ancorate `Left+Right`, si adattano correttamente alla larghezza del gruppo `grpSpawnEdit` con `Dock=Fill`.
- **Dimensione minima finestra** aggiornata a 1400×680 per garantire che tutti i pannelli siano visibili.
- **Finestra di configurazione** (Setup) resa ridimensionabile.

### Tracking server-driven (2026-04)
- Aggiunto un poller che interroga il TransferServer ogni secondo per la posizione autenticata del giocatore (`QueryAuthPosition` / `ReturnAuthPosition`).
- Il polling è abilitato dal flag `Track` / checkbox `chkTracking`.
- Rimosso il fallback di memory scanning; `TryGetLocationFromMemory` e funzioni correlate sono disabilitati.
- Eliminati i `MessageBox` bloccanti per errori remoti; gli errori vengono scritti su `spawneditor.log` e il flag `Track` viene azzerato in caso di errore fatale.
- `DisplayMyLocation()` forza `Invalidate()` + `Update()` sulla mappa per aggiornare il marcatore di posizione immediatamente ad ogni poll.

### Lato server (2026-04)
- `QueryAuthPosition.ProcessMessage()` aggiunge log lato server in `Scripts\Custom\TransServer\queryauth.log`.
- La risoluzione dei tipi per i messaggi server acquisisce un fallback sull'assembly per ridurre le risposte null per mismatch di tipo.

### Build & distribuzione (2026-04)
- `SpawnEditor2.csproj` aggiornato con un post-build target che copia gli output in `dist\Client`.
- `build_and_copy.ps1`: script per eseguire la build e listare il contenuto di `dist\Client`.
- `auto_build_watcher.ps1`: watcher che rileva modifiche ai sorgenti e scatena `build_and_copy.ps1` automaticamente.

File importanti
---------------
- Eseguibile client: `dist\Client\SpawnEditor2.exe`, `SpawnEditor2.pdb`, `SpawnEditor2.exe.config`.
- Log client: `dist\Client\spawneditor.log`.
- Script e log server: `dist\Server\Scripts\Custom\TransServer\QueryAuthPosition.cs` e `queryauth.log`.
- Script di build: `build_and_copy.ps1`, `auto_build_watcher.ps1` (radice del repository).

Deploy / Utilizzo
-----------------
1. Avviare il `TransferServer` (TransServer) in ascolto sull'indirizzo configurato (default `127.0.0.1:8032`).
2. Autenticare la sessione lato server con il comando admin in-game:
   ```
   XTS auth <SessionID>
   ```
3. Avviare `SpawnEditor2.exe` da `dist\Client`.
4. Abilitare `Track` tramite checkbox per avviare il polling (intervallo: 1s).
5. Verificare `spawneditor.log` lato client e `queryauth.log` lato server per diagnostica.

Build
-----
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '.\build_and_copy.ps1'"
```
Per il watcher automatico:
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File ".\auto_build_watcher.ps1"
```

Changelog (alto livello)
------------------------
- **2026-05-11**: Ridisegno layout (SplitContainer, mappa a dimensione fissa, fix coordinate click, vScrollBar1 ancorato a destra, textbox trigger ridimensionabili, MinimumSize aggiornato).
- **2026-04-13**: Poller server-driven, disabilitato memory scanning, popup bloccanti sostituiti da log, repaint mappa immediato, automazione build, logging query lato server, configurazione XML, profili, finestra setup ridimensionabile.

---

<a name="english"></a>

SpawnEditor2 — Release Notes (English)
=======================================

Overview
--------
This repository contains a modified build of SpawnEditor2 (WinForms, .NET Framework 4.8) with server-driven tracking support and build automation to produce distributable artifacts under `dist\Client`.

What's New & Fixed
------------------

### Configuration & Profiles (2026-04)
- Configuration (client path, connection settings, etc.) is now stored in an XML file (`SpawnEditor.config.xml`) instead of the Windows registry, removing permission issues and improving portability.
- Added **File → Profiles** menu: users can save, load and delete named configuration profiles. A default profile is written automatically on first launch.

### Layout & UI (2026-05)
- **Full main-layout redesign**: all panels stay within the main window at any size. Eliminated the overflow that caused controls to extend beyond the right window edge.
- **Adjustable splitters**: introduced a vertical `SplitContainer` (`splitPanel3`) between the *Spawn Templates* panel and the *Spawn Entries* panel, and a horizontal one (`splitContainerRightDetails`) between the detail tab area and the bottom section. Users can resize the areas by dragging the dividers.
- **Fixed-size map with dynamic recalculation**: `axUOMap` no longer uses `Dock=Fill`. Its width is calculated as the residual space after `pnlControls` and `panelRight`; it is recalculated on every window resize (`SpawnEditor_Resize`). This fixes the bug where clicking on the map produced wrong coordinates and the map moved erratically.
- **Mouse-wheel zoom**: works correctly in all layout modes.
- **`grpSpawnEntries` anchored to right edge**: the Spawn Entries panel fills the available area; `vScrollBar1` is anchored `Top|Bottom|Right` so it always stays at the right border of the group.
- **Trigger textboxes (`textSkillTrigger`, `textSpeechTrigger`, etc.)**: already anchored `Left+Right`, now properly stretch to the width of `grpSpawnEdit` with `Dock=Fill`.
- **Minimum window size** updated to 1400×680 to ensure all panels are visible.
- **Setup dialog** made resizable.

### Server-Driven Tracking (2026-04)
- Added a poller that queries the TransferServer every second for the authenticated player position (`QueryAuthPosition` / `ReturnAuthPosition`).
- Polling is gated by the `Track` flag / `chkTracking` checkbox.
- Memory-scanning fallback removed; `TryGetLocationFromMemory` and related functions are disabled.
- Blocking `MessageBox` popups for remote errors removed; errors are written to `spawneditor.log` and the `Track` flag is cleared on fatal remote errors.
- `DisplayMyLocation()` now forces `Invalidate()` + `Update()` on the map control so the position marker updates immediately on each poll.

### Server-Side (2026-04)
- `QueryAuthPosition.ProcessMessage()` adds server-side logging to `Scripts\Custom\TransServer\queryauth.log`.
- Message type resolution gains an assembly fallback to reduce null responses from type mismatches.

### Build & Distribution (2026-04)
- `SpawnEditor2.csproj` updated with a post-build target to copy outputs into `dist\Client`.
- `build_and_copy.ps1`: script to run the build and list `dist\Client` contents.
- `auto_build_watcher.ps1`: watcher that detects source changes and triggers `build_and_copy.ps1` automatically.

Important Files
---------------
- Client executable: `dist\Client\SpawnEditor2.exe`, `SpawnEditor2.pdb`, `SpawnEditor2.exe.config`.
- Client log: `dist\Client\spawneditor.log`.
- Server script & log: `dist\Server\Scripts\Custom\TransServer\QueryAuthPosition.cs` and `queryauth.log`.
- Build scripts: `build_and_copy.ps1`, `auto_build_watcher.ps1` (repository root).

Deployment / Usage
------------------
1. Ensure `TransferServer` (TransServer) is running and listening on the configured address/port (default `127.0.0.1:8032`).
2. Authenticate the client session server-side with the in-game admin command:
   ```
   XTS auth <SessionID>
   ```
3. Launch `SpawnEditor2.exe` from `dist\Client`.
4. Enable `Track` via the UI checkbox to start server polling (interval: 1s).
5. Check `spawneditor.log` for client-side warnings and `queryauth.log` on the server for diagnostics.

Build
-----
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '.\build_and_copy.ps1'"
```
For the auto-watcher:
```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File ".\auto_build_watcher.ps1"
```

Notes & Troubleshooting
-----------------------
- If `dist\Client\SpawnEditor2.exe` cannot be overwritten during build, ensure no running instance of `SpawnEditor2.exe` exists.
- If client polls return `null` or errors, check `queryauth.log` on the server and verify the `SessionID` is present and not expired in `AuthList`.
- For server-side script changes, restart the TransferServer so the updated scripts are loaded.

Changelog (high level)
----------------------
- **2026-05-11**: Layout redesign (SplitContainers, fixed-size map, click-coordinate fix, vScrollBar1 right-anchored, trigger textboxes resizable, MinimumSize updated).
- **2026-04-13**: Server-driven poller, memory scanning disabled, blocking popups replaced with logs, immediate map repaint, build automation, server query logging, XML config, profiles, resizable Setup dialog.
