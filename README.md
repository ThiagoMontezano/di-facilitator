# Dependency Injection Facilitator for .Net Core

Simple library to facilitate dependency injection in .Net Core using attributes (annotations).

## Installation

Use .Net CLI to install.

```bash
dotnet add package di-facilitator --version 0.0.1
```

Use Package Manager

```bash
Install-Package di-facilitator -Version 0.0.1
```

## Usage

Include [Inject] attribute in your class, set your ServiceLifeTime (Singleton, Scoped or Transient) and Type (Interface or Class).

```csharp
    [Inject(ServiceLifetime.Transient, typeof(ISampleSimpleText))]
    public class TransientSample : ISampleSimpleText
    {
        public string print()
        {
            return "This is a transient object";
        }
    }
```

To register all classes with the Inject attribute, add the following code in the application Startup.
PS: void method ConfigureServices (IServiceCollection services).

```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        //...code
        services.AddInject(true);
    }
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to create examples as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)

- [License](LICENSE.md)
- [NuGet Package](https://www.nuget.org/packages/di-facilitator)
