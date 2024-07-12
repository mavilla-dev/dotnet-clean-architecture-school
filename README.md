<a name="top"></a>

## Table of Contents
- [About](#about)
- [References](#references)

## About
**School Management** is a .NET8 demo project showcasing how to leverage Clean Architecture guidance for a project.

| Project Name | Description |
|:-|:-|
| School.Application | Contains majority of application logic |
| School.Core | Project base entities exists here |
| School.Infrastructure | Database Implementations exist here |
| School.RestApi | .NET Minimal API Endpoint |
| School.BFF.Blazor | Incoming - SPA leveraging Blazor and RestAPI |
| School.BFF.React | Incoming - SPA leveraging Remix, React and RestAPI |

Please note that for purposes of showing strengths of Clean Architecture, we implement **Dapper** and **Entity Framework** within the **School.Infrastructure** project. Front-end will also have different views, first being in **React** and another in **Blazor**.

Project is developed using VSCode Dev Containers and Docker.

## References
I wanted to personally learn how to create a Clean Architecture project for personal growth and I could not have done it without the following resources

- [YT Series: REST API following CLEAN ARCHITECTURE & DDD](https://www.youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k)
- [YT Video: In defense of .NET Minimal APIs](https://www.youtube.com/watch?v=4ORO-KOufeU&t=497s)
- [Microsoft .NET Architecture Guides](https://dotnet.microsoft.com/en-us/learn/dotnet/architecture-guides)
- [Awesome README](https://github.com/matiassingers/awesome-readme)

[Back to top](#top)
