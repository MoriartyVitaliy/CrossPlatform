# CrossPlatform

Варіант 51

## Using and tests
To build any lab project, Change "Solution=" to your lab number 
```bash
dotnet build Build.proj -p:Solution=Lab1 -t:Build
```
```bash
dotnet build Build.proj -p:Solution=Lab1 -t:Test
```
```bash
dotnet build Build.proj -p:Solution=Lab1 -t:Run
```



FOR LAB 3 NuGet Local:
1. Спочатку створіть локальний репозиторій для пакету:
```bash
mkdir Nuget_Local
```

2. Перейдіть в папку з бібліотекою лаби, після чого створюємо пакет та публікуємо його в нашому локальному репозиторії
```bash
cd /path/to/Lab3.Library
dotnet pack --output /your/path/to/Nuget_Local
```

3. Додавання локального NuGet репозиторію до вашого проєкту.
```bash
cd /path/to/Lab3.Console
dotnet nuget add source /your/path/to/Nuget_Local --name LocalRepo
```

4. Додавання NuGet пакету в проект.
```bash
dotnet add package Lab3.Library --version 1.0.0 --source O:\LocalNuGetRepo
```