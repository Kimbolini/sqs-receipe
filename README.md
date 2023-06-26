<details>
<summary>Inhaltsverzeichnis </summary> 

[[_TOC_]]

</details>

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

**Über arc42**

arc42, das Template zur Dokumentation von Software- und
Systemarchitekturen.

Template Version 8.2 DE. (basiert auf AsciiDoc Version), Januar 2023

Created, maintained and © by Dr. Peter Hruschka, Dr. Gernot Starke and
contributors. Siehe <https://arc42.org>.

# 1 Einführung und Ziele

Dieses Dokument beschreibt die Software-Architektur des Rezeptedatenbank-Systems. Das System dient dem Finden und Abspeichern von Rezepten. Es soll im Internet einem breiten Publikum zur Verfügung stehen.

[comment]: <> (#############################################################################)

## Qualitätsziele

## Stakeholder


| Stakeholder          | Erwartungshaltung                 |
|-----------------|-----------------------------------|
| Nutzer im Internet   | Schnelle, intuitive Bedienung und Funktion der Website. Keine Bugs, keine Wartezeiten.                |
| Entwickler   | Gut wartbarer, erweiterbarer und lesbarer Code                  |
| Betreiber der themealdb-API  | Kein Missbrauch ihrer API                |
|     |               |

[comment]: <> (#############################################################################)

# Randbedingungen

### Technische Randbedingungen

| Thema       | Erläuterung                 |
|-----------------|-----------------------------------|
| Grafische Oberfläche | Nutzer können mittels einer Website mit dem System interagieren |
| Schutz vor Attacken | DDOs-Schutz, Eingabenschutz |
| Skalierbarkeit | Falls die Nutzungshäufigkeit der Anwendung steigt  |
| Programmiersprache | Das Rezeptsystem wurde fullstack in C# programmiert |
| Betriebssysteme | Das Rezeptsystem unterstützt (mindestens) Windows, Linux und MacOS|
| Betriebsmodi| Das Rezeptsystem kann aus den wichtigsten IDEs, von Buildservern und von der Kommandozeile aus gestartet werden.|
| Build | .. baut sich selbst? |

### Konventionen

| Thema       | Erläuterung                 |
|-----------------|-----------------------------------|
| Source Code | Quelltextverwaltung bei GitHub, <br> https://github.com/Kimbolini/sqs-receipe |
| Defect Tracking | Mittels GitHub issues: <br> https://github.com/Kimbolini/sqs-receipe/issues |

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
|--|--|
| Nutzer - Website | Suchanfrage |  |

**\<optional: Erläuterung der externen fachlichen Schnittstellen>**

## Technischer Kontext

**\<Diagramm oder Tabelle>**

**\<optional: Erläuterung der externen technischen Schnittstellen>**

**\<Mapping fachliche auf technische Schnittstellen>**

[comment]: <> (#############################################################################)

# Lösungsstrategie

[comment]: <> (#############################################################################)

# Bausteinsicht

## Whitebox Gesamtsystem

<img src="images/Grobarchitektur_grob.png"  width="60%">

Begründung

Frontend und Backend werden zur Kapselung der Businesslogik und für bessere Skalierbarkeit aufgeteilt.

Enthaltene Bausteine

| Name | Verantwortung |
|--|--|
| A | Das Backend mit der Datenbank A1 und dem Business Layer A2. A2 stellt Dienste zur Verfügung, um Daten aus der Datenbank zu holen/schreiben. A3 dient dem Administrator zur Wartung. |
| B | Das Frontend mit der graphischen Oberfläche B1 und Logik B2, um mit der mealdb-API und dem Backend zu interagieren. B3 dient dem Administrator zur Wartung und Einsicht des aktuellen Zustands des Systems. |


Wichtige Schnittstellen

- Frontend - themealdb API: Kommunikation über REST-Schnittstelle der mealdb-API
- Frontend - backend: Die beiden Dienste kommunizieren über eine REST-Schnittstelle

### \<Name Blackbox 1> 

*\<Zweck/Verantwortung>*

*\<Schnittstelle(n)>*

*\<(Optional) Qualitäts-/Leistungsmerkmale>*

*\<(Optional) Ablageort/Datei(en)>*

*\<(Optional) Erfüllte Anforderungen>*

*\<(optional) Offene Punkte/Probleme/Risiken>*

### \<Name Blackbox 2> 

*\<Blackbox-Template>*

### \<Name Blackbox n> 

*\<Blackbox-Template>*

### \<Name Schnittstelle 1> 

...

### \<Name Schnittstelle m> 

## Ebene 2

### Whitebox *\<Baustein 1>* 

*\<Whitebox-Template>*

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

<img src="images/Komponentendiagramm.png"  width="60%">

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

# Querschnittliche Konzept

## *Logging* 

Transaktionen in der Datenbank 

## *Transaktionalität* 

*\<Erklärung>*

...

## *Security* 

Haben wir laut Leander nicht? Dachte schon?

[comment]: <> (#############################################################################)

# Architekturentscheidungen 

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

# Qualitätsmaßnahmen

Was ist wie abgesichert

- Performanceanforderungen - wieviel Anfragen pro Sekunde? Wie schnell?
- Rest service testen - Unit-Tests?
- Statische Codequalität abgesichert über .. 
- Lint (z.B. für Dockerimage) 
- Sync, trivy (Tools um zB wegen Dependencies zu überprüfen)

[comment]: <> (#############################################################################)

# Glossar


| Begriff               | Definition                                    |
|--|--|
| *\<Begriff-1>*        | *\<Definition-1>*                             |
| *\<Begriff-2*         | *\<Definition-2>*                             |
