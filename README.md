# Clean-Architecture demo template
Project template to use Clean Architecture

To be clear, if you want to get a Clean Architecture you must know:
- Explicit Dependencies
- Separation of concerns
- Dependency Inversion
- Bounded Context
- Encapsulation
- Single Responsability
- Persistence Ignorance
- Don't repeat yourself - DRY

*Refer to another repo which talks about [SOLID](https://github.com/kenllyacosta/solid)*

This repo uses different type of projects to consume the same architecture:

- Console App
- WebApi
- WebApplication
- WPFApp
- BlazorServerApp

Those projects will never know which database they are consuming. 

## Patterns used:

- **CQRS**
- **MediatR**
- **IoC**
- **Entity Framework Core**
- **Fluent Validation**
- **Generic Repository**
