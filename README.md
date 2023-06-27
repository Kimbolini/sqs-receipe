<details>
<summary>Inhaltsverzeichnis2 </summary> 

[1 Einführung und Ziele](#1-einführung-und-ziele) <br>
[Randbedingungen](#randbedingungen) <br>
[Kontextabgrenzung](#kontextabgrenzung) <br>
[Lösungsstrategie](#lösungsstrategie) <br>
[Bausteinsicht](#bausteinsicht) <br>
[Laufzeitsicht](#laufzeitsicht) <br>
[Verteilungssicht](#verteilungssicht) <br>
[Querschnittliche Konzept](#querschnittliche-konzept) <br>
[Architekturentscheidungen](#architekturentscheidungen) <br>
[Qualitätsanforderungen](#qualitätsanforderungen) <br>
[Risiken und technische Schulden](#risiken-und-technische-schulden) <br>
[Was ist wie abgesichert](#was-ist-wie-abgesichert) <br>
[Glossar](#glossar) <br>

</details>

# 

# 1 Einführung und Ziele

Dieses Dokument beschreibt die Software-Architektur des Rezepte-Systems. Das System dient dem Finden und Abspeichern von Rezepten. Es soll im Internet einem breiten Publikum zur Verfügung stehen.

[comment]: <> (#############################################################################)

## Qualitätsziele

Die folgende Tabelle beschreibt die zentralen Qualitätsziele des Rezeptesystems. Die Reihenfolge gibt dabei eine grobe Orientierung bezüglich der Wichtigkeit vor. 
Die Umsetzung derQualitätsziem im Kapitel Lösungsstrategie zu finden.

| Qualitätsmerkmal | Ziel |
|-----------------|-----------------------------------|
| Wartbarkeit |  |
| Performance |  |
| Security | Interne Schnittstellen des Rezeptesystem sind abgesichert. |
| Erweiterbarkeit | Das Rezeptesystem lässt sich leicht um neue Funktionalität(en) erweitern. Es kann auf lange Sicht dem technologischen Fortschritt bei Tools folgen.|
| Erlernbarkeit | Entwickler finden sich schnell im Rezeptesystem zurecht, wodurch neuer Code und Builds schnell erstellt werden können. |
| Skalierbarkeit | Auch wenn das System wächst und Builds umfangreicher werden, bleibt das Rezeptesystem handhabbar und effizient. |
|  |  |

## Stakeholder

Die folgende Tabelle stellt die Stakeholder des Repetesystems und deren jeweilige Erwartungshaltung und Interessen dar.

| Stakeholder          | Erwartungshaltung                 |
|-----------------|-----------------------------------|
| Nutzer im Internet   | - Schnelle, intuitive Bedienung und Funktion der Website <br> - Keine Bugs <br> - keine Wartezeiten            |
| Entwickler   | Gut wartbarer, erweiterbarer und lesbarer Code                  |
| Betreiber der themealdb-API  | Kein Missbrauch ihrer API                |

[comment]: <> (#############################################################################)

# Randbedingungen

### Technische Randbedingungen

| Thema       | Erläuterung                 |
|-----------------|-----------------------------------|
| Grafische Oberfläche | Nutzer können mittels einer Website mit dem System interagieren |
| Schutz vor Attacken | DDOs-Schutz, Eingabenschutz |
| Programmiersprache | Das Rezeptsystem wurde fullstack in C# programmiert |
| Betriebssysteme | Das Rezeptsystem unterstützt (mindestens) Windows, Linux und MacOS|
| Betriebsmodi| Das Rezeptsystem kann aus den wichtigsten IDEs, von Buildservern und von der Kommandozeile aus gestartet werden.|
| Build | .. baut sich selbst? |

### Konventionen

| Thema       | Erläuterung                 |
|-----------------|-----------------------------------|
| Source Code | Quelltextverwaltung bei GitHub, <br> https://github.com/Kimbolini/sqs-receipe |
| Defect Tracking | Mittels GitHub issues: <br> https://github.com/Kimbolini/sqs-receipe/issues |
| Namensgebung | C# Programmierkonventionen: <br> https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions  |

[comment]: <> (#############################################################################)

# Kontextabgrenzung

Nachfolgend wird das Umfeld beschrieben. Für welchen Nutzer das System erstellt wurde und mit welchen Fremdsystem es interagiert. 
https://www.embarc.de/arc42-starschnitt-gradle-schnipsel-nr-2-systemkontext/

TODO: Bild erstellen wie im Link oben

- Repository: Mittels Repository werden Abhängigkeiten, die für Builds erforderlich sind, aufgelöst 
und erforderliche Artefakte bezogen ("Download"). Außerdem können Ergebnisse eines Builds in Repositories 
veröffentlicht werden.

## Fachlicher Kontext

| Kommunikationspartner | Eingabe | Ausgabe |
|--|--|--|
| Nutzer - Website | Suchanfrage |  |

**\<optional: Erläuterung der externen fachlichen Schnittstellen>**

## Technischer Kontext

**\<Diagramm oder Tabelle>**

**\<optional: Erläuterung der externen technischen Schnittstellen>**

**\<Mapping fachliche auf technische Schnittstellen>**

[comment]: <> (#############################################################################)

# Lösungsstrategie

| Qualitätsziel | Lösungsansatz im Rezeptsystem |
|--|--|
| Wartbarkeit | ----- |
|  | - Die Codequalität wird mittels sonarcloud überprüft (https://sonarcloud.io/summary/overall?id=Kimbolini_sqs-receipe) |
| Performance | ----- |
|  | K6 Lasttest |
| Security | ----- |
|  | github worker |
|  |  |
|  |  |
|  |  |

Was ist wie abgesichert

- Performanceanforderungen - wieviel Anfragen pro Sekunde? Wie schnell?
- Rest service testen - Unit-Tests?
- Statische Codequalität abgesichert über .. 
- Lint (z.B. für Dockerimage) 
- Sync, trivy (Tools um zB wegen Dependencies zu überprüfen)


[comment]: <> (#############################################################################)

# Bausteinsicht

Dieses Kapitel beschreibt die Zerlegung des Rezeptesystem in Module, wie sie auch in der Ordnerstruktur des C#-Quelltextes zu finden sind.

## Whitebox Gesamtsicht

<img src="images/Komponentendiagramm.png"  width="60%">

## Ebene 1 

Das Rezeptesystem besteht aus zwei großen Subsystemen, die als zwei separate Visual-Studio-Projekte realisiert wurden.

//TODO: Bild

| Name | Kurzbeschreibung |
|--|--|
| frontend | Enthält die graphische Oberfläche zur Interaktion mit Nutzern und Logik, um mit der mealdb-API und dem Backend zu interagieren. |
| backend | Das Backend mit der Datenbank und dem Business Layer. B2 stellt Dienste zur Verfügung, um Daten aus der Datenbank zu holen/schreiben. |

### Frontend (Blackbox)
##### Zweck/Verantwortlichkeit

Dieses Subsystem stellt dem Nutzer eine grafische Oberfläche (GUI) zur Interaktion zur Verfügung. Die GUI besitzt zwei Seiten, die der Nutzer direkt aufrufen kann: _Home.razor_ und _Favoriten.razor_. 

//TODO: Bild

##### Schnittstellen

Das Subsystem stellt seine Funktionalität der Rezeptsuche über die Klassen _Program.cs_ und _MealsAtAPIService.cs_ zur Verfügung. _MealsAtAPIService_ wird dabei als Singleton vor Programmstart definiert und der Home-Website als Service zur Verfügung gestellt.

<img src="images/frontendRezeptsuche.png"  width="60%">

| Methode | Kurzbeschreibung |
|--|--|
|  | | 2min


*\<(Optional) Qualitäts-/Leistungsmerkmale>*

*\<(Optional) Ablageort/Datei(en)>*

*\<(Optional) Erfüllte Anforderungen>*

*\<(optional) Offene Punkte/Probleme/Risiken>*

### Backend (Blackbox)

*\<Blackbox-Template>*

### \<Name Blackbox n> 

*\<Blackbox-Template>*

### \<Name Schnittstelle 1> 

...

### \<Name Schnittstelle m> 

## Ebene 2

### Whitebox *\<Baustein 1>* 

Datenbank:
<img src="images/Datenbankschema.png"  width="60%">

### Whitebox *\<Baustein 2>* 

*\<Whitebox-Template>*

...

### Whitebox *\<Baustein m>* 

*\<Whitebox-Template>*

## Ebene 3

### Whitebox \<\_Baustein x.1\_\> 

*\<Whitebox-Template>*

### Whitebox \<\_Baustein x.2\_\> 

*\<Whitebox-Template>*

### Whitebox \<\_Baustein y.1\_\> 

*\<Whitebox-Template>*

[comment]: <> (#############################################################################)

# Laufzeitsicht 

Hier wäre das deployment via Docker relevant, wenn es denn umgesetzt werden würde.

## *\<Bezeichnung Laufzeitszenario 1>* 

-   \<hier Laufzeitdiagramm oder Ablaufbeschreibung einfügen>

-   \<hier Besonderheiten bei dem Zusammenspiel der Bausteine in diesem
    Szenario erläutern>


[comment]: <> (#############################################################################)

# Verteilungssicht 

Die Verteilungssicht des Systems soll im folgenden UML-Komponentendiagramm ersichtlich werden:



## Infrastruktur Ebene 1 

***\<Übersichtsdiagramm>***

Begründung

:   *\<Erläuternder Text>*

Qualitäts- und/oder Leistungsmerkmale

:   *\<Erläuternder Text>*

Zuordnung von Bausteinen zu Infrastruktur

:   *\<Beschreibung der Zuordnung>*

## Infrastruktur Ebene 2

### *\<Infrastrukturelement 1>* 

*\<Diagramm + Erläuterungen>*

### *\<Infrastrukturelement 2>* 

*\<Diagramm + Erläuterungen>*

...

### *\<Infrastrukturelement n>* 

*\<Diagramm + Erläuterungen>*

[comment]: <> (#############################################################################)

# Querschnittliche Konzepte

## *Logging* 

Transaktionen in der Datenbank werden mittels Logger aufgezeichnet.

## *Transaktionalität* 

*\<Erklärung>*

...

## *Security* 

Haben wir laut Leander nicht? Dachte schon?

[comment]: <> (#############################################################################)

# Architekturentscheidungen 

Fullstack .net core
Frontend: Blazor C#
Backend: C# mit mysql db

[comment]: <> (#############################################################################)

# Qualitätsanforderungen

::: formalpara-title
**Weiterführende Informationen**
:::

Siehe [Qualitätsanforderungen](https://docs.arc42.org/section-10/) in
der online-Dokumentation (auf Englisch!).

## Qualitätsbaum 

## Qualitätsszenarien 

[comment]: <> (#############################################################################)

# Risiken und technische Schulden

[comment]: <> (#############################################################################)

# Glossar

| | Erläuterung |
|--|--|
| GUI | Graphical User Interface - Die grafische Oberfläche zur Interaktion mit dem Nutzer. Hier eine Website |

[comment]: <> (#############################################################################)

**Über arc42**

arc42, das Template zur Dokumentation von Software- und
Systemarchitekturen.

Template Version 8.2 DE. (basiert auf AsciiDoc Version), Januar 2023

Created, maintained and © by Dr. Peter Hruschka, Dr. Gernot Starke and
contributors. Siehe <https://arc42.org>.


| Begriff               | Definition                                    |
|--|--|
| *\<Begriff-1>*        | *\<Definition-1>*                             |
| *\<Begriff-2*         | *\<Definition-2>*                             |
