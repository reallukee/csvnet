<p align="center">
<img alt="Logo" src="./assets/csvnet.svg" style="width: 128px; height; 128px">
</p>

<h1 align="center"><b>CSVNet</b></h1>

<p align="center">
<img alt="Licenza" src="https://img.shields.io/badge/Licenza-MIT-%2300AA00" />
<img alt="Versione" src="https://img.shields.io/badge/Versione-2.0.0-%2300AAFF" />
<img alt=".NET" src="https://img.shields.io/badge/.NET-7.0-%23FFCC44" />
</p>

<p align="center">
📊 Una Libreria .NET per Scrivere, Leggere e Modificare File in Formato CSV.
</p>

# Indice

- [Introduzione](#introduzione)
- [Esempi](#esempi)
- [Download](#download)
- [Documentazione](./DOCS.md)
- [Compilazione](#compilazione)
- [Autore](#autore)
- [Licenza](#licenza)



# Introduzione

## `Clients.csv`

```
Nome;Cognome;Città
Luigi;Giallo;Mozzo
Mario;Rossi;Torino
Luigi;Verde;Milano
Franco;Blu;Firenze
```

## Codice

```csharp
using CSVNet;

CSVDocument Doc = new();

// Apro il Documento CSV.
Doc.Load("Clients.csv", ";");

for (int I = 1; I < Doc.GetRowCount(); I++)
{
    // Ottengo la Cella.
    string Name = Doc.GetCell(I, 0);
     
    if (Name == "Luigi")
    {
        // Imposto la Cella.
        Doc.SetCell(I, 0, "Maria");
    }
}

// Salvo il Documento CSV.
Doc.Save("ClientsUpdated.csv", ";");
```

## `ClientsUpdated.csv`

```
Nome;Cognome;Città
Maria;Giallo;Mozzo
Mario;Rossi;Torino
Maria;Verde;Milano
Franco;Blu;Firenze
```



# Esempi

- [Caricare un Documento](#caricare-un-documento)
- [Salvare un Documento](#salvare-un-documento)
- [Aggiungere una Colonna](#aggiungere-una-colonna)
- [Aggiungere una Riga](#aggiungere-una-riga)
- [Rimuovere una Colonna](#rimuovere-una-colonna)
- [Rimuovere una Riga](#rimuovere-una-riga)
- [Ottenere Contenuto Cella](#ottenere-contenuto-cella)
- [Impostare Contenuto Cella](#impostare-contenuto-cella)



## Caricare un Documento

```csharp
// ...

// Istanza classe CSVDocument.
CSVDocument Doc = new();

// Carico da file.
Doc.Load("Clients.csv", ";"))

string[] Clients = {
    "Nome;Cognome;Città",
    "Maria;Giallo;Mozzo",
    "Mario;Rossi;Torino",
    "Maria;Verde;Milano",
    "Franco;Blu;Firenze"
};

// Carico da array.
Doc.Load(Clients, ";"))

// ...
```



## Salvare un Documento

```csharp
// ...

// Istanza classe CSVDocument.
CSVDocument Doc = new();

// Salvo su file.
Doc.Save("Clients.csv", ";"))

string[] Clients;

// Salvo su array.
Doc.Save(Clients, ";"))

// ...
```



## Aggiungere una Colonna

```csharp
// ...

// Aggiunge una colonna alla fine.
Doc.AddCol("Hello!");
// Aggiunge una colonna all'inizio.
Doc.AddColAtStart("Hello!");
// Aggiunge una colonna nella posizione 1.
Doc.AddColAt(1, "Hello!");

// ...
```



## Aggiungere una Riga

```csharp
// ...

// Aggiunge una riga alla fine.
Doc.AddRow("Hello!");
// Aggiunge una riga all'inizio.
Doc.AddRowAtStart("Hello!");
// Aggiunge una riga nella posizione 1.
Doc.AddRowAt(1, "Hello!");

// ...
```



## Rimuovere una Colonna

```csharp
// ...

// Aggiunge una colonna alla fine.
Doc.RemoveCol();
// Aggiunge una colonna all'inizio.
Doc.RemoveColAtStart();
// Aggiunge una colonna nella posizione 1.
Doc.RemoveColAt(1);

// ...
```



## Rimuovere una Riga

```csharp
// ...

// Aggiunge una riga alla fine.
Doc.RemoveRow();
// Aggiunge una riga all'inizio.
Doc.RemoveRowAtStart();
// Aggiunge una riga nella posizione 1.
Doc.RemoveRowAt(1);

// ...
```



## Ottenere Contenuto Cella

```csharp
// ...

// Ottengo la cella (0, 0) come una stringa.
string StrData = Doc.GetCellAs<string>(0, 0);
// Ottengo la cella (0, 1) come un intero.
int IntData = Doc.GetCellAs<int>(0, 1);
// Ottengo la cella (0, 2) come un double.
double DblData = Doc.GetCellAs<double>(0, 2);

// ...
```



## Impostare Contenuto Cella

```csharp
// ...

string StrData = "Hello!";
int IntData = 0;
double DblData = 10.0;

// Imposto la cella (0, 0).
Doc.SetCell(0, 0, StrData);
// Imposto la cella (0, 1).
Doc.SetCell(0, 1, IntData);
// Imposto la cella (0, 2).
Doc.SetCell(0, 2, DblData);

// ...
```



# Download

L'ultima versione di CSVNet può essere scaricata da GitHub.



# Compilazione

- [Script](#script-consigliato) (*Consigliato*)
- [Visual Studio](#visual-studio)
- [.NET CLI](#net-cli)



## Script (*Consigliato*)

1. Clona questa repository utilizzando Git.

    ```terminal
    git clone https://github.com/reallukee/csvnet.git
    ```

2. Installa .NET SDK 7.0.

    - [Windows](https://docs.microsoft.com/en-us/dotnet/core/install/windows)
    - [Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux)
    - [MacOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos)

3. *(Opzionale)* Verifica l'installazione.

    ```terminal
    dotnet --list-sdks
    ```

    Output atteso dal comando.

    ```terminal
    7.0.XXX [Path to SDK]
    ```

4. Entra nella cartella del progetto.

    ```terminal
    cd ./csvnet/script
    ```

5. Esegui lo script.

    - Windows

        ```terminal
        start ./build.cmd
        ```

    - Linux e MacOS

        ```terminal
        chmod +x ./build.sh && ./build.sh
        ```

6. L'output della compilazione si troverà in `./csvnet/bin/Release/net7.0`.



## Visual Studio

> ⚠️ Solo su Windows.

1. Clona questa repository utilizzando Git.

    ```terminal
    git clone https://github.com/reallukee/csvnet.git
    ```

2. Installa [Visual Studio Community 2022]().

    > 💡 Clicca [qui](./vs.vsconfig) per scaricare la configurazione automatica di Visual Studio 2022.

    Installare i seguenti carichi di lavoro:

    - `Sviluppo di applicazioni Desktop .NET`

3. Apri la soluzione.
4. Seleziona il profilo `Release`.
5. Clicca `Compilazione > Compila soluzione`.
6. L'output della compilazione si troverà in `./csvnet/bin/Release/net7.0`.



## .NET CLI

1. Clona questa repository utilizzando Git.

    ```terminal
    git clone https://github.com/reallukee/csvnet.git
    ```

2. Installa .NET SDK 7.0.

    - [Windows](https://docs.microsoft.com/en-us/dotnet/core/install/windows)
    - [Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux)
    - [MacOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos)

3. *(Opzionale)* Verifica l'installazione.

    ```terminal
    dotnet --list-sdks
    ```

    Output atteso dal comando.

    ```terminal
    7.0.XXX [Path to SDK]
    ```

4. Entra nella cartella del progetto.

    ```terminal
    cd ./csvnet/csvnet
    ```

5. Compila il progetto.

    ```terminal
    dotnet build -c Release
    ```

6. L'output della compilazione si troverà in `./csvnet/bin/Release/net7.0`.



# Autore

- [Luca Pollicino](https://github.com/reallukee/)



# Licenza

Questo progetto è sotto licenza [MIT](./LICENSE).
