# Portfolio — Lior Resida

- Studentnummer: 25149946
- E-mail: 25149946@student.hhs.nl
- Repository: [OP_1_PORTFOLIO-SITE](https://github.com/Iglorr/OP_1_PORTFOLIO-SITE)
- Website: [Portfolio](https://iglorr.github.io/OP_1_PORTFOLIO-SITE/)

## Opbouw

De backend gebruikt **.NET 10**, **Minimal API** en **EF Core met SQL Server**. Je kunt projecten en blogposts ophalen, toevoegen, wijzigen en verwijderen.

De code is ingedeeld in verticale slices, zoals in les 6. Elke handeling heeft een eigen map met een endpoint, handler en de benodigde DTO's. Het endpoint ontvangt de aanvraag, de handler voert de handeling uit en de DTO's bepalen de invoer en uitvoer.

```text
frontend/                 De website: HTML, CSS en JavaScript
backend/coreApi/
├── Domain/               Datamodellen
├── Data/                 PortfolioDBContext voor de database
├── Features/Projects/    Handelingen voor projecten
├── Features/Blogposts/   Handelingen voor blogposts
├── Migrations/           Wijzigingen aan de database
└── Program.cs            Services en routes registreren
```

## Project ophalen

Je hebt Git, de .NET 10 SDK en SQL Server nodig. Voor onderstaande opstelling gebruik je Docker Desktop met Linux-containers. Voer de opdrachten uit in PowerShell.

```powershell
git clone https://github.com/Iglorr/OP_1_PORTFOLIO-SITE.git
cd OP_1_PORTFOLIO-SITE/backend/coreApi
dotnet restore
```

## SQL Server instellen

Start Docker Desktop. Maak eenmalig een SQL Server-container aan. Kies een wachtwoord van minimaal acht tekens met hoofdletters, kleine letters, cijfers en een speciaal teken.

```powershell
$sqlPassword = Read-Host 'Kies een SQL Server-wachtwoord'
docker run --name portfolio-sqlserver -e ACCEPT_EULA=Y -e "MSSQL_SA_PASSWORD=$sqlPassword" -p 127.0.0.1:1434:1433 -v portfolio-sql-data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

Wacht tot SQL Server klaar is met opstarten. Met `docker logs portfolio-sqlserver` kun je de status bekijken. Bij een volgende sessie start je dezelfde container met `docker start portfolio-sqlserver`.

Heb je al SQL Server op poort 1434? Sla het aanmaken over en gebruik die server. Vul dan met `$sqlPassword = Read-Host 'SQL Server-wachtwoord'` het bestaande wachtwoord in.

Stel vanuit `backend/coreApi` de verbinding in:

```powershell
dotnet user-secrets set 'ConnectionStrings:PortfolioDB' "Server=tcp:127.0.0.1,1434;Database=PortfolioDb;User Id=sa;Password=$sqlPassword;Encrypt=True;TrustServerCertificate=True"
Remove-Variable sqlPassword
```

Pas het adres en de poort aan als jouw server ergens anders draait. Het wachtwoord wordt lokaal opgeslagen via user secrets en komt niet in Git. Deze verbindingsinstellingen zijn bedoeld voor lokaal ontwikkelen.

## Database aanmaken

We gebruiken EF Core-migraties. Installeer de EF-tool als je die nog niet hebt:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.14
```

Heb je de tool al? Controleer met `dotnet ef --version`. Gebruik zo nodig `dotnet tool update --global dotnet-ef --version 10.0.14`.

Voer daarna vanuit `backend/coreApi` uit:

```powershell
dotnet ef database update -- --environment Development
```

Dit maakt `PortfolioDb` en de tabellen aan met de migraties uit de repository. Je hoeft de database niet zelf vooraf aan te maken.

## Applicatie starten

Zorg dat SQL Server draait en voer vanuit `backend/coreApi` uit:

```powershell
dotnet run
```

Open [Swagger](http://localhost:5229/swagger) om de tien endpoints onder `/api/projects` en `/api/blogposts` te testen. Als je poort afwijkt, gebruik je het adres uit de terminal met `/swagger` erachter.

Gebruik POST om gegevens toe te voegen en GET om ze op te halen. PUT wijzigt een item en DELETE verwijdert het. Een nieuwe database is nog leeg. Stop de API met `Ctrl+C`; de opgeslagen gegevens blijven in SQL Server staan.

De frontend open je via `frontend/index.html` met Live Server in VS Code, of via de websitelink bovenaan. GitHub Pages host de frontend; de API en SQL Server draaien afzonderlijk.
