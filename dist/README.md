================================================================================
# SpawnEditor 2.8 + TransferServer 2.0 — Guida all'installazione
Compatibile con ServUO 57.x (.NET Framework 4.8) e ClassicUO
================================================================================
AUTHOR: ArteGordon
2.7 Version By alchemy on ServUO
2.8 Version By Freezer85

## Requisiti

- .NET Framework 4.8 installato (Windows 10/11 lo include di default)
- ServUO 57.x compilato e funzionante
- I file MUL del client UO (map0.mul, staidx0.mul, statics0.mul, radarcol.mul)

---

## LATO CLIENT — Cartella "Client"

### Contenuto

- `Client/`
  - `SpawnEditor2.exe` — L'editor degli spawner (non richiede OCX)
  - `SpawnEditor2.exe.config` — File di configurazione .NET
  - `Ultima.dll` — Libreria per la lettura dei file MUL

### Installazione

1. Copiare l'intera cartella `Client` in una posizione a scelta (es. `C:\Tools\SpawnEditor2\`).
2. Avviare `SpawnEditor2.exe`.
3. Al primo avvio compilare la finestra di configurazione:
   - `UO Client Path`: percorso dell'eseguibile ClassicUO (es. `C:\Games\ClassicUO\ClassicUO.exe`)
   - `MUL Files Path`: cartella contenente i file .mul del client UO (es. `C:\Games\UltimaOnline\`). Se i file MUL sono nella stessa cartella del client, questo campo può restare vuoto.
   - `RunUO/ServUO Path`: percorso dell'eseguibile di ServUO (es. `G:\ea_games\ServUO-57.4.1\ServUO.exe`).
4. La mappa UO dovrebbe apparire nel pannello sinistro dell'editor.

**Note:**
- Non è più necessario registrare `UOMap.ocx` (regsvr32).
- Non sono più necessari `AxUOMAPLib.dll` e `UOMAPLib.dll`.
- L'app funziona sia a 32 che a 64 bit (AnyCPU).

---

## LATO SERVER — Cartella "Server"

### Contenuto

- `Server/`
  - `DLL/TransferServer.dll` — DLL di infrastruttura per la comunicazione remota (.NET Remoting), da mantenere allineata con gli script `TransServer`
  - `Scripts/Custom/TransServer/` — script server (TransferServer.cs, GetSpawnerData.cs, ecc.)

### Installazione

#### PASSO 1 — Copiare la DLL

Copiare `Server/DLL/TransferServer.dll` nella cartella root di ServUO (dove si trova `ServUO.exe`), ad es. `G:\ea_games\ServUO-57.4.1\TransferServer.dll`.

Importante: sostituire sempre eventuali copie vecchie della DLL. `TransferServer.dll` contiene l'infrastruttura condivisa del protocollo remoto (`ZLib`, `TransferMessage`, `ErrorMessage`, `RemoteMessaging`). Se DLL e script non sono della stessa versione, il server puo' fallire la decompressione delle richieste o restituire payload vuoti.

La DLL distribuita in `Server/DLL/TransferServer.dll` viene ora generata dal sorgente condiviso durante il build del progetto. I messaggi specifici (`GetSpawnerData`, `GetObjectData`, `SaveSpawnerData`, ecc.) restano invece negli script `Server/Scripts/Custom/TransServer/`, quindi DLL e script vanno sempre distribuiti insieme.

#### PASSO 2 — Copiare gli script

Copiare la cartella `Server/Scripts/Custom/TransServer/` dentro ` <ServUO>/Scripts/Custom/TransServer/` sul server.

Dopo ogni aggiornamento del protocollo remoto, copiare sempre sia la DLL sia gli script nella stessa installazione del server.

#### PASSO 3 — Configurare `Assemblies.cfg`

Aprire `<ServUO>/Data/Assemblies.cfg` e aggiungere (se non già presenti):

```
System.Runtime.Remoting.dll
TransferServer.dll
```

Assicurarsi che il file contenga inoltre le voci `System.dll`, `System.Web.dll`, `System.Xml.dll`, `System.Data.dll`, `System.Drawing.dll`, `System.Windows.Forms.dll`.

#### PASSO 4 — Riavviare ServUO

Riavviare il server; il log dovrebbe mostrare: `TransferServer listening on port 8032`.

---

## CONNESSIONE DA SPAWNEDITOR AL SERVER

1. In `SpawnEditor2`, aprire menu `Transfer` > `Transfer Server Settings`.
2. Configurare:
   - `Server`: indirizzo IP o hostname (es. `127.0.0.1` per locale)
   - `Port`: `8032` (default)
   - `Authentication`: il GUID deve corrispondere a quello nella variabile `AuthList` di `TransferServer.cs` sul server
3. Cliccare `Connect` per stabilire la connessione.
4. Usare `Get Spawners` per scaricare gli spawner dal server.

---

## RISOLUZIONE PROBLEMI

- Problema: la mappa è nera / non si vede nulla
  - Soluzione: verificare che il percorso `MUL Files Path` sia corretto e contenga `map0.mul`, `radarcol.mul`, ecc.

- Problema: "No Message Data Received" al tentativo di connessione
  - Soluzione: verificare che ServUO sia avviato e che il log contenga `TransferServer listening on port 8032`; verificare il firewall sulla porta `8032`.

- Problema: errore di autenticazione
  - Soluzione: assicurarsi che il GUID in SpawnEditor corrisponda a quello in `AuthList` di `TransferServer.cs` e che l'account abbia almeno `AccessLevel.GameMaster` per `Get/Send` e `AccessLevel.Administrator` per `Unload Spawners`.

- Problema: ServUO non compila gli script TransServer
  - Soluzione: verificare che `Assemblies.cfg` contenga `System.Runtime.Remoting.dll` e `TransferServer.dll`.

- Problema: in locale funziona ma su un altro server `Get Spawners` fallisce con errori di decompress / payload vuoto
  - Soluzione: verificare di aver sostituito sul server remoto sia `TransferServer.dll` sia `Scripts/Custom/TransServer/` con la stessa versione del pacchetto `dist`. Una DLL vecchia puo' essere incompatibile con le richieste inviate dal client aggiornato.

- Problema: il server remoto usa ancora una DLL legacy incompatibile
  - Soluzione: non riutilizzare vecchie copie manuali di `TransferServer.dll`. Usare sempre la DLL presente in `dist/Server/DLL/TransferServer.dll`, ricreata dal build corrente.

---

