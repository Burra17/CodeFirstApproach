# CodeFirstApproach - Instagram Databas Modell POC

Detta projekt är en konsolapplikation skriven i C# och .NET som demonstrerar **Entity Framework Core Code First**-metodiken. Syftet är att bygga en databasmodell för en förenklad version av Instagram, där relationer mellan användare, inlägg och kommentarer definieras i kod och sedan migreras till en SQL Server-databas.

## Projektstruktur

Projektet är uppdelat i följande huvudkomponenter:

### Modeller (`Models/`)
Klasserna som representerar tabellerna i databasen:
*   **User:** Representerar en användare med namn och e-post. En användare kan ha många inlägg och många kommentarer.
*   **Post:** Representerar ett inlägg (bild/text) med en bildtext (Caption). Ett inlägg tillhör en användare (Author) och kan ha många kommentarer.
*   **Comment:** Representerar en kommentar på ett inlägg. En kommentar tillhör ett specifikt inlägg och är skriven av en specifik användare.

### Databas (`Database/`)
*   **InstagramDatabase:** Ärver från `DbContext` och hanterar kommunikationen med databasen. Här konfigureras även relationer och begränsningar (t.ex. maxlängd på text) via Fluent API i `OnModelCreating`.

### Program (`Program.cs`)
Huvudprogrammet som:
1.  Läser in konfiguration (connection string) från `appsettings.json`.
2.  Initierar databaskopplingen.
3.  Hämtar och skriver ut alla användare från databasen till konsolen (som ett enkelt test).

## Teknologier

*   .NET (C#)
*   Entity Framework Core (EF Core)
*   Microsoft SQL Server

## Databasrelationer

Projektet implementerar följande relationer:
*   **En-till-Många (User -> Posts):** En användare kan skapa flera inlägg.
*   **En-till-Många (User -> Comments):** En användare kan skriva flera kommentarer.
*   **En-till-Många (Post -> Comments):** Ett inlägg kan ha flera kommentarer.

## Kom igång

För att köra projektet behöver du:

1.  **Konfigurera databasanslutning:**
    Se till att du har en fil som heter `appsettings.json` i roten av projektet med en giltig anslutningssträng till din SQL Server-instans. Exempel:
    ```json
    {
      "ConnectionStrings": {
        "InstagramDatabase": "Server=(localdb)\mssqllocaldb;Database=InstagramCodeFirst;Trusted_Connection=True;"
      }
    }
    ```

2.  **Applicera migrationer:**
    Öppna Package Manager Console eller en terminal och kör kommandot för att skapa databasen baserat på migrationerna:
    ```bash
    dotnet ef database update
    ```

3.  **Kör applikationen:**
    Starta programmet via Visual Studio eller terminalen:
    ```bash
    dotnet run
    ```
