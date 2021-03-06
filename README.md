# Learning Cake (Make for C#) withh Frosting
The goal for this repository is to learn how to setup [Cake with Frosting](https://cakebuild.net/docs/running-builds/runners/cake-frosting) and
run it for a basic console app.

This learning tutorial is the second step, after my [Learning Cake](https://github.com/sharafc/learning-cake).
As there, I used VS Code with installed Cake and C# plugins.

The [video from *Lee Richardson*](https://www.youtube.com/watch?v=k7EwcKnQ46M) was a heavy inspiration to get going.

## Preconditions
Frosting is only usable with .NET Core, if you want to run a build in .NET Framework or .NET Tool, you **have** to use
the DSL runners.
You need a current version of the .NET SDK (atmy time of writing 6.0.2).

Also it is pretty helpful to have an IDE with some kind of Cake support. Both Visual Studio and Visual Studio Code have a plugin available, which helps you writing the tasks and basic syntax.

## 1. Install the Cake Frosting Template
Execute:
`dotnet new --install Cake.Frosting.Template`
anywhere on the machine. This will install the templates globally.
```csharp
Die folgenden Vorlagenpakete werden installiert:
   Cake.Frosting.Template

Erfolg: Cake.Frosting.Template::2.1.0 installierte die folgenden Vorlagen:
Vorlagenname                Kurzname      Sprache  Tags
--------------------------  ------------  -------  -------------
Cake Frosting Build Script  cakefrosting  [C#]     Cake/Frosting
```

## 2. Create a Cake Frosting project
Siwtch to the future project folder and execute:
`dotnet new cakefrosting`
This will create a Cake Frosting project including the bootstrappers. A `ls`or `dir`
should show the newly created files:
```csharp
Mode                LastWriteTime     Length Name
----                -------------     ------ ----
d-----       04.03.2022     07:52        1   build
-a----       04.03.2022     07:52       69   build.ps1
-a----       04.03.2022     07:52       50   build.sh
```
This will integrate nicely into an already existing project, since everything build-related
will go into the newly created `build` directory.

Make sure the correct .NET version is targeted in the project. At the of writing, the template targets
`netcoreapp3.1` which is now part of .NET6, thus a change of the `<TargetFramework>` to `net6? is needed.

Add a feasable `.gitignore` since there will be lots of created objects and binaries.

## 4. Execute the build
With one of the bootstrappers, it is possible to execute a build for the first time now:
```csharp
.\build.ps1 --target=Default
// or
./build.sh --target=Default
```

This should output something like this:
<details>
    <summary>
        Powershell output
    </summary>

```csharp
    .\build.ps1 --target=Default

    ========================================
    Hello
    ========================================
    Hello

    ========================================
    World
    ========================================
    World

    ========================================
    Default
    ========================================

    Task                          Duration
    --------------------------------------------------
    Hello                         00:00:00.0164991
    World                         00:00:00.0042322
    --------------------------------------------------
    Total:                        00:00:00.0226552
```
</details>

**HEUREKA!** The first build is running!
